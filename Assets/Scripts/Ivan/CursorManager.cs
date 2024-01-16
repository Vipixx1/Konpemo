using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField]
    private RectTransform rectTransform;

    private Vector3 mousePos;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        rectTransform.position = mousePos;
    }
}
