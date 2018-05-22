using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Abilities
{

    //What shows up on the UI---------------------------------------------------




    private float _magicDamage;
    private float _physicalDamage;
    private float _armorClass;
    private float _health;
    private float _manaCap;
    private float _manaRegeneration;


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
            OnStrUpdate();
        }
    }

    private void OnStrUpdate()
    {
        throw new NotImplementedException();
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
            OnDexUpdate();
        }
    }

    private void OnDexUpdate()
    {
        throw new NotImplementedException();
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
            OnConUpdate();
        }
    }

    private void OnConUpdate()
    {
        throw new NotImplementedException();
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
            OnIntUpdate();
        }
    }

    private void OnIntUpdate()
    {
        throw new NotImplementedException();
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
            OnWisUpdate();
        }
    }

    private void OnWisUpdate()
    {
        throw new NotImplementedException();
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
            OnChaUpdate();
        }
    }

    private void OnChaUpdate()
    {
        throw new NotImplementedException();
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
}


public class AbilityScore : MonoBehaviour
{
    [Tooltip("Determines all underlying stats for the player. Functions almost exactly like D&D ability scores.")]
    public Abilities abilities;


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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
