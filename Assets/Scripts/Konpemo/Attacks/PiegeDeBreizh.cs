using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiegeDeBreizh : MonoBehaviour
{
    private float flatDamage = 150;
    private float trapRadius = 3;
    private float timeToBoom = 2;
    private float particleDuration = 0.3f;
    private Collider[] colliders;

    [SerializeField]
    ParticleSystem explosionParticle;
    [SerializeField]
    LayerMask enemyMask;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Konpemo>() && this.gameObject.layer != other.gameObject.layer)
        {
            Debug.Log("TicTac");
            StartCoroutine(DeclenchementPiegeCoroutine());
        }
    }
    public IEnumerator DeclenchementPiegeCoroutine()
    {
        yield return new WaitForSeconds(timeToBoom);
        Debug.Log("BOOM");
        colliders = Physics.OverlapSphere(transform.position, trapRadius);
        foreach (Collider collider in colliders) if (collider.GetComponent<Konpemo>() != null)
        {
            if (collider.gameObject.layer != transform.gameObject.layer)
            {
                explosionParticle.Play();
                collider.GetComponent<Konpemo>().TakingDamage(flatDamage);
                StartCoroutine(DisableCoroutine(this.gameObject));
            }
        }
    }
    public IEnumerator DisableCoroutine(GameObject gameObject)
    {
        yield return new WaitForSeconds(particleDuration); //le temps de voir l'explosion
        gameObject.SetActive(false);
    }
}
