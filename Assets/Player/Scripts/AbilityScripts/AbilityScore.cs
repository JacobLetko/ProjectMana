using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Abilities
{
    //Delegates-----------------------------------------------------------------Each delegate runs its assigned functions on their respective monitored variables change
    public delegate void HealthMonitor();
    public HealthMonitor healthMonitor;

    public delegate void HealthCapMonitor();
    public HealthCapMonitor healthCapMonitor;

    public delegate void ExpMonitor();
    public ExpMonitor expMonitor;

    public delegate void StrMonitor();
    public StrMonitor strMonitor;

    public delegate void DexMonitor();
    public DexMonitor dexMonitor;

    public delegate void ConMonitor();
    public ConMonitor conMonitor;

    public delegate void IntMonitor();
    public IntMonitor intMonitor;

    public delegate void WisMonitor();
    public WisMonitor wisMonitor;

    public delegate void ChaMonitor();
    public ConMonitor chaMonitor;


    //What shows up on the UI---------------------------------------------------




    private float _magicDamage;
    private float _physicalDamage;
    private float _armorClass;
    [SerializeField]
    private float _health;
    private float _healthCap;
    private float _mana;
    private float _manaCap;
    private float _manaRegeneration;
    [SerializeField]
    private float _experience;
    private float _experienceGainModifier;

    public float MagicDamage
    {
        get
        {
            return _magicDamage;
        }

        set
        {
            _magicDamage = value;
        }
    }

    public float PhysicalDamage
    {
        get
        {
            return _physicalDamage;
        }

        set
        {
            _physicalDamage = value;
        }
    }

    public float ArmorClass
    {
        get
        {
            return _armorClass;
        }

        set
        {
            _armorClass = value;
        }
    }


    public float Health
    {
        get
        {
            return _health;
        }

        set
        {
            _health = value;
            if (healthMonitor != null)
            {
                Debug.Log("AAAAAAAAAA");
                healthMonitor();
            }

        }
    }


    public float HealthCap
    {
        get
        {
            return _healthCap;
        }

        set
        {
            _healthCap = value;
            if (healthCapMonitor != null)
            {

            }
        }
    }

    public float ManaCap
    {
        get
        {
            return _manaCap;
        }

        set
        {
            _manaCap = value;
        }
    }

    public float ManaRegeneration
    {
        get
        {
            return _manaRegeneration;
        }

        set
        {
            _manaRegeneration = value;
        }
    }

    public float Experience
    {
        get
        {
            return _experience;
        }

        set
        {
            _experience = value;
            if (expMonitor != null)
            {
                expMonitor();
            }

        }
    }

    public float Mana
    {
        get
        {
            return _mana;
        }

        set
        {
            _mana = value;
        }
    }


    //Ability scores-----------------------------------------------------

    [SerializeField]
    private float _str;
    [SerializeField]
    private float _dex;
    [SerializeField]
    private float _con;
    [SerializeField]
    private float _int;
    [SerializeField]
    private float _wis;
    [SerializeField]
    private float _cha;

    public float Str
    {
        get
        {
            return _str;
        }

        set
        {
            _str = value;
            if (strMonitor != null)
            {
                strMonitor();
            }


        }
    }


    public float Dex
    {
        get
        {
            return _dex;
        }

        set
        {
            _dex = value;
            if (dexMonitor != null)
            {
                dexMonitor();
            }

        }
    }


    public float Con
    {
        get
        {
            return _con;
        }

        set
        {
            _con = value;
            if (conMonitor != null)
            {
                conMonitor();
            }

        }
    }


    public float Int
    {
        get
        {
            return _int;
        }

        set
        {
            _int = value;
            if (intMonitor != null)
            {
                intMonitor();
            }

        }
    }


    public float Wis
    {
        get
        {
            return _wis;
        }

        set
        {
            _wis = value;
            if (wisMonitor != null)
            {
                wisMonitor();
            }

        }
    }


    public float Cha
    {
        get
        {
            return _cha;
        }

        set
        {
            _cha = value;
            if (chaMonitor != null)
            {
                chaMonitor();
            }

        }
    }








    //What does not show up on the UI-------------------------------------------
    private float _speed;
    private float _EvasionCool;
    private float _attackSpeed;
    private float _attackAccuracy;
    private float _jumpHeightMod;
    private float _healthAbsorbtion;

    public float Speed
    {
        get
        {
            return _speed;
        }

        set
        {
            _speed = value;
        }
    }

    public float EvasionCool
    {
        get
        {
            return _EvasionCool;
        }

        set
        {
            _EvasionCool = value;
        }
    }

    public float AttackSpeed
    {
        get
        {
            return _attackSpeed;
        }

        set
        {
            _attackSpeed = value;
        }
    }

    public float AttackAccuracy
    {
        get
        {
            return _attackAccuracy;
        }

        set
        {
            _attackAccuracy = value;
        }
    }

    public float JumpHeightMod
    {
        get
        {
            return _jumpHeightMod;
        }

        set
        {
            _jumpHeightMod = value;
        }
    }

    public float HealthAbsorbtion
    {
        get
        {
            return _healthAbsorbtion;
        }

        set
        {
            _healthAbsorbtion = value;
        }
    }



    public float ExperienceGainModifier
    {
        get
        {
            return _experienceGainModifier;
        }

        set
        {
            _experienceGainModifier = value;
        }
    }

}


public class AbilityScore : MonoBehaviour
{
    [Tooltip("Determines all underlying stats for the player. Functions almost exactly like D&D ability scores.")]
    public Abilities abilities = new Abilities();




    public delegate void TouchAbility();
    public TouchAbility levelMonitor;
    private float _level;

    public float Level
    {
        get
        {
            return _level;
        }

        set
        {
            _level = value;
            levelMonitor();
        }
    }


    /*
        Score Modifier
    Ability Scores and Modifiers
    1	−5
    2–3	−4
    4–5	−3
    6–7	−2
    8–9	−1
    10–11	+0
    12–13	+1
    14–15	+2
    16–17	+3
    18–19	+4
    20–21	+5
    22–23	+6
    24–25	+7
    26–27	+8
    28–29	+9
    30	+10
    */
    // Use this for initialization
    void Awake()
    {
        SetDefaultValues(abilities);
        abilities = SetStatusScores(abilities);
    }


    public float GetMod(float val)
    {
        return Mathf.Floor((val - 10) / 2);
    }

    public Abilities SetStatusScores(Abilities abilities)
    {
        abilities.ArmorClass = 11 + GetMod(abilities.Dex);
        abilities.Health = 8 + GetMod(abilities.Con);
        abilities.PhysicalDamage = 6 + GetMod(abilities.Str);
        abilities.MagicDamage = 2 + GetMod(abilities.Cha);//psuedo-magic massile damage
        return abilities;
    }

    public void SetDefaultValues(Abilities abilities)
    {
        abilities.Cha = 10;
        abilities.Con = 10;
        abilities.Dex = 10;
        abilities.Int = 10;
        abilities.Str = 10;
        abilities.Wis = 10;
    }
}
