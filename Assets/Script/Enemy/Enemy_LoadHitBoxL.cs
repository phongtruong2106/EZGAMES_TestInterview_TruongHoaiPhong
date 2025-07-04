using UnityEngine;

public class Enemy_LoadHitBoxL : Obj_LoadHitBoxE
{
     public void SetMaxDamage(float value)
    {
        this.damage_Amount = Mathf.FloorToInt(value);
    }

    public void Init(EnemyStatsData statsData, int level)
    {
        SetMaxDamage(statsData.GetDamageForLevel(level));
    }
}