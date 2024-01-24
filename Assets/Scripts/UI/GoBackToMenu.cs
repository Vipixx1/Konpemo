using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoBackToMenu : MonoBehaviour
{
    [SerializeField]
    private Button GoToMenuButton;
    [SerializeField]
    private Button GoBackToGameButton;
    [SerializeField]
    private string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        GoToMenuButton.onClick.AddListener(OnButtonClick);
        GoBackToGameButton.onClick.AddListener(OnButtonBackClick);
    }
    public void OnButtonClick()
    {
        Debug.Log("Bouton cliqué");
        SceneManager.LoadScene(sceneName);
    }
    public void OnButtonBackClick()
    {
        this.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        GoToMenuButton.onClick.RemoveListener(OnButtonClick);
        GoBackToGameButton.onClick.RemoveListener(OnButtonClick);
    }
}
