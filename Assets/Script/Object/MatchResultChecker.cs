using System.Collections.Generic;
using UnityEngine;

public class MatchResultChecker : NewMonobehavior
{
    [SerializeField] private GameMode currentMode = GameMode.OneVsOne;
    [SerializeField] private PlayerControllerr PC;
    [SerializeField] private Enemy_Controller EC;
    [SerializeField] protected UI_Controller uI_Controller;
    [Header("Enemy")]
    [SerializeField] protected List<Enemy_Controller> gameObjects;
    [Header("elly")]
    [SerializeField] protected List<Enemy_Controller> EllyObj;


    private bool gameEnded = false;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPC();
        this.LoadUIC();
    }

    private void LoadUIC()
    {
        if (this.uI_Controller != null) return;
        this.uI_Controller = FindAnyObjectByType<UI_Controller>();
    }
    private void LoadPC()
    {
        if (this.PC != null) return;
        this.PC = FindAnyObjectByType<PlayerControllerr>();
    }
    private void Update()
    {
        if (gameEnded) return;

        switch (currentMode)
        {
            case GameMode.OneVsOne:
                Check1v1();
                break;
            case GameMode.OneVsMany:
                Check1v6();
                break;
            case GameMode.ManyVsMany:
                Check25vs25();
                break;
        }
    }

    private void Check1v1()
    {
        if (PC._player_TakeDamage.isDie)
        {
            gameEnded = true;
            this.uI_Controller._uI_ResultGame._anim.SetBool("Defeat", true);
            EC._anim.SetBool("victory", true);

        }
        else if (EC._enemy_TakeDamage.isDie)
        {
            gameEnded = true;
            this.uI_Controller._uI_ResultGame._anim.SetBool("Victory", true);
            PC._anim.SetBool("Victory", true);
        }
    }
    private void Check1v6()
    {
        if (PC._player_TakeDamage.isDie)
        {
            gameEnded = true;
            this.uI_Controller._uI_ResultGame._anim.SetBool("Defeat", true);

            foreach (var enemy in gameObjects)
            {
                if (enemy != null && !enemy._enemy_TakeDamage.isDie)
                {
                    enemy._anim.SetBool("victory", true);
                }
            }

            return;
        }

        bool allEnemiesDead = true;
        foreach (var enemy in gameObjects)
        {
            if (enemy != null && !enemy._enemy_TakeDamage.isDie)
            {
                allEnemiesDead = false;
                break;
            }
        }

        if (allEnemiesDead)
        {
            gameEnded = true;
            this.uI_Controller._uI_ResultGame._anim.SetBool("Victory", true);
            PC._anim.SetBool("Victory", true);
        }
    }
    private void Check25vs25()
    {
        bool allEllyDead = true;
        foreach (var elly in EllyObj)
        {
            if (elly != null && !elly._enemy_TakeDamage.isDie)
            {
                allEllyDead = false;
                break;
            }
        }

        if (PC._player_TakeDamage.isDie && allEllyDead)
        {
            gameEnded = true;
            uI_Controller._uI_ResultGame._anim.SetBool("Defeat", true);

            foreach (var enemy in gameObjects)
            {
                if (enemy != null && !enemy._enemy_TakeDamage.isDie)
                {
                    enemy._anim.SetBool("victory", true);
                }
            }

            return;
        }
        bool allEnemiesDead = true;
        foreach (var enemy in gameObjects)
        {
            if (enemy != null && !enemy._enemy_TakeDamage.isDie)
            {
                allEnemiesDead = false;
                break;
            }
        }

        if (allEnemiesDead)
        {
            gameEnded = true;
            uI_Controller._uI_ResultGame._anim.SetBool("Victory", true);

            PC._anim.SetBool("Victory", true);

            foreach (var elly in EllyObj)
            {
                if (elly != null && !elly._enemy_TakeDamage.isDie)
                {
                    elly._anim.SetBool("Victory", true);
                }
            }
        }
    }
}
