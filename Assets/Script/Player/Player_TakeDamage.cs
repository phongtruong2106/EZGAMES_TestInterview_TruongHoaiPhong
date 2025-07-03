using UnityEngine;

public class Player_TakeDamage : NewMonobehavior, IDamageable
{
    [SerializeField] protected PlayerControllerr playerControllerr;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerController();
    }

    private void LoadPlayerController()
    {
        if (this.playerControllerr != null) return;
        this.playerControllerr = gameObject.GetComponentInParent<PlayerControllerr>();
    }

    public void TakeDamage(int amount)
    {
        this.playerControllerr._player_HP.health -= amount;
        if (this.playerControllerr._player_HP.health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        this.playerControllerr._anim.SetBool("KnockOut", true);
    }
}