using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public float health
    {
        get { return player.GetComponent<AbilityScore>().abilities.Health; }
        set { }
    }
    private float _Health;


    public float mana
    {
        get { return player.GetComponent<AbilityScore>().abilities.ManaCap; }
        set {  }
    }
    private float _Mana;

    public Slider healthBar;
    public Slider manaBar;
    public GameObject canvas;
    public GameObject HUDmenu;
    public GameObject pausemenu;

    public GameObject player;

    private void Start()
    {
        health = player.GetComponent<AbilityScore>().abilities.Health;
        mana = player.GetComponent<AbilityScore>().abilities.Mana;
        _Health = health;
        _Mana = mana;
        HUDmenu.GetComponent<RectTransform>().sizeDelta = new Vector2(canvas.GetComponent<RectTransform>().rect.width, canvas.GetComponent<RectTransform>().rect.height);
        pausemenu.GetComponent<RectTransform>().sizeDelta = new Vector2(canvas.GetComponent<RectTransform>().rect.width, canvas.GetComponent<RectTransform>().rect.height);
    }

    private void Update()
    {
        healthBar.value = calcHealth();
        //manaBar.value = calcMana();

    }

    float calcHealth()
    {
        health = player.GetComponent<AbilityScore>().abilities.Health;
        return player.GetComponent<AbilityScore>().abilities.Health / _Health;
    }

    float calcMana()
    {
        mana = player.GetComponent<AbilityScore>().abilities.Mana;
        return player.GetComponent<AbilityScore>().abilities.Mana /_Mana;
    }
}
