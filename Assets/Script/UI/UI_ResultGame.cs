using UnityEngine;

public class UI_ResultGame : NewMonobehavior
{
    [SerializeField] protected Animator anim;
    public Animator _anim => anim;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnim();
    }

    private void LoadAnim()
    {
        if (this.anim != null) return;
        this.anim = GetComponent<Animator>();
    }
}