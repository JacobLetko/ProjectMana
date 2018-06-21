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

    [Header("lighting")]
    public float max;
    public float current;
    public Light Light;

    [Header("objects")]
    public Slider healthBar;
    public Slider manaBar;
    public Slider brightnessBar;
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
        calcBright();
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
    
    void calcBright()
    {
        /*
         * need to get current bar value and make it current intensity value of light
         * bar.value * max = current ?
        */
        current = max * brightnessBar.value;
        Light.intensity = current;
    }
}
