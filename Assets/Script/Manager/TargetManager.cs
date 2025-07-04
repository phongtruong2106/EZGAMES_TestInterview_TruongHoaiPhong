using System.Collections.Generic;
using UnityEngine;

public class TargetManager : NewMonobehavior
{
     public static TargetManager Instance { get; private set; }

    private readonly Dictionary<EntityFaction, List<ITargetable>> factionTargets = new();

    protected override void Awake()
    {
        Instance = this;
        foreach (EntityFaction faction in System.Enum.GetValues(typeof(EntityFaction)))
        {
            if (faction == EntityFaction.None) continue;
            factionTargets[faction] = new List<ITargetable>();
        }
    }

    public void Register(ITargetable target)
    {
        if (target == null || target.Faction == EntityFaction.None) return;
        factionTargets[target.Faction].Add(target);
       // Debug.Log($"[TargetManager] Registered: {target.GetTransform().name}, Faction: {target.Faction}");
    }

    public void Unregister(ITargetable target)
    {
        if (target == null || target.Faction == EntityFaction.None) return;
        factionTargets[target.Faction].Remove(target);
    }

    public ITargetable FindClosestTarget(ITargeter requester, float maxRange = Mathf.Infinity)
    {
        if (requester == null) return null;

        List<EntityFaction> validTargets = GetValidTargetFactions(requester.Faction);
        float closestDist = maxRange;
        ITargetable closest = null;

        foreach (var faction in validTargets)
        {
            foreach (var target in factionTargets[faction])
            {
                if (target == null || !target.IsAlive()) continue;

                float dist = Vector3.Distance(requester.GetTransform().position, target.GetTransform().position);
                if (dist < closestDist)
                {
                    closestDist = dist;
                    closest = target;
                }
            }
        }
        foreach (var faction in validTargets)
        {
           //Debug.Log($"[TargetManager] Checking faction: {faction}, count: {factionTargets[faction].Count}");

            foreach (var target in factionTargets[faction])
            {
                if (target == null || !target.IsAlive()) continue;

                float dist = Vector3.Distance(requester.GetTransform().position, target.GetTransform().position);
            }
        }
        return closest;
    }

    private List<EntityFaction> GetValidTargetFactions(EntityFaction faction)
    {
        return faction switch
        {
            EntityFaction.Enemy => new List<EntityFaction> { EntityFaction.Player, EntityFaction.Ally },
            EntityFaction.Ally => new List<EntityFaction> { EntityFaction.Enemy },
            EntityFaction.Player => new List<EntityFaction> { EntityFaction.Enemy },
            _ => new List<EntityFaction>()
        };
    }
}