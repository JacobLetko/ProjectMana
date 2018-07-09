using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulDrainObjBehaviour : MonoBehaviour
{
    private AbilityScore abilityScore;
    // Use this for initialization
    void Start()
    {
        abilityScore = GetComponent<AbilityScore>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Stun()
    {
        if (abilityScore.abilities.Health <= Mathf.Round(abilityScore.abilities.HealthCap / 3))
        {

        }
    }
}
