using UnityEngine;

public class JellyfishDamage : MonoBehaviour
{
    public float oxygenDamage = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OxygenSystem oxygenSystem =
                FindFirstObjectByType<OxygenSystem>();

            if (oxygenSystem != null)
            {
                oxygenSystem.DamageOxygen(oxygenDamage);
            }
        }
    }
}