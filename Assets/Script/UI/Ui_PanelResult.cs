using UnityEngine;

public class Ui_PanelResult : NewMonobehavior
{
    [SerializeField] protected UI_NextLevel uI_NextLevel;
    [SerializeField] protected UI_ExitMainMenu UI_ExitMainMenu;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUINextLevel();
        this.LoadExitMainMenu();
    }

    private void LoadUINextLevel()
    {
        if (this.uI_NextLevel != null) return;
        this.uI_NextLevel = gameObject.GetComponentInChildren<UI_NextLevel>();
    }
    private void LoadExitMainMenu()
    {
        if (this.UI_ExitMainMenu != null) return;
        this.UI_ExitMainMenu = gameObject.GetComponentInChildren<UI_ExitMainMenu>();
    }
}