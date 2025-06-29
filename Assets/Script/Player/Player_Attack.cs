using UnityEngine;

public class Player_Attack : NewMonobehavior
{
    
    public void Init()
    {
        //controlAttack.OnAttackTriggered += HandleAttack;
    }
    protected override void Start()
    {
        base.Start();
        InputManager.OnTap += HandleAttack;
    }
    private void HandleAttack()
    {
        Debug.Log("Player Attack!");
    }
    private void OnDestroy()
    {
        InputManager.OnTap -= HandleAttack;
    }
}