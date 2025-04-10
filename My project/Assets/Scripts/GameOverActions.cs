using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverActions : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI victoryText;

    public TextMeshProUGUI timeText;

    public TextMeshProUGUI scoreText;

    


    public void Start()
    {   
       
        coinsText.text = "Coins: " + GameData.Coins.ToString();
        victoryText.text = GameData.IsVictory ? "You Win!" : "Game Over!";
        timeText.text = "Time: " + GameData.Time.ToString();
        scoreText.text = "Score: " + (GameData.Coins *100 / GameData.ElapsedTime).ToString("F1");
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu(){
        // Load the main menu scene (assuming it's index 0)
        SceneManager.LoadScene(0);
    }

}
