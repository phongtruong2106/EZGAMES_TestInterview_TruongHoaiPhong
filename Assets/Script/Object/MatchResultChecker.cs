using UnityEngine;

public class MatchResultChecker : NewMonobehavior
{
    [SerializeField] private GameMode currentMode = GameMode.OneVsOne;
    [SerializeField] private PlayerControllerr PC;
    [SerializeField] private Enemy_Controller EC;

    private bool gameEnded = false;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPC();
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
            EC._anim.SetBool("victory", true);
        }
        else if (EC._enemy_TakeDamage.isDie)
        {
            gameEnded = true;
            PC._anim.SetBool("Victory", true);
        }
    }
}