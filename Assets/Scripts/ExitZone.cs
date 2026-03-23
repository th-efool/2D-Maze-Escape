using UnityEngine;

public class ExitZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (GameManager.Instance.AllKeysCollected())
        {
            Debug.Log("Game Win");
            other.GetComponent<PlayerController>().ResetToStart();
            GameManager.Instance.TriggerWin();
        }
        else
        {
            Debug.Log("Need more keys!");
        }
    }
}
