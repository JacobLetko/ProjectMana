using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovment : MonoBehaviour
{
    public GameObject player;
    NavMeshAgent nav;

    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();
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
        if(player != null)
        {
            nav.SetDestination(player.transform.position);
        }
    }
}
