using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovment : MonoBehaviour
{
    public EnemyController controller;
    public Transform target;
    public NavMeshAgent nav;
    [SerializeField]
    private float _searchRadius;
    [SerializeField]
    LayerMask layers;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        if (nav == null)
        {
            Debug.LogError("No NavMeshAgent detected");
        }

        if (GetComponent<EnemyController>() != null)
        {
            controller = GetComponent<EnemyController>();
        }
        else
        {
            Debug.Log("No EnemyController located on: " + gameObject.name);
        }
    }



    private void Update()
    {

        Collider[] hit = Physics.OverlapSphere(transform.position, _searchRadius, layers, QueryTriggerInteraction.Ignore);

        if (hit.Length > 0)
        {
            foreach (Collider item in hit)
            {
                if (item != null)
                {
                    if (item.tag == "Player")
                    {

                        if (item.transform != transform)
                        {
                            target = item.transform;
                            Debug.Log(target.name);
                            break;
                        }
                    }
                }

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

    public void GoTo()
    {
        if (target != null)
        {
            if (Vector3.Distance(target.position, transform.position) < _searchRadius)
            {
                nav.destination = target.position;
                if (nav.pathStatus == NavMeshPathStatus.PathComplete)//stopping distance is adjusted on the navmesh agent and is taken into account here
                {
                    if ((nav.remainingDistance != Mathf.Infinity) && ((nav.remainingDistance - nav.stoppingDistance) <= 0.1f))
                    {
                        controller.stateStack.Pop();
                        controller.stateStack.Push(EnemyController.States.ATTACK);
                    }
                }
            }
            else
            {
                nav.destination = transform.position;
            }
        }
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _searchRadius);
    }
}
