using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimController : MonoBehaviour
{
    [SerializeField]
    private EnemyController _enemyController;
    [SerializeField]
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    // Use this for initialization
    void Start()
    {
        if (_enemyController == null)
        {
            Debug.LogError("The Enemy model '" + gameObject.name +"' does not have a reference to its EnemyController script!");
        }

        if (_navMeshAgent == null)
        {
            Debug.LogError("The Enemy model '" + gameObject.name + "' does not have a reference to its NavMeshAgent!");
        }

        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemyController.stateStack.Peek() == EnemyController.States.ATTACK)
        {
            _animator.SetBool("isAttacking", true);
        }
        else
        {
            _animator.SetBool("isAttacking", false);

        }

        if (_enemyController.stateStack.Peek() == EnemyController.States.GOTO && _navMeshAgent.velocity.magnitude > 0)
        {
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }
    }
}
