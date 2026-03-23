using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Keys")]
    public int totalKeys = 3;
    private int collectedKeys = 0;

    [Header("Timer")]
    public float timeLimit = 60f;
    private float timeRemaining;
    private bool gameActive = false;

    [Header("Restart")]
    public float restartDelay = 3f;
    private bool restarting = false;
    private float restartTimer = 0f;
    private bool loadNextScene = false;

    [Header("UI")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI keysText;
    public TextMeshProUGUI statusText;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        timeRemaining = timeLimit;
        gameActive = true;
        statusText.text = "";
        UpdateUI();
    }

    void Update()
    {
        if (restarting)
        {
            restartTimer += Time.deltaTime;
            if (restartTimer >= restartDelay)
            {
                if (loadNextScene)
                {
                    int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
                    // If no next scene exists, go back to MainMenu (index 0)
                    if (nextIndex >= SceneManager.sceneCountInBuildSettings)
                        nextIndex = 0;
                    SceneManager.LoadScene(nextIndex);
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
            return;
        }

        if (!gameActive) return;

        timeRemaining -= Time.deltaTime;
        UpdateUI();

        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            TriggerLose("Time's up!");
        }
    }

    public void CollectKey()
    {
        collectedKeys++;
        UpdateUI();
    }

    public bool AllKeysCollected()
    {
        return collectedKeys >= totalKeys;
    }

    public void TriggerWin()
    {
        if (!gameActive) return;
        gameActive = false;
        loadNextScene = true;

        int score = Mathf.RoundToInt(timeRemaining * 10);
        Debug.Log("Game Win — Score: " + score);
        statusText.text = "YOU ESCAPED!\nScore: " + score + "\nLoading next level...";
        restarting = true;
    }

    public void TriggerLose(string reason)
    {
        if (!gameActive) return;
        gameActive = false;
        loadNextScene = false;

        Debug.Log("Game Over — " + reason);
        statusText.text = "GAME OVER\n" + reason + "\nRestarting...";
        restarting = true;
    }

    public bool IsGameActive() => gameActive;

    void UpdateUI()
    {
        if (timerText != null)
            timerText.text = "Time: " + Mathf.CeilToInt(timeRemaining);

        if (keysText != null)
            keysText.text = "Keys: " + collectedKeys + " / " + totalKeys;
    }
}