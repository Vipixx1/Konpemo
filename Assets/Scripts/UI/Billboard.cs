using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private Camera cam;


    public void Start()
    {
        cam = Camera.main;    
    }
    void LateUpdate()
    {
        transform.rotation = cam.transform.rotation;
    }
}
