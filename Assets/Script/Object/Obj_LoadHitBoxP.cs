using UnityEngine;

public class Obj_LoadHitBoxP : NewMonobehavior
{
    public AttackType currentAttackType;

    public void SetAttackType(AttackType type)
    {
        currentAttackType = type;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Enemy_Hurt enemyHurt)) return;
        enemyHurt.SetLastHitType(currentAttackType);
    }
}
