using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulDrainObjManager : MonoBehaviour
{

    [SerializeField]
    private EnemyController _controller;
    [SerializeField]
    private GameObject _particleSystem;
    [SerializeField]
    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }
    // Use this for initialization
    void Start()
    {
        _particleSystem.SetActive(false);
        if (_controller == null)
        {
            if (GetComponent<EnemyController>() != null)
            {
                _controller = GetComponent<EnemyController>();
            }
            else
            {
                Debug.LogError("No 'EnemyController' component detected on object: " + gameObject.name);
            }
        }

        if (_particleSystem == null)
        {
            Debug.LogError("No ParticleSystem GameObject component was given to component 'SoulDrainManager' of gameobject: " + gameObject.name);
        }
        gaveHealth = false;
    }


    bool gaveHealth = false;
    public void DrainEffect()
    {
        if (_controller.stateStack.Peek() == EnemyController.States.DEATH)
        {
            if (Vector3.Distance(_playerController.transform.position, transform.position) < 10)
            {
                //if (Input.GetKeyDown(KeyCode.Q))
                //{
                if (gaveHealth == false)
                {

                    _particleSystem.SetActive(true);
                    if ((_playerController.abilityScores.abilities.Health + (int)_playerController.abilityScores.GetMod(_playerController.abilityScores.abilities.Con) + 1) <= _playerController.abilityScores.abilities.HealthCap)
                    {
                        _playerController.abilityScores.abilities.Health += (int)_playerController.abilityScores.GetMod(_playerController.abilityScores.abilities.Con) + 1;
                    }
                    Debug.Log("Drain Effect working");
                    gaveHealth = true;
                }
                //}
            }
        }
    }
}
