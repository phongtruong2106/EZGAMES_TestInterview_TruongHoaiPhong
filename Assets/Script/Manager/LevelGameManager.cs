using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGameManager : NewMonobehavior
{
    [SerializeField] private LevelData levelData;
    [SerializeField] private EnemyStatsData enemyStatsData;

    private const int MaxLevel = 10;

    private void Start()
    {
        InitAllEnemies();
    }

    private void InitAllEnemies()
    {
        EnemyHealth[] allEnemyHealths = FindObjectsOfType<EnemyHealth>();
        foreach (var e in allEnemyHealths)
        {
            e.Init(enemyStatsData, levelData.currentLevel);
        }

        Enemy_LoadHitBoxR[] allEnemyAttackers = FindObjectsOfType<Enemy_LoadHitBoxR>();
        foreach (var e in allEnemyAttackers)
        {
            e.Init(enemyStatsData, levelData.currentLevel);
        }
    }

    public void OnNextLevelClicked()
    {
        if (levelData.currentLevel < MaxLevel)
        {
            levelData.currentLevel++;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResetGame()
    {
        levelData.currentLevel = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
