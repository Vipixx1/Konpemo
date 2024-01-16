using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField]
    LayerMask masqueUnite;
    [SerializeField]
    LayerMask masqueUniteAllie;
    [SerializeField]
    EventManager eventManager;

    [SerializeField] private bool locker;
    [SerializeField] private GameObject mOwner;

    private bool allyUnitHit;
    private bool UnitHit;
    KonpemoManager konpemoManagerHit;
    List<KonpemoManager> selectedKonpemos;
    Camera mainCamera;


    void Start()
    {
        mainCamera = Camera.main;
        selectedKonpemos = new List<KonpemoManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && this.Lock(this.gameObject))
        {   
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            allyUnitHit = Physics.Raycast(ray, out hit, Mathf.Infinity, masqueUniteAllie);
            if (allyUnitHit)
            {
                if (!Input.GetKey(KeyCode.LeftShift)) UnSelectKonpemos();
                konpemoManagerHit = hit.collider.gameObject.GetComponent<KonpemoManager>();
                if (!CheckKonpemoSelected(konpemoManagerHit))//Konpemo not selected
                {
                    Debug.Log("unit� touch�, tentative d'ajout listeners");
                    SelectKonpemo(konpemoManagerHit);
                    Debug.Log(selectedKonpemos.Count);
                }
                else//Konpemo already selected
                {
                    Debug.Log("remove des listeners");
                    unSelectKonpemo(konpemoManagerHit);
                }
            }
            else if (!Physics.Raycast(ray, out hit, Mathf.Infinity, masqueUnite))  //on ne clique pas sur une unit�
            {
                UnSelectKonpemos();
                Debug.Log("tous les konpemos d�sel�ctionn�s");
                Debug.Log(selectedKonpemos.Count);
            }
            this.Unlock(this.gameObject);
        }
    }

    public bool Lock(GameObject owner)
    {
        if (locker)
        {
            if(owner.name == mOwner.name) return true;
            else return false;
        }
        else
        {
            locker = true;
            mOwner = owner;
            return true;
        }
    }

    public void Unlock(GameObject preOwner)
    {
        if(preOwner.name == mOwner.name)
        {
            locker = false;
            mOwner = null;
        }
    }

    private void SelectKonpemo(KonpemoManager konpemoManager)
    {
        eventManager.AddListener(konpemoManager);
        selectedKonpemos.Add(konpemoManager);
    }
    private void unSelectKonpemo(KonpemoManager konpemoManager)
    {
        eventManager.RemoveListener(konpemoManager);
        selectedKonpemos.Remove(konpemoManager);
    }
    private void UnSelectKonpemos()
    {
        foreach (KonpemoManager mKonpemoManager in selectedKonpemos)
        {
            eventManager.RemoveListener(mKonpemoManager);
        }
        selectedKonpemos.Clear();
    }
    private bool CheckKonpemoSelected(KonpemoManager konpemoManager)
    {
        return (selectedKonpemos.Contains(konpemoManager));
    }
    public KonpemoManager GetLastKonpemoSelected()
    {
        if (selectedKonpemos.Count > 0)
        {
            return selectedKonpemos[selectedKonpemos.Count - 1];
        }
        return null;
    }
    private List<KonpemoManager> GetKonpemoManagers()
    {
        return selectedKonpemos;
    }
}