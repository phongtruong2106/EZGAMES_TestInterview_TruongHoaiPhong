using UnityEngine;

public class MatchResultChecker : NewMonobehavior
{
    [SerializeField] private GameMode currentMode = GameMode.OneVsOne;
    [SerializeField] private PlayerControllerr PC;
    [SerializeField] private Enemy_Controller EC;
    [SerializeField] protected UI_Controller uI_Controller;



    private bool gameEnded = false;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPC();
        this.LoadUIC();
    }

    private void LoadUIC()
    {
        if (this.uI_Controller != null) return;
        this.uI_Controller = FindAnyObjectByType<UI_Controller>();
    }
    private void LoadPC()
    {
        if (this.PC != null) return;
        this.PC = FindAnyObjectByType<PlayerControllerr>();
    }
    private void Update()
    {
        if (gameEnded) return;

        switch (currentMode)
        {
            case GameMode.OneVsOne:
                Check1v1();
                break;
            case GameMode.OneVsMany:
                break;
            case GameMode.ManyVsMany:
                break;
        }
    }

    private void Check1v1()
    {
        if (PC._player_TakeDamage.isDie)
        {
            gameEnded = true;
            this.uI_Controller._uI_ResultGame._anim.SetBool("Defeat", true);
            EC._anim.SetBool("victory", true);

        }
        else if (EC._enemy_TakeDamage.isDie)
        {
            gameEnded = true;
            this.uI_Controller._uI_ResultGame._anim.SetBool("Victory", true);
            PC._anim.SetBool("Victory", true);
        }
    }
}