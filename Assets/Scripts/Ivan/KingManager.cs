using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingManager : MonoBehaviour
{
    [SerializeField]
    private GameObject theKing;
    public void setKing(GameObject gameObjectKing)
    {
        if (theKing == null)
        {
            theKing = gameObjectKing;
        }
    }
    public void endOfTheGameWhen()
    {
        //if king died or king reached based
        //end of the game
    }

    private void Update()
    {
        if (theKing != null)
        {
            endOfTheGameWhen();
        }
    }
}