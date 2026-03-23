using UnityEngine;

public class Quicksand : MonoBehaviour
{
    [Header("Slow Amount")]
    [Range(0.1f, 0.9f)]
    public float speedMultiplier = 0.3f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            other.GetComponent<PlayerController>().SetSpeedMultiplier(speedMultiplier);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            other.GetComponent<PlayerController>().SetSpeedMultiplier(1f);
    }
}
