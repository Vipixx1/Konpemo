using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject arenaMenu;
    [SerializeField] private GameObject characterMenu;
    [SerializeField] private GameObject optionsMenu;

    [SerializeField] private KonpemoCounting counter;


    private string levelToLoad;

    //Load the level you want : Level1, Level2, Level3, Level4 or Level5 
    public void LoadLevel()
    {
        if (KonpemoCounting.konpemosBlue.Count == 5) SceneManager.LoadScene(levelToLoad);
    }

    //Set the name of level you want to load, if no name has been set, make levelToLoad null
    public void SetLevelToLoad(string levelName)
    {
        if (levelName == "") levelToLoad = null;
        else levelToLoad = levelName;
        Debug.Log(levelToLoad);
    }

    public void QuitGame()
    {
        Debug.Log("Successfully quit");
        levelToLoad = null;
        Application.Quit();
    }

    public void ArenaToKonpemoScene()
    {
        if (levelToLoad != null)
        {
            arenaMenu.SetActive(false);
            characterMenu.SetActive(true);
        }
    }

}
