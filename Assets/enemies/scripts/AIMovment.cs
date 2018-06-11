using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovment : MonoBehaviour
{
    public EnemyController controller;
    public Transform target;
    NavMeshAgent _nav;
    [SerializeField]
    private float _searchRadius;

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


    private void Start()
    {
        _nav = GetComponent<NavMeshAgent>();
        if (_nav == null)
        {
            Debug.LogError("No NavMeshAgent detected");
        }
    }


    private void Update()
    {
        if (target == null)
        {
            RaycastHit hit;
          
            if (Physics.SphereCast(transform.position, _searchRadius, Vector3.zero, out hit, 0, LayerMask.GetMask("Default"), QueryTriggerInteraction.Ignore))
            {
                if ((hit.collider.transform.tag != "Ground") && (hit.collider.transform.tag != "Wall"))
                {
                    target = hit.collider.transform;
                }
            }
            else
            {
                if (target != null)
                {
                    target = null;
                }
            }
        }    
    }

    public void GoTo()
    {
        _nav.destination = target.position;
        if (_nav.pathStatus == NavMeshPathStatus.PathComplete)//stopping distance is adjusted on the navmesh agent and is taken into account here
        {
            controller.stateStack.Pop();
            controller.stateStack.Push(EnemyController.States.ATTACK);
        }
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _searchRadius);
    }
}
