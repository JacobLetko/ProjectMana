using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public GameObject chest;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void LoadSceneByName(string name)
    {
        Time.timeScale = 1;
        
        SceneManager.LoadScene(name);
        if (name != "Main Menu" || name != "Win Scene")
            Cursor.visible = false;
        else
            Cursor.visible = true;
    }

    public void quit()
    {
        Application.Quit();
    }

    private void Update()
    {
        if(chest != null && chest.active == false)
        {
            LoadSceneByName("Win");
        }
    }
}
