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
        if (Input.GetKeyDown(KeyCode.Mouse0))
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
                    Debug.Log("unité touché, tentative d'ajout listeners");
                    SelectKonpemo(konpemoManagerHit);
                    Debug.Log(selectedKonpemos.Count);
                }
                else//Konpemo already selected
                {
                    Debug.Log("remove des listeners");
                    unSelectKonpemo(konpemoManagerHit);
                }
            }
            else if (!Physics.Raycast(ray, out hit, Mathf.Infinity, masqueUnite))  //on ne clique pas sur une unité
            {
                UnSelectKonpemos();
                Debug.Log("tous les konpemos déseléctionnés");
                Debug.Log(selectedKonpemos.Count);
            }
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
    private List<KonpemoManager> GetKonpemoManagers()
    {
        return selectedKonpemos;
    }
}