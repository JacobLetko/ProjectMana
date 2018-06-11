using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIattack : MonoBehaviour
{

    public EnemyController controller;
    public Transform target;
    [SerializeField]
    private float _AttackRadius;

    private void Awake()
    {
        if (GetComponent<EnemyController>() != null)
        {
            controller = GetComponent<EnemyController>();
        }
        else
        {
            Debug.Log("No EnemyController located on: " + gameObject.name);
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack()
    {

    }
}
