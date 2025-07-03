using UnityEngine;

public class UI_Controller : NewMonobehavior
{
    [SerializeField] protected UI_ResultGame uI_ResultGame;
    public UI_ResultGame _uI_ResultGame => uI_ResultGame;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIResultGame();
    }

    private void LoadUIResultGame()
    {
        if (this.uI_ResultGame != null) return;
        this.uI_ResultGame = gameObject.GetComponentInChildren<UI_ResultGame>();
    }
}