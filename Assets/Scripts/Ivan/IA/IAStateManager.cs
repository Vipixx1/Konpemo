using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAStateManager : MonoBehaviour
{
    [SerializeField]
    public float porteeVision;
    [SerializeField]
    public float porteeAtk;
    [SerializeField]
    public bool etat_cible;
    [SerializeField]
    public LayerMask masqueEnnemi; //c'est l'ennemi de l'IA
    [SerializeField]
    private KingManager kingManager;

    public NavMeshAgent agent;

    IABaseState currentState;
    public IAIdleState IAIdleState = new IAIdleState();
    public IAAttackingState IAAttackingState = new IAAttackingState();
    public IAMovingState IAMovingState = new IAMovingState();

    private GameObject king;
    public Konpemo cible;
    public Konpemo konpemo;

    void Start()
    {
        konpemo = GetComponent<Konpemo>();
        currentState = IAIdleState;
        currentState.EnterState(this);  
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(IABaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public GameObject CibleLaPlusProche(float porteAtk, LayerMask masqueUniteRecherche) //Renvois le GO le plus proche a attaquer
    {
        Collider[] unitsColliders = Physics.OverlapSphere(this.gameObject.transform.position, porteAtk, masqueUniteRecherche);
        if (unitsColliders.Length > 0)
        {
            GameObject minDistGO = unitsColliders[0].gameObject;
            Vector3 distCible = minDistGO.transform.position - this.gameObject.transform.position;
            foreach (Collider unitCollider in unitsColliders)
            {
                //trouver le plus près a partir des transforms
                Vector3 newDistCible = unitCollider.transform.position - this.gameObject.transform.position;
                if (newDistCible.magnitude <= distCible.magnitude)
                {
                    minDistGO = unitCollider.gameObject;
                    distCible = minDistGO.transform.position - this.gameObject.transform.position;
                }
            }
            return minDistGO;
        }
        else
        {
            return null;
        }
    }

    public GameObject CheckKing(float portee)
    {
        //code optimisé au début je faisais un overlapSphere
        king = kingManager.getKing();
        if (king != null)
        {
            if((king.transform.position - this.gameObject.transform.position).magnitude <= portee)
            {
                return king;
            }
            return null;
        }
        else
        { 
            return null;
        }
    }


}
