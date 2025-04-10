using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Player player;
    public InfosUIController infosUIController; // Reference to the UI controller
    void Update()
    {
        if(player.coins >= 4)
        {
            GameData.IsVictory = true;
            GameData.Coins = player.coins;
            GameData.Time = infosUIController.GetFormattedTime(); 
        GameData.ElapsedTime = infosUIController.GetElapsedTime(); 
            SceneManager.LoadScene(2); // Load the Game Over scene
        }

        if (player.isDead)
        {
            GameData.IsVictory = false;
            GameData.Coins = player.coins;
            GameData.Time = infosUIController.GetFormattedTime(); // Get the formatted time from the UI controller
            GameData.ElapsedTime = infosUIController.GetElapsedTime(); // Get the elapsed time from the UI controller
            SceneManager.LoadScene(2); // Load the Game Over scene
        }
    }

}
