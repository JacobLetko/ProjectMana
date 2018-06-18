using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceGain : MonoBehaviour
{
    [SerializeField]
    private GameObject _reciever;//what recieves the experience points
    private AbilityScore _myAbilitiyScore;//the local entities stat numbers
    private bool _isDead = false;
    public int experienceReward = 100;
    private void Start()
    {
        _isDead = false;
        if (GetComponent<AbilityScore>() == null)//checking to see if the object has it's Ability Scores
        {
            Debug.LogError("No AbilityScore on" + gameObject.tag);
        }
        else//sets up a direct reference to the objects ability scores
        {
            _myAbilitiyScore = GetComponent<AbilityScore>();
            _myAbilitiyScore.abilities.healthMonitor += GiveExperience;//the health monitor delegate inside this objects ability score script will now run "GiveExperience" when it's health variable is updated
        }

        _reciever = FindObjectOfType<PlayerController>().gameObject;
        if (_reciever == null)//if their is no reciever even after searcging the entire hierarchy then this returns an error explaining that
        {
            Debug.LogError("No reciever for experience points detected, check tags and objects");
        }
    }

    void GiveExperience()//if the objects health hits zero then the experience reward is given to the reciever
    {
        _isDead = true;
        if (_myAbilitiyScore.abilities.Health <= 0)
        {
            if (_isDead)
            {
                _reciever.GetComponent<AbilityScore>().abilities.Experience += experienceReward;

                Destroy(gameObject);
            }


        }
    }

}
