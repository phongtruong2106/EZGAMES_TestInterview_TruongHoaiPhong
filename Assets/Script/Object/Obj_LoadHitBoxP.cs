using UnityEngine;

public class Obj_LoadHitBoxP : NewMonobehavior
{
    public AttackType currentAttackType;
    public int damage_Amount;

    public void SetAttackType(AttackType type)
    {
        currentAttackType = type;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Enemy_Hurt enemyHurt)) return;
        enemyHurt.SetLastHitType(currentAttackType);
        enemyHurt.SetTakeDamage(damage_Amount);
        
    }
}
