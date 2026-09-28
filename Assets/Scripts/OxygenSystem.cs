using UnityEngine;
using TMPro;

public class OxygenSystem : MonoBehaviour
{
    public float maxOxygen = 100f;
    public float oxygen = 100f;
    public float oxygenDrainRate = 1f;

    public int oxygenTanks = 0;
    public int maxOxygenTanks = 4;

    public TMP_Text oxygenText;
    public GameObject gameOverPanel;

    private bool gameOver = false;

    private void Start()
    {
        oxygen = maxOxygen;
        gameOverPanel.SetActive(false);
        UpdateOxygenText();
    }

    private void Update()
    {
        if (gameOver)
        {
            return;
        }

        oxygen -= oxygenDrainRate * Time.deltaTime;

        if (oxygen <= 0)
        {
            oxygen = 0;

            if (oxygenTanks > 0)
            {
                oxygenTanks--;
                oxygen = maxOxygen;
            }
            else
            {
                GameOver();
            }
        }

        UpdateOxygenText();
    }

    private void UpdateOxygenText()
    {
        oxygenText.text = Mathf.Ceil(oxygen).ToString();
    }

    public void AddOxygenTank()
    {
        if (oxygenTanks < maxOxygenTanks)
        {
            oxygenTanks++;
        }
    }

    public void DamageOxygen(float amount)
    {
        oxygen -= amount;

        if (oxygen <= 0)
        {
            oxygen = 0;

            if (oxygenTanks > 0)
            {
                oxygenTanks--;
                oxygen = maxOxygen;
            }
            else
            {
                GameOver();
            }
        }

        UpdateOxygenText();
    }

    public void GameOver()
    {
        if (gameOver)
        {
            return;
        }

        gameOver = true;

        // تجميد اللعبة بالكامل
        Time.timeScale = 0f;

        // إظهار شاشة Game Over
        gameOverPanel.SetActive(true);
    }
}