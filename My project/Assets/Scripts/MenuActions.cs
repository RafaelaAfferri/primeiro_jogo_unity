using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuActions : MonoBehaviour

{
    public void StartGame()
    {
        // Load the game scene (assuming it's index 1)
        SceneManager.LoadScene(1);
    }
}
