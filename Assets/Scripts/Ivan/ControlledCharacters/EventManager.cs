using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class EventManager : MonoBehaviour
{
    Camera mainCamera;
    RaycastHit hit;
    Ray ray;
    Ray rayE;
    Ray rayZ;
    GameObject cibleGameObject;

    public UnityEvent<Vector3> goToEvent;
    public UnityEvent<GameObject> goToAtkEvent;
    public UnityEvent rCapacityEvent;
    public UnityEvent<GameObject> eCapacityEvent;
    public UnityEvent<Vector3> zCapacityEvent;

    [SerializeField] private LayerMask masqueUnite;
    [SerializeField] private LayerMask masqueUniteEnnemi;
    [SerializeField] private UIManager uiManager;
    private Vector3 positionSouris;
    // Start is called before the first frame update
    void Start()
    {
        goToEvent = new UnityEvent<Vector3>();
        goToAtkEvent = new UnityEvent<GameObject>();
        rCapacityEvent = new UnityEvent();
        eCapacityEvent = new UnityEvent<GameObject>();
        zCapacityEvent = new UnityEvent<Vector3>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool unitHit = Physics.Raycast(ray, Mathf.Infinity, masqueUnite);
            if (!unitHit) //move if not a unite hit
            {
                Physics.Raycast(ray, out hit, Mathf.Infinity, ~masqueUnite); //signifie inverse du masque des unites
                positionSouris = hit.point;
                Debug.Log("Envois d'un goToEvent");
                goToEvent.Invoke(positionSouris);  //le false correspnd à ne pas chase
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, masqueUniteEnnemi)) //un ennemi est touché
            {
                cibleGameObject = hit.collider.gameObject;
                Debug.Log("J'envois un goToAtkEvent");
                goToAtkEvent.Invoke(cibleGameObject);
            }
        }
        if (Input.GetKeyDown (KeyCode.R)) //capacité spéciale
        {
            rCapacityEvent.Invoke();
        }
        if(Input.GetKeyDown (KeyCode.E)) //capacite cible perso
        {
            rayE = mainCamera.ScreenPointToRay(Input.mousePosition);
            //uiManager.
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, masqueUniteEnnemi))
            {
                eCapacityEvent.Invoke(hit.collider.gameObject);
            }

        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            rayZ = mainCamera.ScreenPointToRay(Input.mousePosition);
        }
    }

    public void AddListener(KonpemoManager konpemoManager)
    {
        konpemoManager.AddMoveListener(this);
        konpemoManager.AddAtkMoveListener(this);
    }

    public void RemoveListener(KonpemoManager konpemoManager)
    {
        konpemoManager.RemoveMoveListener(this);
        konpemoManager.RemoveAtkMoveListener(this);
    }
}
