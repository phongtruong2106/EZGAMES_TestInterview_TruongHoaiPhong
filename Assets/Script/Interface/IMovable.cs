using UnityEngine;

public interface IMovable
{
    public Transform GetTransform();
    public void SetDestination(Vector3 destination);
    public bool ShouldMove();
}