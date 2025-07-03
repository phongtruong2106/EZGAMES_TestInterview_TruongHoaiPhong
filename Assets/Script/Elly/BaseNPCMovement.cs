using UnityEngine;

public abstract class BaseNPCMovement : NewMonobehavior
{
    protected abstract void MoveToTarget();
    public virtual void TickMovement()
    {
        // Giống như Update nhưng gọi từ Manager
        MoveToTarget();
    }
}