using UnityEngine;

public class Enemy_LoadHitBoxR : Obj_LoadHitBoxE
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