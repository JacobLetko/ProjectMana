using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulDrainObjBehaviour : MonoBehaviour
{
    [SerializeField]
    private EnemyController _controller;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Stun()
    {
        if (_controller.stateStack.Peek() == EnemyController.States.STUNNED)
        {

        }
    }
}
