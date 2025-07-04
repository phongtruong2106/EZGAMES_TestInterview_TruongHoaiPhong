using UnityEngine;

public class Targetable : NewMonobehavior, ITargetable
{
    [SerializeField] private EntityFaction faction = EntityFaction.Player;
    public EntityFaction Faction => faction;

    public Transform GetTransform()
    {
        throw new System.NotImplementedException();
    }

    public bool IsAlive()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnEnable()
    {
        TargetManager.Instance?.Register(this);
    }

    private void OnDisable()
    {
        TargetManager.Instance?.Unregister(this);
    }
}