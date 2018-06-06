using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Vector3 respawnPos;
    public GameObject player;

    private void Start()
    {
        respawnPos = player.transform.position;
    }

    private void Update()
    {
        if(player.GetComponent<AbilityScore>().abilities.Health <= 0)
        {
            Debug.Log("dead");
            player.transform.position = respawnPos;
            player.GetComponent<AbilityScore>().SetDefaultValues(player.GetComponent<AbilityScore>().abilities);
            player.GetComponent<AbilityScore>().abilities = player.GetComponent<AbilityScore>().SetStatusScores(player.GetComponent<AbilityScore>().abilities);
        }
    }
}
