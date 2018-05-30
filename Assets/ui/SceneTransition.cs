using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void LoadSceneByName(string name)
    {
        Time.timeScale = 1;
        if (name != "Main Menu")
            Cursor.visible = false;
        SceneManager.LoadScene(name);
    }

    public void quit()
    {
        Application.Quit();
    }
}
