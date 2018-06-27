using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SwordScript))]
[RequireComponent(typeof(SeekerSpawner))]
[RequireComponent(typeof(AbilityScore))]
public class PlayerController : MonoBehaviour
{
    public Animator playerAnimator;
    [SerializeField]
    private PlayerMovement _playerMovement;
    public SeekerSpawner rangedAttack;
    public SwordScript meleeAttack;
    public AbilityScore abilityScores;
    [SerializeField]
    private bool _paused = false;
    

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
        _playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (!_paused)
        {
            if (!_playerMovement.isJumping)
            {
                if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
                {
                    _playerMovement.IsAttacking = true;
                }
                else
                {
                    _playerMovement.IsAttacking = false;
                }

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
    }

    public void PausePlayer(bool val)
    {
        _paused = val;
    }

}