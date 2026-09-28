using UnityEngine;
using TMPro;

public class TrashCounter : MonoBehaviour
{
    public static TrashCounter Instance;

    public TMP_Text counterText;

    private int trashCollected = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateCounter();
    }

    public void AddTrash()
    {
        trashCollected++;
        UpdateCounter();

        FallingTrash[] allTrash = FindObjectsByType<FallingTrash>(FindObjectsSortMode.None);

        foreach (FallingTrash trash in allTrash)
        {
            trash.IncreaseSpeed(0.1f);
        }
    }

    private void UpdateCounter()
    {
        counterText.text = ": " + trashCollected;
    }
}