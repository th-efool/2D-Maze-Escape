using UnityEngine;

public class ExitZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (GameManager.Instance.AllKeysCollected())
        {
            Debug.Log("Game Win");
            
            var a = GetComponent<AudioSource>();
            if (a) a.Play();
            foreach (var obj in GameObject.FindGameObjectsWithTag("backgroundmusic"))
                obj.SetActive(false);

            GameManager.Instance.TriggerWin();
            other.GetComponent<PlayerController>().ResetToStart();

        }
        else
        {
            Debug.Log("Need more keys!");
        }
    }
}
