using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class chest : MonoBehaviour
{
    /*
     * need messages to display over chest letter by letter using corutine
     * need string for message can only be 72 per message
     * need int for index of string
     * needs to be on center chest for message to display over
     * needs to start when player gets close to chest
     * 
     * string hi = "hello";
     *  Debug.Log(hi[2]);
     */

    public string message;
    int index = 0;
    bool reading = false;
    public float delay;
    public TextMeshProUGUI messaqgeCenter;
    public Image background;

    private void Start()
    {
        messaqgeCenter.gameObject.SetActive(false);
        background.gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        messaqgeCenter.gameObject.SetActive(true);
        background.gameObject.SetActive(true);
        reading = true;
        StartCoroutine(display());
    }

    private void OnTriggerExit(Collider other)
    {
        messaqgeCenter.gameObject.SetActive(false);
        background.gameObject.SetActive(false);
        reading = false;
        index = 0;
        messaqgeCenter.text = "";
    }

    IEnumerator display()
    {

        if (reading)
        {
            messaqgeCenter.text += message[index];
            index++;
        }
        yield return new WaitForSeconds(delay);
    }
}
