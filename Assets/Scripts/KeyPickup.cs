using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.CollectKey();
            Debug.Log("Key collected!");
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;


            var a = GetComponent<AudioSource>();
            if (a) a.Play();
            Destroy(gameObject, a ? a.clip.length : 0f);
        }
    }
}
 