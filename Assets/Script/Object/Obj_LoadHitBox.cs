using UnityEngine;

public abstract class Obj_LoadHitBox : NewMonobehavior
{
    public AttackType currentAttackType;
    public int damage_Amount;

    [SerializeField] protected CombatEntity ownerEntity;

    public void SetAttackType(AttackType type)
    {
        currentAttackType = type;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out CombatEntity targetEntity)) return;
        if (targetEntity.team == ownerEntity.team) return;

        HandleHit(other, targetEntity);
    }

    protected abstract void HandleHit(Collider other, CombatEntity targetEntity);

    protected override void Reset()
    {
        base.Reset();
        if (ownerEntity == null) ownerEntity = GetComponentInParent<CombatEntity>();
    }
}