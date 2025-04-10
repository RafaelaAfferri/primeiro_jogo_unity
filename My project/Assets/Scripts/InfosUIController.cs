using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InfosUIController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    public TextMeshProUGUI timeText;

    private float elapsedTime = 0f;
    private bool isRunning = true;

    public void UpdateLives(int lives)
    {
        livesText.text = "Lives: " + lives.ToString();
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void Update()
    {
        if (!isRunning) return;

        elapsedTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        timeText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public float GetElapsedTime()
    {
        return elapsedTime;
    }

    public string GetFormattedTime()
    {
    int minutes = Mathf.FloorToInt(elapsedTime / 60f);
    int seconds = Mathf.FloorToInt(elapsedTime % 60f);
    return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}