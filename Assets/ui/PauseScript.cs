using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject wheel;
    public GameObject menu;

    bool paused = false;

    void Start()
    {
        paused = false;
        wheel.SetActive(false);
        menu.SetActive(false);
    }

	void Update ()
    {
        if (Input.GetKeyDown("escape") && paused == false)
        {
            paused = true;
            Time.timeScale = 0.0f;
            menu.gameObject.SetActive(true);
        }

        else if (Input.GetKeyDown("escape") && paused == true)
        {
            paused = false;
            Time.timeScale = 1.0f;
            menu.SetActive(false);
        }

        if (Input.GetKey("tab"))
            wheel.SetActive(true);
        else
            wheel.SetActive(false);
	}
}
