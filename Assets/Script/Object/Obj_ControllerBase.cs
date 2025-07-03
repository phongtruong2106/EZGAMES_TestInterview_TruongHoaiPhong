using UnityEngine;

public class Obj_ControllerBase : NewMonobehavior
{
    public TeamType team;
    public Transform currentTarget;

    public virtual void FindTarget() {
    }
}