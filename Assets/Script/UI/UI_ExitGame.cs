using UnityEngine;

public class UI_ExitGame : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("Thoát game...");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}