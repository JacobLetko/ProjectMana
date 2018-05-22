using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public void LoadSceneByName(string name)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(name);
    }

    public void quit()
    {
        Application.Quit();
    }
}
