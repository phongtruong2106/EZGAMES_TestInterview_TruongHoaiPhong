using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerr : NewMonobehavior
{
    [SerializeField] protected Obj_Movement movementScript;
    public Obj_Movement _movementScript => movementScript;
    [SerializeField] protected SwipeDetector swipeDetector;
    public SwipeDetector _swipeDetector => swipeDetector;
    [SerializeField] protected Player_Attack player_Attack;
    public Player_Attack _player_Attack => player_Attack;
    [SerializeField] protected Obj_LoadBoxHIt obj_LoadBoxHIt;
    public  Obj_LoadBoxHIt _obj_LoadBoxHit => obj_LoadBoxHIt;
    [SerializeField] protected Animator anim;
    public Animator _anim => anim;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjMovement();
        this.LoadSwipeController();
        this.LoadPlayerAttack();
        this.LoadAnimation();
        this.LoadObjLoadBH();
    }

    private void LoadObjLoadBH()
    {
        if (this.obj_LoadBoxHIt != null) return;
        this.obj_LoadBoxHIt = this.gameObject.GetComponentInChildren<Obj_LoadBoxHIt>();
    }
    private void LoadAnimation()
    {
        if (this.anim != null) return;
        this.anim = gameObject.GetComponentInChildren<Animator>();
    }
    private void LoadPlayerAttack()
    {
        if (this.player_Attack != null) return;
        this.player_Attack = gameObject.GetComponentInChildren<Player_Attack>();
    }
    private void LoadObjMovement()
    {
        if (this.movementScript != null) return;
        this.movementScript = gameObject.GetComponentInChildren<Obj_Movement>();
    }
    private void LoadSwipeController()
    {
        if (this.swipeDetector != null) return;
        this.swipeDetector = gameObject.GetComponentInChildren<SwipeDetector>();
    }
}
