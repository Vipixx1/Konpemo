using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private Camera cam;
    [SerializeField] private Vector3 offset;

    public void Start()
    {
        cam = Camera.main;    
    }
    void LateUpdate()
    {
        Debug.Log(this.transform.rotation);
        transform.rotation = cam.transform.rotation;
        transform.position = target.position + offset;
    }
}
