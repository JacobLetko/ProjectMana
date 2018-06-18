using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AIMovment))]
[RequireComponent(typeof(AIattack))]
public class EnemyController : MonoBehaviour
{
    public AIMovment movement;
    public AIattack attack;

    public enum States
    {
        AVOID = 0, GOTO = 1, ATTACK = 2, DEATH = 3
    }

    public delegate void AIbehavior();
    public Dictionary<States, AIbehavior> availibleStates = new Dictionary<States, AIbehavior>();

    public Stack<States> stateStack = new Stack<States>(); 

    private void Awake()
    {
        GetComponent<AbilityScore>().abilities.healthMonitor += Death;

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





        stateStack.Push(States.GOTO);
    }

    public void Death()
    {
        //run Death animation and death stuff
        Debug.Log("Running Ai death");
    }

    public States myState;
    // Update is called once per frame
    void Update()
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

}
