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
    [SerializeField] protected Player_LoadBoxHit obj_LoadBoxHIt;
    public  Player_LoadBoxHit _obj_LoadBoxHit => obj_LoadBoxHIt;
    [SerializeField] protected Player_HP player_HP;
    public Player_HP _player_HP => player_HP;
    [SerializeField] protected Animator anim;
    public Animator _anim => anim;
    [SerializeField] protected Rigidbody rb;
    public Rigidbody _rb => rb;
    [SerializeField] protected CharacterController characterController;
    public CharacterController _characterController => characterController;
    [SerializeField] protected Player_TakeDamage player_TakeDamage;
    public Player_TakeDamage _player_TakeDamage => player_TakeDamage;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjMovement();
        this.LoadSwipeController();
        this.LoadPlayerAttack();
        this.LoadAnimation();
        this.LoadObjLoadBH();
        this.LoadRB();
        this.LoadCC();
        this.LoadPlayerHP();
        this.LoadPlayerTakeDamage();
    }
    private void LoadPlayerTakeDamage()
    {
        if (this.player_TakeDamage != null) return;
        this.player_TakeDamage = gameObject.GetComponentInChildren<Player_TakeDamage>();
    }
    private void LoadPlayerHP()
    {
        if (this.player_HP != null) return;
        this.player_HP = gameObject.GetComponentInChildren<Player_HP>();
    }
    private void LoadRB()
    {
        if (this.rb != null) return;
        this.rb = GetComponent<Rigidbody>();
    }
    private void LoadCC()
    {
        if (this.characterController != null) return;
        this.characterController = GetComponent<CharacterController>();
    }
    private void LoadObjLoadBH()
    {
        if (this.obj_LoadBoxHIt != null) return;
        this.obj_LoadBoxHIt = this.gameObject.GetComponentInChildren<Player_LoadBoxHit>();
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
