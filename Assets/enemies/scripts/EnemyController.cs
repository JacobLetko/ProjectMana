using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public delegate void CurrentEnemyActions();
    public CurrentEnemyActions currentEnemyActions;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnemyActions != null)
        {
            currentEnemyActions();
        }

    }
}
