using UnityEngine;

public class Enemy_TakeDamage : NewMonobehavior, IDamageable
{
    [SerializeField] protected Enemy_Controller enemy_Controller;
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
        this.enemy_Controller._animator.SetBool("KnockOut", true);
    }
}