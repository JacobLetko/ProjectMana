using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public AIMovment movment;
    public Abilities abilities;


    public enum States
    {
        IDLE = 0, AVOID = 1, SEARCH = 2, GOTO = 3, ATTACK = 4
    }

    public delegate void AIbehavior();
    public Dictionary<States, AIbehavior> availibleStates = new Dictionary<States, AIbehavior>();

    public Stack<States> stateStack = new Stack<States>(); 


    public AIbehavior currentState;



    private void Awake()
    {
        availibleStates.Add(States.GOTO, new AIbehavior(movment.GoTo));

    }

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        availibleStates[stateStack.Peek()]();
    }
}
