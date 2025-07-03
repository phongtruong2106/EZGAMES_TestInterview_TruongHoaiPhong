using UnityEngine;

public class Enemy_TakeDamage : NewMonobehavior, IDamageable
{
    [SerializeField] protected Enemy_Controller enemy_Controller;
    public bool isDie;

    protected override void Start()
    {
        this.isDie = false;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyHP();
    }

    private void LoadEnemyHP()
    {
        if (this.enemy_Controller != null) return;
        this.enemy_Controller = gameObject.GetComponentInParent<Enemy_Controller>();
    }
    public void TakeDamage(int amount)
    {
        this.enemy_Controller._enemyHealth.health -= amount;
        if (this.enemy_Controller._enemyHealth.health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        this.isDie = true;
        this.enemy_Controller._anim.SetBool("KnockOut", true);
        enemy_Controller._agent.isStopped = true;
    }
}