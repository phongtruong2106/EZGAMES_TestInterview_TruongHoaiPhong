using UnityEngine;

public class EnemyHealth : Obj_Hp
{
    public void SetMaxHealth(float value)
    {
        this.health = Mathf.FloorToInt(value);
    }

    public void Init(EnemyStatsData statsData, int level)
    {
        SetMaxHealth(statsData.GetHPForLevel(level));
    }
}
