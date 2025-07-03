using UnityEngine;

public class Player_TakeDamage : NewMonobehavior, IDamageable
{
    [SerializeField] protected PlayerControllerr playerControllerr;
    public bool isDie;
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
    protected override void Start()
    {
        this.isDie = false;
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
        this.isDie = true;
        this.playerControllerr._anim.SetBool("KnockOut", true);
    }
}