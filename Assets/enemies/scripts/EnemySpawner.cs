using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public List<GameObject> enemies;
    public GameObject player;
    public int AreaLength = 10;


    private void Start()
    {
        enemies = new List<GameObject>();
    }

    void Update ()
    {
        RaycastHit hit;
        Vector3 dir = ((player.transform.position + Vector3.up) - transform.position).normalized * AreaLength;
        Ray target = new Ray(transform.position, dir);
        Debug.DrawRay(transform.position, dir);
        if (Physics.Raycast(target, out hit, AreaLength)) { }
        else
            StartCoroutine(Spawn());
        foreach(GameObject g in enemies)
        {
            if (g == null)
                enemies.Remove(g);
        }
    }

    IEnumerator Spawn()
    { 
        if (enemies.Count < 10)
        {
            yield return new WaitForSeconds(5);
            enemies.Add(Instantiate(enemy));
            enemies[enemies.Count - 1].transform.position = transform.position + Vector3.up;
        }
    }
}
