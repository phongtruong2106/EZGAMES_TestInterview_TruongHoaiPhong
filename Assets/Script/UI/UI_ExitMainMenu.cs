using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_ExitMainMenu : MonoBehaviour
{
    [SerializeField] private string mainMenuSceneName = "MainMenu";
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

}