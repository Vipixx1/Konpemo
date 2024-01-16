using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseSand : MonoBehaviour
{
    private float percentSpeedReduction = -0.1f;
    private void OnTriggerEnter(Collider other)
    {
        Konpemo konpemo = other.GetComponent<Konpemo>();
        if (konpemo != null)
        {
            Debug.Log("aaa" + konpemo.speed.Value);
            if (konpemo.speed.StatModifiers.Count > 0)
            {
                bool isOnSand = false;
                foreach (StatModifier speedMod in konpemo.speed.StatModifiers)
                {
                    if (speedMod.Source == this) { isOnSand = true; }
                }

                if (! isOnSand)
                {
                    konpemo.speed.AddModifier(new StatModifier(percentSpeedReduction, StatModType.PercentAdd, this));
                    Debug.Log("bbb" + konpemo.speed.Value);
                }

            }
            else
            {
                konpemo.speed.AddModifier(new StatModifier(percentSpeedReduction, StatModType.PercentAdd, this));
                Debug.Log("ccc" + konpemo.speed.Value);
            }
            
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
