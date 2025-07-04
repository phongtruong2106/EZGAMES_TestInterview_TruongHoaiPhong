using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_NextLevel : NewMonobehavior
{
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private LevelData levelData;
    private bool isFlag;

    protected override void Start()
    {
        this.isFlag = true;
    }

    protected void Update()
    {
        if (this.isFlag)
        {

            nextLevelButton.onClick.AddListener(OnNextLevelClicked);
            this.isFlag = false;
        }
    }

    private void UpdateLevelText(int level)
    {
        if (levelText != null)
            levelText.text = "Level: " + levelData.currentLevel;
    }

    private void OnNextLevelClicked()
    {
        if (this.levelData.currentLevel < 10)
        {
            this.levelData.currentLevel++;
        }
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       // LevelGameManager.Instance.AdvanceLevel();
    }
}
