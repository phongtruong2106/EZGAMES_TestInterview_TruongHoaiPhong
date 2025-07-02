using UnityEngine;
using UnityEngine.AI;

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
    [SerializeField] protected EnemyHealth enemyHealth;
    public EnemyHealth _enemyHealth => enemyHealth;
    [SerializeField] protected Enemy_TakeDamage enemy_TakeDamage;
    public Enemy_TakeDamage _enemy_TakeDamage => enemy_TakeDamage;
    [SerializeField] protected NavMeshAgent agent;
    public NavMeshAgent _agent => agent;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyAtk();
        this.LoadEnemyHurt();
        this.LoadPlayerController();
        this.LoadAnimator();
        this.LoadEnemyHp();
        this.LoadEnemyTakeDamage();
        this.LoadNavMeshAgent();
    }
    private void LoadNavMeshAgent()
    {
        if (this.agent != null) return;
        this.agent = GetComponent<NavMeshAgent>();
    }
    private void LoadEnemyHp()
    {
        if (this.enemyHealth != null) return;
        this.enemyHealth = gameObject.GetComponentInChildren<EnemyHealth>();
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
    private void LoadEnemyTakeDamage()
    {
        if (this.enemy_TakeDamage != null) return;
        this.enemy_TakeDamage = this.gameObject.GetComponentInChildren<Enemy_TakeDamage>();
    }
}