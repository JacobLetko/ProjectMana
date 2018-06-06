using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// put on areas such as spikes or "pits" to do damage over time or do redicules amounts of damage
/// </summary>
public class DOT : MonoBehaviour
{
    public float damage;
    public float timer;

    public List<GameObject> stuff;

    private void Start()
    {
        stuff = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (stuff.Contains(other.gameObject) == false)
        {
            stuff.Add(other.gameObject);
            StartCoroutine(doDamage());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        stuff.Remove(other.gameObject);
    }

    IEnumerator doDamage()
    {
        while (stuff.Count > 0)
        {
            foreach (GameObject g in stuff)
            {
                g.GetComponent<AbilityScore>().abilities.Health -= damage;
            }
            yield return new WaitForSeconds(timer);
        }
    }
}
