using UnityEngine;

public class Obj_LoadHitBoxE : Obj_LoadHitBox
{
    protected override void HandleHit(Collider other, CombatEntity targetEntity)
    {
        if (!other.TryGetComponent(out PlayerHurt playerHurt)) return;
        playerHurt.SetLastHitType(currentAttackType);
        playerHurt.SetTakeDamage(damage_Amount);
    }
}