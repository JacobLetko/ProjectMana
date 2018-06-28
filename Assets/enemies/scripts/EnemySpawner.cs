using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public List<GameObject> enemies;
    public GameObject player;
    public int AreaLength;


    private void Start()
    {
        for(int i=0; i<10;i++)
        {
            enemies.Add(Instantiate(enemy));
        }
    }
    // Update is called once per frame
    void Update ()
    {
        RaycastHit hit;
        Ray target = new Ray(transform.position, player.GetComponent<Transform>().position);
        Debug.DrawRay(transform.position, player.GetComponent<Transform>().position);

        //if (Physics.Raycast(target, out hit, AreaLength))
        //{
        //    if (hit.collider.tag == "Player")
        //    {

        //    }
        //}
    }
}
