using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SwordScript))]
[RequireComponent(typeof(SeekerSpawner))]
[RequireComponent(typeof(AbilityScore))]
public class PlayerController : MonoBehaviour
{
    public SeekerSpawner rangedAttack;
    public SwordScript meleeAttack;
    public AbilityScore abilityScores;

    

    public ObjectPool pool;


    float rangeAtkTimer = 0;
    float meleeAtkTimer = 0;
    public float RateOfFire;//Bullets per second
    // Use this for initialization
    void Awake()
    {
        abilityScores.abilities = abilityScores.SetStatusScores(abilityScores.abilities);
        rangeAtkTimer = 1 / RateOfFire;
        meleeAtkTimer = 1 / RateOfFire;
        meleeAttack.damage = abilityScores.abilities.PhysicalDamage;
        Debug.Log(abilityScores.abilities.PhysicalDamage);
    }

    void Update()
    {
        rangeAtkTimer += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if (rangeAtkTimer >= 1 / RateOfFire)
            {
                for (int i = 0; i < 3; i++)
                {
                    rangedAttack.FireGun(abilityScores.abilities.MagicDamage);
                    rangeAtkTimer = 0;
                    Debug.Log("ranged");
                }

            }
        }

        meleeAtkTimer += Time.deltaTime;
        if (Input.GetMouseButton(1))
        {
            if (meleeAtkTimer >= 1 / RateOfFire)
            {
                meleeAttack.damage = abilityScores.abilities.PhysicalDamage;
                meleeAttack.attack();
                rangeAtkTimer = 0;
                Debug.Log("Melee");
            }
        }


    }

}