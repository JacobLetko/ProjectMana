using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public float damage;
    public string target;
    private List<GameObject> stuff;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == target)
        {
            stuff.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        stuff.Remove(other.gameObject);
    }

    public void attack()
    {
        GameObject hull;
        for (int i = 0; i < stuff.Capacity; i++)
        {
            hull = stuff[i];
            if (hull.GetComponent<AbilityScore>() != null)
            {
                hull.GetComponent<AbilityScore>().abilities.Health -= damage;
            }
        }
         
    }
}
