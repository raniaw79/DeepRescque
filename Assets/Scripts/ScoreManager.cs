using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TMP_Text scoreText;
    public GameObject levelCompletePanel;

    public int levelCompleteScore = 50;

    private int score = 0;
    private bool levelCompleted = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (levelCompletePanel == null)
        {
            Canvas canvas = FindFirstObjectByType<Canvas>();

            if (canvas != null)
            {
                Transform panel = FindChildRecursive(
                    canvas.transform,
                    "LevelCompletePanel"
                );

                if (panel != null)
                {
                    levelCompletePanel = panel.gameObject;
                }
            }
        }

        if (levelCompletePanel != null)
        {
            levelCompletePanel.SetActive(false);
        }

        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        if (levelCompleted)
        {
            return;
        }

        score += points;

        UpdateScoreText();

        if (score >= levelCompleteScore)
        {
            levelCompleted = true;
            ShowLevelComplete();
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    private void ShowLevelComplete()
    {
        if (levelCompletePanel != null)
        {
            levelCompletePanel.SetActive(true);
            Time.timeScale = 0f;

            Debug.Log("LEVEL 2 POPUP SHOWN!");
        }
    }

    private Transform FindChildRecursive(
        Transform parent,
        string childName)
    {
        foreach (Transform child in parent)
        {
            if (child.name == childName)
            {
                return child;
            }

            Transform result = FindChildRecursive(
                child,
                childName
            );

            if (result != null)
            {
                return result;
            }
        }

        return null;
    }
}