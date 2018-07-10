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
        _abilityScore.abilities.healthMonitor += Stunned;

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
        availibleStates.Add(States.STUNNED, new AIbehavior(WaitAbit));
        availibleStates.Add(States.DEATH, new AIbehavior(OnDeath));

        stateStack.Push(States.GOTO);
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
        //GetComponent<CapsuleCollider>().enabled = false;
        _runUpdate = false;
    }

    public void Stunned()
    {
        if ((_abilityScore.abilities.Health <= Mathf.Round(_abilityScore.abilities.HealthCap / 3)) && _abilityScore.abilities.Health > 0)
        {
            Debug.Log("Ai Stunned");
            stateStack.Pop();
            stateStack.Push(EnemyController.States.STUNNED);
        }
    }

    public void WaitAbit()
    {
        StartCoroutine(IWait());

    }

    IEnumerator IWait()
    {
        float duration = 3f;

        float totalTime = 0;
        while (totalTime <= duration)
        {
            if (_abilityScore.abilities.Health <= 0)
            {
                yield break;
            }
            totalTime += Time.deltaTime;
            yield return null;
        }

        _abilityScore.abilities.Health = Mathf.RoundToInt(_abilityScore.abilities.HealthCap / 2);

        stateStack.Pop();
        stateStack.Push(EnemyController.States.GOTO);

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
