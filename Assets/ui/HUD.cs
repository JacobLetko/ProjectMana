using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public float health;
    private float _Health;
    public float mana;
    private float _Mana;

    public Slider healthBar;
    public Slider manaBar;

    public GameObject player;

    private void Start()
    {
        health = player.GetComponent<AbilityScore>().abilities.Health;
        mana = player.GetComponent<AbilityScore>().abilities.Mana;
        _Health = health;
        _Mana = mana;
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
