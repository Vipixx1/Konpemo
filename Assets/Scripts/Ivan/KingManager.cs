using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public GameObject getKing()
    {
        return theKing;
    }
    public void endOfTheGameLose()
    {
        Debug.Log("Lose");
        //SceneManager.LoadSceneAsync("GameOverScreen");
    }

    public void endOfTheGameWin()
    {
        Debug.Log("Win");
        //SceneManager.LoadSceneAsync("VictoryScreen");
    }

    private void Update()
    {
        /*if !theKing.health.isAlive)
        {
            endOfTheGameLose();
        }*/
    }
    //besoin de mettre un trigger pour la condition de victoire
}