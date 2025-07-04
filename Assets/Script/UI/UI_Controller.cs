using UnityEngine;

public class UI_Controller : NewMonobehavior
{
    [SerializeField] protected UI_ResultGame uI_ResultGame;
    public UI_ResultGame _uI_ResultGame => uI_ResultGame;
    [SerializeField] protected Ui_PanelResult ui_PanelResult;
    public Ui_PanelResult _ui_PanelResult => ui_PanelResult;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIResultGame();
        this.LoadUIPR();
    }
    private void LoadUIPR()
    {
        if (this.ui_PanelResult != null) return;
        this.ui_PanelResult = gameObject.GetComponentInChildren<Ui_PanelResult>();
    }
    private void LoadUIResultGame()
    {
        if (this.uI_ResultGame != null) return;
        this.uI_ResultGame = gameObject.GetComponentInChildren<UI_ResultGame>();
    }
}