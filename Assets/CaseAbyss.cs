using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseAbyss : MonoBehaviour
{
    private readonly float damage = 0.5f;
    public void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Konpemo>(out var konpemo))
        {
            Debug.Log("Aie");
            konpemo.health.TakingFlatDamage(damage, 0);
            if (konpemo.health.GetCurrentHealth() < 0) { konpemo.Death(); }
        }
    }
}
