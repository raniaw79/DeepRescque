using UnityEngine;
using System.Collections;

public class SharkSpawner : MonoBehaviour
{
    private GameObject shark;

    void Start()
    {
        SpriteRenderer sharkSprite = GetComponentInChildren<SpriteRenderer>(true);

        if (sharkSprite == null)
        {
            Debug.LogError("SHARK NOT FOUND!");
            return;
        }

        shark = sharkSprite.gameObject;

        shark.SetActive(false);

        StartCoroutine(ShowShark());
    }

    IEnumerator ShowShark()
    {
        yield return new WaitForSeconds(10f);

        shark.SetActive(true);

        Debug.Log("SHARK APPEARED!");
    }
}