using UnityEngine;

public class Enemy_Hurt : NewMonobehavior
{
    [SerializeField] protected Enemy_Controller enemy_Controller;
    private AttackType lastHitType = AttackType.None;
    private float hurtResetTime = 0.5f;
    private float timer = 0f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyController();
    }

    private void LoadEnemyController()
    {
        if (this.enemy_Controller != null) return;
        this.enemy_Controller = this.GetComponentInParent<Enemy_Controller>();
    }

    public void SetLastHitType(AttackType type)
    {
        this.lastHitType = type;
        this.timer = hurtResetTime;
        UpdateAnimation(type);
    }
    public void SetTakeDamage(int takeDame)
    {
        this.enemy_Controller._enemy_TakeDamage.TakeDamage(takeDame);
    }
    private void UpdateAnimation(AttackType type)
    {
        ResetAllBools();

        switch (type)
        {
            case AttackType.Head:
                enemy_Controller._animator.SetBool("HeahHit", true);
                break;
            case AttackType.Stomach:
                enemy_Controller._animator.SetBool("StomachHit", true);
                break;
            case AttackType.KidneyL:
                enemy_Controller._animator.SetBool("KidneyHit", true);
                break;
        }
    }

    private void ResetAllBools()
    {
        enemy_Controller._animator.SetBool("HeahHit", false);
        enemy_Controller._animator.SetBool("StomachHit", false);
        enemy_Controller._animator.SetBool("KidneyHit", false);
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

    
