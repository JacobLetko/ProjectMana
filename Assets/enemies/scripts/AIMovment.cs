using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovment : MonoBehaviour
{
    public Transform player;
    NavMeshAgent _nav;
    [SerializeField]
    private float _searchRadius;

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
        if (player == null)
        {
            RaycastHit hit;
          
            if (Physics.SphereCast(transform.position, _searchRadius, Vector3.zero, out hit, 0, LayerMask.GetMask("Default"), QueryTriggerInteraction.Ignore))
            {
                player = hit.collider.transform;
            }
            else
            {
                if (player != null)
                {
                    player = null;
                }
            }
        }

        if(player != null)
        {
            _nav.SetDestination(player.position);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position,_searchRadius);
    }
}
