using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    private AbilityScore _myAbilitiyScore;//the local entities stat numbers

    // Use this for initialization
    void Start()
    {
        if (GetComponent<AbilityScore>() == null)//checking to see if the object has it's Ability Scores
        {
            Debug.LogError("No AbilityScore on" + gameObject.tag);
        }
        else//sets up a direct reference to the objects ability scores
        {
            _myAbilitiyScore = GetComponent<AbilityScore>();
            _myAbilitiyScore.abilities.expMonitor += LevelAttained;//the health monitor delegate inside this objects ability score script will now run "GiveExperience" when it's health variable is updated
            _myAbilitiyScore.levelMonitor += EditAbilities;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LevelAttained()
    {
        _myAbilitiyScore.Level += 1;
    }

    public void EditAbilities()
    {

    }
}
