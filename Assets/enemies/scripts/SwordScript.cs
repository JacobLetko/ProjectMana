using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public float damage;
    public string target;
    private List<GameObject> _stuff;

    private void Awake()
    {
        _stuff = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == target)
        {
            _stuff.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _stuff.Remove(other.gameObject);
    }

    public void attack()
    {
        GameObject hull;
        for (int i = 0; i < _stuff.Count; i++)
        {          
            if (_stuff[i] != null)
            {
                hull = _stuff[i];
                if (hull.GetComponent<AbilityScore>() != null)
                {
                    hull.GetComponent<AbilityScore>().abilities.Health -= damage;
                }
            }
        }
    }
}
