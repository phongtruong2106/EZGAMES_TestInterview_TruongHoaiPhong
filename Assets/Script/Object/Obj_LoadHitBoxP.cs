using UnityEngine;

public class Obj_LoadHitBoxP : Obj_LoadHitBox
{
    protected override void HandleHit(Collider other, CombatEntity targetEntity)
    {
         if (!other.TryGetComponent(out Enemy_Hurt enemyHurt)) return;
        enemyHurt.SetLastHitType(currentAttackType);
        enemyHurt.SetTakeDamage(damage_Amount);
    }
}
