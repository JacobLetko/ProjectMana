using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteThis : MonoBehaviour
{
    public AbilityScore abilities;
    // Use this for initialization
    void Start()
    {
        abilities.SetStatusScores(abilities.abilities);
    }

}
