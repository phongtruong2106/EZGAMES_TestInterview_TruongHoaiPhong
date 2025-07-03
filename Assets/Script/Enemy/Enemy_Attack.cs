using UnityEngine;

public class Enemy_Attack : NewMonobehavior
{
    [SerializeField] protected Enemy_Controller enemy_Controller;
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private float attackRange = 1.8f;
    private float attackTimer;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemyController();
    }

    private void LoadEnemyController()
    {
        if (this.enemy_Controller != null) return;
        this.enemy_Controller = gameObject.GetComponentInParent<Enemy_Controller>();
    }

    protected override void Start()
    {
        base.Start();
        attackTimer = attackCooldown;
    }

    private void Update()
    {
        attackTimer -= Time.deltaTime;

        float distanceToPlayer = Vector3.Distance(
            enemy_Controller.transform.position,
            enemy_Controller._playerControllerr.transform.position
        );

        if (distanceToPlayer <= attackRange && attackTimer <= 0f)
        {
            DoAttack();
            attackTimer = attackCooldown;
        }
        else if (attackTimer > 0f)
        {
            ResetAttackAnim();
        }
    }

    private void DoAttack()
    {
        int attackType = Random.Range(1, 4);
        ResetAttackAnim();

        enemy_Controller.isAttacking = true;

        switch (attackType)
        {
            case 1:
                enemy_Controller._anim.SetBool("atk1", true);
                enemy_Controller._enemyLoadBoxHit._enemy_LoadHitBoxL.SetAttackType(AttackType.KidneyL);
                enemy_Controller._enemyLoadBoxHit._enemy_LoadHitBoxR.SetAttackType(AttackType.KidneyL);
                break;
            case 2:
                enemy_Controller._anim.SetBool("atk2", true);
                enemy_Controller._enemyLoadBoxHit._enemy_LoadHitBoxL.SetAttackType(AttackType.Head);
                enemy_Controller._enemyLoadBoxHit._enemy_LoadHitBoxR.SetAttackType(AttackType.Head);
                break;
            case 3:
                enemy_Controller._anim.SetBool("atk3", true);
                enemy_Controller._enemyLoadBoxHit._enemy_LoadHitBoxL.SetAttackType(AttackType.Stomach);
                enemy_Controller._enemyLoadBoxHit._enemy_LoadHitBoxR.SetAttackType(AttackType.Stomach);
                break;
        }
        enemy_Controller.Invoke("ResetAttackState", 1f); 
        
    }

    private void ResetAttackAnim()
    {
        enemy_Controller._anim.SetBool("atk1", false);
        enemy_Controller._anim.SetBool("atk2", false);
        enemy_Controller._anim.SetBool("atk3", false);
        enemy_Controller.isAttacking = false;
    }

}
