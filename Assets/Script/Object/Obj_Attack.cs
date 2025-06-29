using UnityEngine;

public class Obj_Attack : NewMonobehavior
{
    [SerializeField] private Player_Attack playerAttack;
    [SerializeField] private Enemy_Attack enemyAttack;

    protected override void Start()
    {
        playerAttack?.Init();
        enemyAttack?.Init();
    }
}