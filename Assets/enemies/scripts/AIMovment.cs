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
    [SerializeField]
    LayerMask layers;

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
            Collider[] hit = Physics.OverlapSphere(transform.position, _searchRadius, layers, QueryTriggerInteraction.Ignore);

            if (hit.Length > 0)
            {
                foreach (Collider item in hit)
                {
                    if (item != null)
                    {
                        if ((item.tag != "Ground") && (item.tag != "Wall"))
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
        
    }

    public void GoTo()
    {
        if (target != null)
        {
            _nav.destination = target.position;
            if (_nav.pathStatus == NavMeshPathStatus.PathComplete)//stopping distance is adjusted on the navmesh agent and is taken into account here
            {
                if ((_nav.remainingDistance != Mathf.Infinity) && ((_nav.remainingDistance - _nav.stoppingDistance) <= 0.1f))
                {
                    controller.stateStack.Pop();
                    controller.stateStack.Push(EnemyController.States.ATTACK);
                }
            }
        }
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _searchRadius);
    }
}
