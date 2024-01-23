using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Vector3 offset;

    public void Start()
    {
        cam = Camera.main;
        this.transform.position += offset;

    }
    void LateUpdate()
    {
        transform.rotation = cam.transform.rotation;
        
    }
}
