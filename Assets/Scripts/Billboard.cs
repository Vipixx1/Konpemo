using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private Camera cam;
    [SerializeField] private Vector3 offset;

    void LateUpdate()
    {
        transform.rotation = cam.transform.rotation;
        transform.position = target.position + offset;
    }
}
