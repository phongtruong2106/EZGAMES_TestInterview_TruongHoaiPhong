using UnityEngine;

public interface ITargeter
{
    public EntityFaction Faction { get; }
    public Transform GetTransform();
}