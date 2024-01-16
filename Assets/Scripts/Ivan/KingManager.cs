using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KingManager : MonoBehaviour
{
    [SerializeField]
    private Konpemo theKing;
    public void setKing(Konpemo gameObjectKing)
    {
        if (theKing == null)
        {
            theKing = gameObjectKing;

        }
    }

    public Konpemo getKing()
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