using UnityEngine;

public class Obj_LoadBoxHIt : NewMonobehavior
{
    [Header("HitBoxAttack")]
    [SerializeField] protected Obj_HitBoxLeft obj_HitBoxLeft;
    public Obj_HitBoxLeft _HitBoxLeft => obj_HitBoxLeft;
    [SerializeField] protected Obj_HitBoxRight obj_HitBoxRight;
    public Obj_HitBoxRight _HitBoxRight => obj_HitBoxRight;
    [SerializeField] protected Enemy_LoadHitBoxL enemy_LoadHitBoxL;
    public Enemy_LoadHitBoxL _enemy_LoadHitBoxL => enemy_LoadHitBoxL;
    [SerializeField] protected Enemy_LoadHitBoxR enemy_LoadHitBoxR;
    public Enemy_LoadHitBoxR _enemy_LoadHitBoxR => enemy_LoadHitBoxR;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjHBL();
        this.LoadObjHBR();
        this.LoadEHBL();
        this.LoadEHBR();
    }
    private void LoadEHBL()
    {
        if (this.enemy_LoadHitBoxL != null) return;
        this.enemy_LoadHitBoxL = gameObject.GetComponentInChildren<Enemy_LoadHitBoxL>();
    }
    private void LoadEHBR()
    {
        if (this.enemy_LoadHitBoxR != null) return;
        this.enemy_LoadHitBoxR = gameObject.GetComponentInChildren<Enemy_LoadHitBoxR>();
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