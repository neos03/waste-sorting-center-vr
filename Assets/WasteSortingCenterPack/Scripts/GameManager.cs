using UnityEngine;
using TMPro; 

public class GameManager : MonoBehaviour
{
    [Header("Game Settings")]
    public float gameDurationSeconds = 120f;
    public int goodPoints = 1;
    public int badPenalty = 10;

    [Header("References")]
    public TrashSpawner spawner;            
    public TreadmillsController controller; 

    [Header("UI")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;

    public int Score { get; private set; }
    public bool IsGameOver { get; private set; }

    float timeLeft;

    void Start()
    {
        Score = 0;
        timeLeft = gameDurationSeconds;
        IsGameOver = false;
        RefreshUI();
    }

    void Update()
    {
        if (IsGameOver) return;

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0f)
        {
            timeLeft = 0f;
            GameOver();
        }

        RefreshUI();
    }

    public void RegisterTrashReachedEnd(Trash trash)
    {
        if (IsGameOver || trash == null) return;

        if (trash.type == TrashType.Good) Score += goodPoints;
        else Score -= badPenalty;

        Destroy(trash.gameObject);
        RefreshUI();
    }

    void GameOver()
    {
        IsGameOver = true;

        if (spawner != null) spawner.enabled = false;
        if (controller != null) controller.SetPaused(true);

        Debug.Log($"GAME OVER - Score final: {Score}");
        RefreshUI();
    }

    void RefreshUI()
    {
        if (scoreText) scoreText.text = $"Score : {Score}";
        if (timeText) timeText.text = $"Temps : {Mathf.CeilToInt(timeLeft)}";
    }
}
