using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStatsData", menuName = "Game/Enemy Stats Data")]
public class EnemyStatsData : ScriptableObject
{
    public int baseHP = 100;
    public int hpGrowth = 20;

    public int baseDamage = 10;
    public int damageGrowth = 5;

    public int GetHPForLevel(int level)
    {
        return baseHP + (level - 1) * hpGrowth;
    }

    public int GetDamageForLevel(int level)
    {
        return baseDamage + (level - 1) * damageGrowth;
    }
}
