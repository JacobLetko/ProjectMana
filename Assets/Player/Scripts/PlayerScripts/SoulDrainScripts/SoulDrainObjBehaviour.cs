using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulDrainObjBehaviour : MonoBehaviour
{
    public Transform player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }

    private void Update()
    {
        transform.LookAt(player.position + new Vector3(0,1,0));
    }
}
