using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public AIMovment movement;

    public enum States
    {
        IDLE = 0, AVOID = 1, SEARCH = 2, GOTO = 3, ATTACK = 4, DEATH = 5
    }

    public delegate void AIbehavior();
    public Dictionary<States, AIbehavior> availibleStates = new Dictionary<States, AIbehavior>();

    public Stack<States> stateStack = new Stack<States>(); 

    private void Awake()
    {
        if (GetComponent<AIMovment>() != null)
        {
            movement = GetComponent<AIMovment>();
            availibleStates.Add(States.GOTO, new AIbehavior(movement.GoTo));
        }
        else
        {
            Debug.LogError("There is no AIMovement script on: " + gameObject.name);
        }






    }

    // Update is called once per frame
    void Update()
    {

        if (stateStack.Count > 0)
        {
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
