using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    public Vector3 respawnPos;
    public GameObject player;
    public Image deathbox;
    Color imgChange;
    bool dead = false;


    private void Start()
    {
        respawnPos = player.transform.position;
        imgChange = deathbox.color;
    }

    private void Update()
    {
        if (player.GetComponent<AbilityScore>().abilities.Health <= 0)
        {
            dead = true;
        }

        if (dead && imgChange.a < 1)
        {
            imgChange.a += .07f;
            
        }

        if(imgChange.a > 1 && dead)
        {
            dead = false;
            player.transform.position = respawnPos;
            player.transform.rotation = Quaternion.Euler(0,0,0);
            player.GetComponent<AbilityScore>().SetDefaultValues(player.GetComponent<AbilityScore>().abilities);
            player.GetComponent<AbilityScore>().abilities = player.GetComponent<AbilityScore>().SetStatusScores(player.GetComponent<AbilityScore>().abilities);
        }

        if(!dead && imgChange.a > 0)
        {
            imgChange.a -= .3f * Time.deltaTime;
        }

        deathbox.color = imgChange;
    }
}
