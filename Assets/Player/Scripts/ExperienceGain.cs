using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceGain : MonoBehaviour
{
    [SerializeField]
    private GameObject _reciever;
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

        _reciever = GameObject.FindGameObjectWithTag("Player");
        if (_reciever == null)
        {
            Debug.LogError("No reciever for experience points detected, check tags and objects");
        }
    }

    void GiveExperience()
    {
        if (_myAbilitiyScore.abilities.Health <= 0)
        {
            _reciever.GetComponent<AbilityScore>().abilities.Experience += experienceReward;
            Destroy(gameObject);
        }
    }

}
