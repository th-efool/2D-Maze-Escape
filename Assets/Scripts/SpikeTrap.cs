using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            player.PlayDeathAnimation();
            GameManager.Instance.TriggerLose("Hit a spike!");
        }
    }
}
