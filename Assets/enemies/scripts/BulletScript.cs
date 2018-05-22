using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float damage;
    public string target;

    private void OnTriggerEnter(Collider other)
    {
        if(target != other.gameObject.tag)
        {
            GameObject hull = other.gameObject;
            if(hull.GetComponent<AbilityScore>() != null)
            {
                hull.GetComponent<AbilityScore>().abilities.Health -= damage;   
            }
        }
    }
}
