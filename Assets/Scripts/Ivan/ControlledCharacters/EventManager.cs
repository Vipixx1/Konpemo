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
    Konpemo cibleGameObject;
    KonpemoManager konpemoManagerSelected;
    Konpemo konpemoSelected;

    public UnityEvent<Vector3> goToEvent;
    public UnityEvent<Konpemo> goToAtkEvent;
    public UnityEvent<Konpemo> goToFlwAllyEvent;
    public UnityEvent rCapacityEvent;
    public UnityEvent<GameObject> eCapacityEvent;
    public UnityEvent<Vector3> zCapacityEvent;

    [SerializeField] private LayerMask masqueUnite;
    [SerializeField] private LayerMask masqueUniteEnnemi;
    [SerializeField] private LayerMask masqueUniteAllie;
    [SerializeField] private LayerMask masqueSol;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private SelectionManager selectionManager;
    private Vector3 positionSouris;

    void Start()
    {
        goToEvent = new UnityEvent<Vector3>();
        goToAtkEvent = new UnityEvent<Konpemo>();
        goToFlwAllyEvent = new UnityEvent<Konpemo>();
        rCapacityEvent = new UnityEvent();
        eCapacityEvent = new UnityEvent<GameObject>();
        zCapacityEvent = new UnityEvent<Vector3>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool unitHit = Physics.Raycast(ray, Mathf.Infinity, masqueUnite);
            if (!unitHit && Physics.Raycast(ray, out hit, Mathf.Infinity, masqueSol)) //move if not a unite hit
            {
                positionSouris = hit.point;
                goToEvent.Invoke(positionSouris);
            }
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, masqueUniteEnnemi)) //un ennemi est touché
            {
                cibleGameObject = hit.collider.gameObject.GetComponent<Konpemo>();
                //Debug.Log("J'envois un goToAtkEvent");
                goToAtkEvent.Invoke(cibleGameObject);
            }
            //Debug.Log("J'envois pas un goToFollowEvent");
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, masqueUniteAllie)) //un allié est touché
            {
                cibleGameObject = hit.collider.gameObject.GetComponent<Konpemo>();
                Debug.Log("J'envois un goToFollowEvent");
                goToFlwAllyEvent.Invoke(cibleGameObject);
            }
        }
        if(Input.GetKeyDown (KeyCode.E)) //capacite cible perso
        {
            //uiManager.DisplaySpriteBlue();
            //uiManager.Display(SpriteLastKonpemo);
            konpemoManagerSelected = selectionManager.GetLastKonpemoSelected();
            if(konpemoManagerSelected != null)
            {
                konpemoSelected = konpemoManagerSelected.GetComponent<Konpemo>();
                //Debug.Log(konpemoSelected.ToString());
                switch (konpemoSelected.capacityType)
                {
                    case 1:
                        rCapacityEvent.Invoke();
                        break;
                    case 2:
                        StartCoroutine(Capacity2Coroutine(uiManager, selectionManager));
                        break;
                    case 3:
                        StartCoroutine(Capacity3Coroutine(uiManager, selectionManager));
                        break;
                    default:
                        //Debug.Log("Impossible de lancer la capacité");
                        break;
                }
            }
        }
    }
    private IEnumerator Capacity2Coroutine(UIManager mUiManager, SelectionManager mSelectionManager)  //ATTENTION POUR DEBUGER IL FAUDRA PASSER LE KONPEMO DANS LE LOCK
    {
        mUiManager.DisplaySpriteRed();
        selectionManager.Lock(this.gameObject);
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && selectionManager.Lock(this.gameObject))
            {
                //Debug.Log("Dans la partie LOCK, vise un ennemi");
                rayE = mainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(rayE, out hit, Mathf.Infinity, masqueUniteEnnemi))
                {
                    //Debug.Log("Capacity 2 event sent");
                    eCapacityEvent.Invoke(hit.collider.gameObject);
                    mUiManager.HideSpriteRed();
                    mSelectionManager.Unlock(this.gameObject);
                    break;
                }
            }
            yield return null;
        }
        yield return null;
    }
    private IEnumerator Capacity3Coroutine(UIManager mUiManager, SelectionManager mSelectionManager)  //ATTENTION POUR DEBUGER IL FAUDRA PASSER LE KONPEMO DANS LE LOCK
    {
        mUiManager.DisplaySpriteBlue();
        selectionManager.Lock(this.gameObject);
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && selectionManager.Lock(this.gameObject))
            {
                //Debug.Log("Dans la partie LOCK");
                rayZ = mainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(rayZ, out hit, Mathf.Infinity, masqueSol))
                {
                    //Debug.Log("Capacity 3 event sent");
                    zCapacityEvent.Invoke(hit.collider.transform.position);
                    mUiManager.HideSpriteBlue();
                    mSelectionManager.Unlock(this.gameObject);
                    break;
                }
            }
            yield return null;
        }
        yield return null;
    }

    public void AddListener(KonpemoManager konpemoManager)
    {
        konpemoManager.AddMoveListener(this);
        konpemoManager.AddAtkMoveListener(this);
        konpemoManager.AddFlwAllyListener(this);
        konpemoManager.AddCapacityListener(this);
    }

    public void RemoveListener(KonpemoManager konpemoManager)
    {
        konpemoManager.RemoveMoveListener(this);
        konpemoManager.RemoveAtkMoveListener(this);
        konpemoManager.RemoveFlwAllyListener(this);
        konpemoManager.RemoveCapacityListener(this);
    }
}
