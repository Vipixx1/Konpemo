using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Image redCursor;
    [SerializeField]
    Image blueCursor;

    private void Start()
    {
        redCursor.enabled = false;
        blueCursor.enabled = false;
    }
    public void DisplaySpriteRed()
    {
        redCursor.enabled = true;
    }
    public void HideSpriteRed()
    {
        redCursor.enabled = false;
    }
    public void DisplaySpriteBlue()
    {
        blueCursor.enabled = true;
    }
    public void HideSpriteBlue()
    {
        blueCursor.enabled = false;
    }


}
