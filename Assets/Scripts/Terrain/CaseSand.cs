using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseSand : MonoBehaviour
{
    private float percentSpeedReduction = -0.5f;

    public void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Konpemo>(out var konpemo))
        {
            //Debug.Log("a : " + konpemo.speed.Value);
            if (konpemo.speed.StatModifiers.Count > 0)
            {
                bool isOnSand = false;
                foreach (StatModifier speedMod in konpemo.speed.StatModifiers)
                {
                    if (speedMod.Source.ToString() == "CaseSand") { isOnSand = true; }
                }

                if (! isOnSand)
                {
                    konpemo.speed.AddModifier(new StatModifier(percentSpeedReduction, StatModType.PercentMult, "CaseSand"));
                    //Debug.Log("b : " + konpemo.speed.Value);
                }

            }
            else
            {
                konpemo.speed.AddModifier(new StatModifier(percentSpeedReduction, StatModType.PercentMult, "CaseSand"));
                //Debug.Log("c : " + konpemo.speed.Value);
            }
            
        }
    }

    public void OnTriggerExit(Collider other)
    {
        Konpemo konpemo = other.GetComponent<Konpemo>();
        if (konpemo != null)
        {
            konpemo.speed.RemoveAllModifiersFromSource("CaseSand");
        }
    }
}
