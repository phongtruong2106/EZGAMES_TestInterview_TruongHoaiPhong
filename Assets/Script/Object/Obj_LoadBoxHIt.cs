using UnityEngine;

public class Obj_LoadBoxHIt : NewMonobehavior
{
    [Header("HitBoxAttack")]
    [SerializeField] protected Obj_HitBoxLeft obj_HitBoxLeft;
    public Obj_HitBoxLeft _HitBoxLeft => obj_HitBoxLeft;
    [SerializeField] protected Obj_HitBoxRight obj_HitBoxRight;
    public Obj_HitBoxRight _HitBoxRight => obj_HitBoxRight;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjHBL();
        this.LoadObjHBR();
    }
    private void LoadObjHBL()
    {
        if (this.obj_HitBoxLeft != null) return;
        this.obj_HitBoxLeft = this.gameObject.GetComponentInChildren<Obj_HitBoxLeft>();
    }
    private void LoadObjHBR()
    {
        if (this.obj_HitBoxRight != null) return;
        this.obj_HitBoxRight = this.gameObject.GetComponentInChildren<Obj_HitBoxRight>();
    }
}