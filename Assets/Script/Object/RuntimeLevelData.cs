using UnityEngine;

public class RuntimeLevelData : NewMonobehavior
{
    public int currentLevel;

    public RuntimeLevelData(LevelData template)
    {
        currentLevel = template.currentLevel;
    }

    public float GetHealthMultiplier() => 1.2f + (currentLevel - 1) * 0.1f;
    public float GetDamageMultiplier() => 1.0f + (currentLevel - 1) * 0.15f;

    public void AdvanceLevel() => currentLevel++;
    public void ResetLevel() => currentLevel = 1;
}