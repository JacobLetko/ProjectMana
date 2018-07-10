using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public List<GameObject> enemies;
    public GameObject player;
    public int AreaLength = 10;
    public LayerMask mask;


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

        if (Physics.Raycast(target, AreaLength, mask))
        /*if (Physics.Raycast(target, out hit, AreaLength)) */{ }

        else
            StartCoroutine(Spawn());

        foreach(GameObject g in enemies)
            if (g == null)
                enemies.Remove(g);
    }

    IEnumerator Spawn()
    { 
        if (enemies.Count < 10)
        {
            GameObject spawnedEnemy = Instantiate(enemy);
            Vector3 desiredPosition = transform.position + Vector3.up + (new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5)));
            NavMeshHit hit;
            if (NavMesh.SamplePosition(desiredPosition, out hit, 5, NavMesh.AllAreas))
            {
                spawnedEnemy.GetComponent<NavMeshAgent>().Warp(hit.position);
                enemies.Add(spawnedEnemy);
            }
            else
            {
                Debug.Log("Spawner cannot spawn enemies in this location");
            }
            
        }
        yield return new WaitForSeconds(5);
    }
}
