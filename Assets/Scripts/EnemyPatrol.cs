using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    public Transform pointA;
    public Transform pointB;

    [Header("Speed")]
    public float speed = 2.5f;

    private Transform target;

    void Start()
    {
        target = pointB;
    }

    void Update()
    {
        if (pointA == null || pointB == null) return;
        if (!GameManager.Instance.IsGameActive()) return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, target.position) < 0.05f)
            target = (target == pointA) ? pointB : pointA;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Game Over — Caught by enemy");
            other.GetComponent<PlayerController>().ResetToStart();
            GameManager.Instance.TriggerLose("Caught by enemy!");
        }
    }
}
