using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.CollectKey();
            Debug.Log("Key collected!");
            gameObject.SetActive(false);
        }
    }
}
