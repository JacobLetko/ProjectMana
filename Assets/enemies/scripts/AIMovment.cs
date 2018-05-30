using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovment : MonoBehaviour
{
    public GameObject player;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            player = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            player = null;
    }

    private void Update()
    {
        if (player == null)
        {
            RaycastHit hit;
            if (Physics.SphereCast(transform.position, _searchRadius, Vector3.zero, out hit, 0, LayerMask.GetMask("Default"), QueryTriggerInteraction.Ignore))
            {

            }
        }

        if(player != null)
        {
            _nav.SetDestination(player.transform.position);
        }
    }
}
