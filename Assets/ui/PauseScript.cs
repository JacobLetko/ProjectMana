using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject wheel;
    public GameObject menu;
    public GameObject player;
    public GameObject HUD;

    public bool paused;

    void Start()
    {
        paused = false;
        wheel.SetActive(false);
        menu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown("escape") && paused == false)
        {
            paused = true;
            player.GetComponent<PlayerController>().PausePlayer(paused);
            cursorstate(true);
            Time.timeScale = 0.0f;
            HUD.gameObject.SetActive(false);
            menu.gameObject.SetActive(true);
        }

        else if (Input.GetKeyDown("escape") && paused == true)
        {
            paused = false;
            player.GetComponent<PlayerController>().PausePlayer(paused);
            cursorstate(false);
            Time.timeScale = 1.0f;
            wheel.SetActive(false);
            menu.SetActive(false);
            HUD.gameObject.SetActive(true);
        }

        if (Input.GetKey("tab"))
        {
            cursorstate(true);
            wheel.SetActive(true);
        }
        else
        {
            if(!paused)
                cursorstate(false);
            wheel.SetActive(false);
        }
    }

    public void resume()
    {
        paused = false;
        player.GetComponent<PlayerController>().PausePlayer(paused);
        cursorstate(false);
        Time.timeScale = 1.0f;
        wheel.SetActive(false);
        menu.SetActive(false);
    }

    private void cursorstate(bool state)
    {
        Cursor.visible = state;
    }
}
