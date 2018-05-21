using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class AbilityScore : MonoBehaviour
{
    //What shows up on the UI---------------------------------------------------
    private float _magicDamage;
    private float _physicalDamage;
    private float _armorClass;
    private float _health;

    private float _str;
    private float _dex;
    private float _con;
    private float _int;
    private float _wis;
    private float _cha;

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

    public float Str
    {
        get
        {
            return _str;
        }

        set
        {
            _str = value;
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

    //What does not show up on the UI-------------------------------------------


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
