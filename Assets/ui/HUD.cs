using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public float health;
    private float _Health;
    public float mana;
    private float _mana;

    public Slider healthBar;
    public Slider manaBar;

    private List<GameObject> stats;

    public GameObject healthText, manaText, StrText, DexText, ConText, IntText, WisText, ChaText, ExpText, LevelText;

    public GameObject player;

    private void Start()
    {
        health = player.GetComponent<AbilityScore>().abilities.Health;
        mana = player.GetComponent<AbilityScore>().abilities.Mana;
        _Health = health;
        _mana = mana;

        //stats[0] = healthText;
        //stats[1] = manaText;
    }

    private void Update()
    {
        healthBar.value = calcHealth();
        //manaBar.value = calcMana();

    }

    float calcHealth()
    {
        _Health = player.GetComponent<AbilityScore>().abilities.Health;
        return player.GetComponent<AbilityScore>().abilities.Health / health;
    }

    float calcMana()
    {
        _mana = player.GetComponent<AbilityScore>().abilities.Mana;
        return player.GetComponent<AbilityScore>().abilities.Mana / mana;
    }
}
