using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject wheel;
    public GameObject menu;
    public GameObject player;

    public bool paused;

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
            player.GetComponent<PlayerController>().PausePlayer(paused);
            Time.timeScale = 0.0f;
            menu.gameObject.SetActive(true);
        }

        else if (Input.GetKeyDown("escape") && paused == true)
        {
            paused = false;
            player.GetComponent<PlayerController>().PausePlayer(paused);
            Time.timeScale = 1.0f;
            wheel.SetActive(false);
            menu.SetActive(false);
        }

        if (Input.GetKey("tab"))
            wheel.SetActive(true);
        else
            wheel.SetActive(false);
	}
}
