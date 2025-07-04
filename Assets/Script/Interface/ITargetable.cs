using UnityEngine;

public interface ITargetable
{
    EntityFaction Faction { get; }
    Transform GetTransform();
    bool IsAlive();    
}