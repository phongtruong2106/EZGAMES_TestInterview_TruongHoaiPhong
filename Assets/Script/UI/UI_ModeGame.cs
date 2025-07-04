using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_ModeGame : MonoBehaviour
{
    [SerializeField] private string scene1 = "Scenes1";
    [SerializeField] private string scene2 = "Scenes2";
    [SerializeField] private string scene3 = "Scenes3";

    public void PlayMode1()
    {
        SceneManager.LoadScene(scene1);
    }
    public void PlayMode2()
    {
        SceneManager.LoadScene(scene2);
    }
    public void PlayMode3()
    {
        SceneManager.LoadScene(scene3);
    }
}