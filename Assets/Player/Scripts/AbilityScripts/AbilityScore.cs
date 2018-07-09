using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Abilities
{
    #region Delegates
    //Delegates-----------------------------------------------------------------Each delegate runs its assigned functions on their respective monitored variables change
    public delegate void HealthMonitor();
    public System.Action healthMonitor;

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
    #endregion

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
    private int _str;
    [SerializeField]
    private int _dex;
    [SerializeField]
    private int _con;
    [SerializeField]
    private int _int;
    [SerializeField]
    private int _wis;
    [SerializeField]
    private int _cha;

    public int Str
    {
        get
        {
            return _str;
        }

        set
        {
            if (value > 20)
            {
                _str = 20;
            }
            else
            {
                _str = value;
            }


            if (strMonitor != null)
            {
                strMonitor();
            }


        }
    }


    public int Dex
    {
        get
        {
            return _dex;
        }

        set
        {

            if (value > 20)
            {
                _dex = 20;
            }
            else
            {
                _dex = value;
            }

            if (dexMonitor != null)
            {
                dexMonitor();
            }

        }
    }


    public int Con
    {
        get
        {
            return _con;
        }

        set
        {
            if (value > 20)
            {
                _dex = 20;
            }
            else
            {
                _dex = value;
            }
            if (conMonitor != null)
            {
                conMonitor();
            }

        }
    }


    public int Int
    {
        get
        {
            return _int;
        }

        set
        {
            if (value > 20)
            {
                _int = 20;
            }
            else
            {
                _int = value;
            }
            if (intMonitor != null)
            {
                intMonitor();
            }

        }
    }


    public int Wis
    {
        get
        {
            return _wis;
        }

        set
        {
            if (value > 20)
            {
                _wis = 20;
            }
            else
            {
                _wis = value;
            }
            if (wisMonitor != null)
            {
                wisMonitor();
            }

        }
    }


    public int Cha
    {
        get
        {
            return _cha;
        }

        set
        {
            if (value > 20)
            {
                _cha = 20;
            }
            else
            {
                _cha = value;
            }
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
    [SerializeField]
    [Tooltip("Sets the floor value for how many points a state can gain on a character levelup")]
    private float _statBoostFloor;
    [SerializeField]
    [Tooltip("Sets the floor value for how many points a state can gain on a character levelup")]
    private float _statBoostCeiling;
    [SerializeField]
    [Tooltip("Responsible for setting when the layer levels up in accordance to if 'abilities.Experience / LevelUpThreshold > Level'")]
    private int levelUpThreshold = 100;


    public delegate void TouchAbility();
    public TouchAbility levelMonitor;
    private float _level = 1;

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
            SetStatusScores(abilities);
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
        abilities.healthMonitor += DeathPenalty;
        abilities.expMonitor += LevelUp;
    }

    void DeathPenalty()
    {
        if (abilities.Health <= 0)
        {
            abilities.Experience = 0;
        }
    }
    
    void LevelUp()
    {
        if (abilities.Experience / levelUpThreshold > Level)
        {
                
                abilities.Cha += (int)UnityEngine.Random.Range(_statBoostFloor, _statBoostCeiling);

                abilities.Con += (int)UnityEngine.Random.Range(_statBoostFloor, _statBoostCeiling);

                abilities.Dex += (int)UnityEngine.Random.Range(_statBoostFloor, _statBoostCeiling);

                abilities.Int += (int)UnityEngine.Random.Range(_statBoostFloor, _statBoostCeiling);

                abilities.Str += (int)UnityEngine.Random.Range(_statBoostFloor, _statBoostCeiling);

                abilities.Wis += (int)UnityEngine.Random.Range(_statBoostFloor, _statBoostCeiling);

        }
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
        if (abilities.Cha <= 0)
        {
            abilities.Cha = 10;
        }
        if (abilities.Con <= 0)
        {
            abilities.Con = 10;
        }
        if (abilities.Dex <= 0)
        {
            abilities.Dex = 10;
        }
        if (abilities.Int <= 0)
        {
            abilities.Int = 10;
        }
        if (abilities.Str <= 0)
        {
            abilities.Str = 10;
        }
        if (abilities.Wis <= 0)
        {
            abilities.Wis = 10;
        }
    }

    public void SetDefaultValues(Abilities abilities, int cha, int con, int dex,int intelligence, int str, int wis)
    {
        abilities.Cha = cha;
        abilities.Con = con;
        abilities.Dex = dex;
        abilities.Int = intelligence;
        abilities.Str = str;
        abilities.Wis = wis;
    }
}
