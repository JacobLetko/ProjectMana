using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestScript : MonoBehaviour
{
    private bool chest1;
    private bool chest2;
    public bool chest3;
    public GameObject wall;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject thing = collision.gameObject;
        if (thing.name == "Chest1")
        {
            chest1 = true;
            thing.SetActive(false);
        }
        if (thing.name == "chest2")
        {
            chest2 = true;
            thing.SetActive(false);
        }
        if (thing.name == "chest3")
        {
            chest3 = true;
            thing.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (chest1 == true && chest2 == true)
            wall.SetActive(false);
    }
}
