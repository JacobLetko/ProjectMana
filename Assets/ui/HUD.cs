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

    public float MagicTimer;
    float _MagicTimer;
    public float SwordTimer;
    float _SwordTimer;

    [Header("lighting")]
    public float max;
    public float current;

    public Light Red;
    public Slider RedBar;
    public Light Green;
    public Slider GreenBar;
    public Light Blue;
    public Slider BlueBar;
    public Light White;
    public Slider WhiteBar;
    public Light Black;
    public Slider BlackBar;

    [Header("objects")]
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
        //MagicTimer = player.GetComponent<PlayerController>().rangedAttack;
        //SwordTimer = player.GetComponent<PlayerController>().meleeAttack;
    }

    private void Update()
    {
        healthBar.value = calcHealth();
        //manaBar.value = calcMana();
        calcBright(Red, RedBar);
        calcBright(Green, GreenBar);
        calcBright(Blue, BlueBar);
        calcBright(White, WhiteBar);
        calcBright(Black, BlackBar);
    }

    float calcHealth()
    {
        health = player.GetComponent<AbilityScore>().abilities.Health;
        return player.GetComponent<AbilityScore>().abilities.Health / player.GetComponent<AbilityScore>().abilities.HealthCap;
    }

    float calcMana()
    {
        mana = player.GetComponent<AbilityScore>().abilities.Mana;
        return player.GetComponent<AbilityScore>().abilities.Mana /_Mana;
    }
    
    void calcBright(Light light, Slider bar)
    {
        /*
         * need to get current bar value and make it current intensity value of light
         * bar.value * max = current ?
        */
        current = max * bar.value;
        light.intensity = current;
    }
}
