using UnityEngine;

public class PlayerHurt : NewMonobehavior
{
    [SerializeField] protected PlayerControllerr playerControllerr;
    private AttackType lastHitType = AttackType.None;
    private float hurtResetTime = 0.5f;
    private float timer = 0f;

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

    public void SetLastHitType(AttackType type)
    {
        this.lastHitType = type;
        this.timer = hurtResetTime;
        UpdateAnimation(type);
    }
    public void SetTakeDamage(int takeDame)
    {
         this.playerControllerr._player_TakeDamage.TakeDamage(takeDame);
    }
    private void UpdateAnimation(AttackType type)
    {
        ResetAllBools();

        switch (type)
        {
            case AttackType.Head:
                playerControllerr._anim.SetBool("hit2", true);
                break;
            case AttackType.Stomach:
                playerControllerr._anim.SetBool("hit3", true);
                break;
            case AttackType.KidneyL:
                playerControllerr._anim.SetBool("hit1", true);
                break;
        }
    }

    private void ResetAllBools()
    {
        playerControllerr._anim.SetBool("hit1", false);
        playerControllerr._anim.SetBool("hit2", false);
        playerControllerr._anim.SetBool("hit3", false);
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                ResetAllBools();
                lastHitType = AttackType.None;
            }
        }
    }
}