using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AIMovment))]
[RequireComponent(typeof(AIattack))]
public class EnemyController : MonoBehaviour
{
    public AIMovment movement;
    public AIattack attack;
    private AbilityScore _abilityScore;
    private SoulDrainObjManager _soulDrainObjManager;

    bool _runUpdate = true;

    public enum States
    {
        STUNNED = 0, GOTO = 1, ATTACK = 2, DEATH = 3
    }

    public delegate void AIbehavior();
    public Dictionary<States, AIbehavior> availibleStates = new Dictionary<States, AIbehavior>();

    public Stack<States> stateStack = new Stack<States>(); 

    private void Awake()
    {
        if (_soulDrainObjManager == null)
        {
            _soulDrainObjManager = GetComponent<SoulDrainObjManager>();
            if (_soulDrainObjManager == null)
            {
                Debug.LogError("GameObject '" + gameObject.name + "' has not been given a 'SoulDrainManager' componenet.");
            }
        }


        _abilityScore = GetComponent<AbilityScore>();
        _abilityScore.abilities.healthMonitor += Death;

        if (GetComponent<AIMovment>() != null)
        {
            movement = GetComponent<AIMovment>();
            availibleStates.Add(States.GOTO, new AIbehavior(movement.GoTo));
        }
        else
        {
            Debug.LogError("There is no AIMovement script on: " + gameObject.name);
        }

        if (GetComponent<AIattack>() != null)
        {
            attack = GetComponent<AIattack>();
            availibleStates.Add(States.ATTACK, new AIbehavior(attack.Attack));
        }
        else
        {
            Debug.LogError("There is no AIattack script on: " + gameObject.name);
        }
        availibleStates.Add(States.DEATH, new AIbehavior(OnDeath));

    }

    void Start()
    {


        if (GetComponent<CapsuleCollider>().enabled == false)
        {
            GetComponent<CapsuleCollider>().enabled = true;
        }
        movement.nav.speed = _abilityScore.abilities.Speed;

        if (stateStack.Count > 0)
        {
            stateStack.Pop();
        }

        GetComponent<CapsuleCollider>().enabled = true;
        movement.nav.enabled = true;

        stateStack.Push(States.GOTO);
        _runUpdate = true;
    }

    public void Death()
    {
        //run Death animation and death stuff
        if (_abilityScore.abilities.Health <= 0)
        {
            Debug.Log("Running Ai death");
            movement.nav.speed = 0;
            stateStack.Pop();
            stateStack.Push(EnemyController.States.DEATH);
        }
 
    }

    public void OnDeath()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        movement.nav.enabled = false;
        _runUpdate = false;
    }






    public States myState;
    // Update is called once per frame
    void Update()
    {
        if (_runUpdate)
        {
            if (stateStack.Count > 0)
            {
                myState = stateStack.Peek();

                if (availibleStates[stateStack.Peek()] != null)
                {
                    availibleStates[stateStack.Peek()]();
                }
                else
                {
                    Debug.LogError("The state \"" + stateStack + "\" does not have any assigned functions to its delegate.");
                }
            }
            else
            {
                Debug.LogError("There are no items inside the 'stateStack' container");
            }
        }
        else
        {
            _soulDrainObjManager.DrainEffect();
        }




    }

}
