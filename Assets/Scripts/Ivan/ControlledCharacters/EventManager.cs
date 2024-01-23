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

    public UnityEvent capacityNoClickEvent;
    public UnityEvent<Vector3> capacityOnGroundEvent;
    public UnityEvent capacityOnUnitEvent;

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

        capacityNoClickEvent = new UnityEvent();
        capacityOnGroundEvent = new UnityEvent<Vector3>();
        //capacityOnUnitEvent = new UnityEvent();

        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool unitHit = Physics.Raycast(ray, Mathf.Infinity, masqueUnite);
            if (!unitHit && Physics.Raycast(ray, out hit, Mathf.Infinity, masqueSol))   // No unit has been clicked on
            {
                positionSouris = hit.point;
                goToEvent.Invoke(positionSouris);
            }
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, masqueUniteEnnemi))       // An enemy has been clicked on
            {
                cibleGameObject = hit.collider.gameObject.GetComponent<Konpemo>();
                //Debug.Log("J'envois un goToAtkEvent");
                goToAtkEvent.Invoke(cibleGameObject);
            }
            //Debug.Log("J'envois pas un goToFollowEvent");
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, masqueUniteAllie))        // An ally has been clicked on
            {
                cibleGameObject = hit.collider.gameObject.GetComponent<Konpemo>();
                //Debug.Log("J'envois un goToFollowEvent");
                goToFlwAllyEvent.Invoke(cibleGameObject);
            }
        }

        // Capacity Management :
        if (Input.GetKeyDown(KeyCode.E))
        {
            konpemoManagerSelected = selectionManager.GetLastKonpemoSelected();
            if (konpemoManagerSelected != null)
            {
                konpemoSelected = konpemoManagerSelected.GetComponentInParent<Konpemo>();
                //Debug.Log(konpemoSelected.ToString());
                switch (konpemoSelected.capacityType)
                {
                    case CapacityType.NoClick:
                        capacityNoClickEvent.Invoke();
                        break;

                    case CapacityType.ClickOnGround:
                        StartCoroutine(CapacityOnGroundCoroutine(uiManager, selectionManager, konpemoSelected));
                        break;

                    /*case CapacityType.ClickOnAlly:
                        StartCoroutine(CapacityOnAllyCoroutine(uiManager, selectionManager, konpemoSelected));
                        break;

                    case CapacityType.ClickOnEnemy:
                        StartCoroutine(CapacityOnEnemyCoroutine(uiManager, selectionManager, konpemoSelected));
                        break;*/

                    default:
                        Debug.Log("Impossible de lancer la capacite");
                        break;
                }
            }
        }
    }

    private IEnumerator CapacityOnGroundCoroutine(UIManager mUiManager, SelectionManager mSelectionManager, Konpemo konpemoExecutingCap)
    {
        mUiManager.DisplaySpriteBlue();
        konpemoExecutingCap.capacityArea.SetActive(true);
        selectionManager.Lock(this.gameObject);
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && selectionManager.Lock(this.gameObject))
            {
                //Debug.Log("Dans la partie LOCK");
                rayZ = mainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(rayZ, out hit, Mathf.Infinity, masqueSol))
                {
                    if ((hit.point - konpemoExecutingCap.transform.position).magnitude <= konpemoExecutingCap.rangeCapacity.Value)
                    {
                        //Debug.Log("Capacity OnGround event sent");
                        capacityOnGroundEvent.Invoke(hit.point);
                        mUiManager.HideSpriteBlue();
                        konpemoExecutingCap.capacityArea.SetActive(false);
                        mSelectionManager.Unlock(this.gameObject);
                        break;
                    }
                }
            }
            yield return null;
        }
        yield return null;
    }


 /*   private IEnumerator CapacityOnAllyCoroutine(UIManager mUiManager, SelectionManager mSelectionManager, Konpemo konpemoExecutingCap)
    {
        mUiManager.DisplaySpriteRed();
        konpemoExecutingCap.capacityArea.SetActive(true);
        selectionManager.Lock(this.gameObject);
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && selectionManager.Lock(this.gameObject))
            {
                rayE = mainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(rayE, out hit, Mathf.Infinity, masqueUniteAllie))
                {
                    if ((hit.point - konpemoExecutingCap.transform.position).magnitude <= konpemoExecutingCap.rangeCapacity.Value)
                    {
                        capacityOnUnitEvent.Invoke();
                        mUiManager.HideSpriteRed();
                        konpemoExecutingCap.capacityArea.SetActive(false);
                        mSelectionManager.Unlock(this.gameObject);
                        break;
                    }
                }
            }
            yield return null;
        }
        yield return null;
    }

    private IEnumerator CapacityOnEnemyCoroutine(UIManager mUiManager, SelectionManager mSelectionManager, Konpemo konpemoExecutingCap)
    {
        mUiManager.DisplaySpriteRed();
        konpemoExecutingCap.capacityArea.SetActive(true);
        selectionManager.Lock(this.gameObject);
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && selectionManager.Lock(this.gameObject))
            {
                //Debug.Log("Dans la partie LOCK, vise un ennemi");
                rayE = mainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(rayE, out hit, Mathf.Infinity, masqueUniteEnnemi))
                {
                    if ((hit.point - konpemoExecutingCap.transform.position).magnitude <= konpemoExecutingCap.rangeCapacity.Value)
                    {
                        //Debug.Log("Capacity OnEnemy event sent");
                        capacityOnUnitEvent.Invoke();
                        mUiManager.HideSpriteRed();
                        konpemoExecutingCap.capacityArea.SetActive(false);
                        mSelectionManager.Unlock(this.gameObject);
                        break;
                    }
                }
            }
            yield return null;
        }
        yield return null;
    }*/


    public void AddListener(KonpemoManager konpemoManager)
    {
        konpemoManager.AddMoveListener(this);
        konpemoManager.AddAtkMoveListener(this);
        konpemoManager.AddFlwAllyListener(this);
    }

    public void RemoveListener(KonpemoManager konpemoManager)
    {
        konpemoManager.RemoveMoveListener(this);
        konpemoManager.RemoveAtkMoveListener(this);
        konpemoManager.RemoveFlwAllyListener(this);
    }

    // Les deux methodes qui suivent sont separees de celles au dessus afin de gerer les capacites Konpemo par Konpemo
    public void AddCapacityListener(KonpemoManager konpemoManager)
    {
        konpemoManager.AddCapacityListener(this);
    }
    public void RemoveCapacityListener(KonpemoManager konpemoManager)
    {
        konpemoManager.RemoveCapacityListener(this);
    }
}
