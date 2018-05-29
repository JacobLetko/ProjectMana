using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceGain : MonoBehaviour
{
    private GameObject _player;
    private AbilityScore _myAbilitiyScore;

    public int experienceReward = 100;
    private void Awake()
    {
        if (GetComponent<AbilityScore>() == null)
        {
            Debug.LogError("No AbilityScore on" + gameObject.tag);
        }
        else
        {
            _myAbilitiyScore = GetComponent<AbilityScore>();
            _myAbilitiyScore.abilities.healthMonitor += GiveExperience;
        }

        _player = GameObject.FindGameObjectWithTag("Player");
        if (_player == null)
        {
            Debug.LogError("No Player detected, check tags and objects");
        }
    }

    void GiveExperience()
    {
        if (_myAbilitiyScore.abilities.Health <= 0)
        {
            _player.GetComponent<AbilityScore>().abilities.Experience += experienceReward;
            Destroy(gameObject);
        }
    }

}
