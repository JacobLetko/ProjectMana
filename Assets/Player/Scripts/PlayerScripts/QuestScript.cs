using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestScript : MonoBehaviour
{
    public bool chest1;
    public bool chest2;
    public bool chest3;
    public GameObject wall;

    private void OnTriggerEnter(Collider other)
    {
        GameObject thing = other.gameObject;
        if (thing.name == "chest1")
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

    private void Update()
    {
        if (chest1 == true && chest2 == true)
            wall.SetActive(false);
    }
}
