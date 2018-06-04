using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseScript : MonoBehaviour
{
    public GameObject wheel;
    public GameObject menu;
    public GameObject HUD;
    public bool paused;

    [Header("stats stuff")]
    public GameObject player;
    public GameObject healthText, manaText, StrText, DexText, ConText, IntText, WisText, ChaText, ExpText, LevelText;

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
            getStats();
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

    private void getStats()
    {
        AbilityScore stats = player.GetComponent<AbilityScore>();

        healthText.GetComponent<TextMeshProUGUI>().text = "HP: " + stats.abilities.Health.ToString();
        manaText.GetComponent<TextMeshProUGUI>().text = "MP: " + stats.abilities.Mana.ToString();
        ExpText.GetComponent<TextMeshProUGUI>().text = "EXP: " + stats.abilities.Experience.ToString();
        LevelText.GetComponent<TextMeshProUGUI>().text = "Level: " + stats.Level.ToString();

        StrText.GetComponent<TextMeshProUGUI>().text = "Str: " + stats.abilities.Str.ToString();
        ConText.GetComponent<TextMeshProUGUI>().text = "Con: " + stats.abilities.Con.ToString();
        DexText.GetComponent<TextMeshProUGUI>().text = "Dex: " + stats.abilities.Dex.ToString();
        IntText.GetComponent<TextMeshProUGUI>().text = "Int: " + stats.abilities.Int.ToString();
        WisText.GetComponent<TextMeshProUGUI>().text = "Wis: " + stats.abilities.Wis.ToString();
        ChaText.GetComponent<TextMeshProUGUI>().text = "Cha: " + stats.abilities.Cha.ToString();
    }
}
