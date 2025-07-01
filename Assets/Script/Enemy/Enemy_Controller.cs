using UnityEngine;

public class Enemy_Controller : NewMonobehavior
{
    [SerializeField] protected Enemy_Attack enemy_Attack;
    public Enemy_Attack _enemy_Attack => _enemy_Attack;
    [SerializeField] protected Enemy_Hurt enemy_Hurt;
    public Enemy_Hurt _enemy_Hurt => _enemy_Hurt;
    [SerializeField] protected PlayerControllerr playerControllerr;
    public PlayerControllerr _playerControllerr => playerControllerr;
    [SerializeField] protected Animator animator;
    public Animator _animator => animator;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyAtk();
        this.LoadEnemyHurt();
        this.LoadPlayerController();
        this.LoadAnimator();
    }

    private void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = gameObject.GetComponentInChildren<Animator>();
    }
    private void LoadEnemyAtk()
    {
        if (this.enemy_Attack != null) return;
        this.enemy_Attack = this.gameObject.GetComponentInChildren<Enemy_Attack>();
    }
    private void LoadEnemyHurt()
    {
        if (this.enemy_Hurt != null) return;
        this.enemy_Hurt = this.gameObject.GetComponentInChildren<Enemy_Hurt>();
    }
    private void LoadPlayerController()
    {
        if (this.playerControllerr != null) return;
        this.playerControllerr = FindAnyObjectByType<PlayerControllerr>();
    }
}