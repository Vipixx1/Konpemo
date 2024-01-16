using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseSand : MonoBehaviour
{
    private float percentSpeedReduction = -0.25f;
    private void OnTriggerEnter(Collider other)
    {
        Konpemo konpemo = other.GetComponent<Konpemo>();  
        if (konpemo != null)
        {
            konpemo.speed.AddModifier(new StatModifier(percentSpeedReduction, StatModType.PercentAdd, this));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Konpemo konpemo = other.GetComponent<Konpemo>();
        if (konpemo != null)
        {
            konpemo.speed.RemoveAllModifiersFromSource(this);
        }
    }
}
