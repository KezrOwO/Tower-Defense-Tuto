using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool gameIsOver ;
    public GameObject gameOverUI;

    public SceneFader sceneFader;

    public GameObject completLevelUI;

    private void Start()
    {
        gameIsOver = false;
    }

    void Update()
    {

        if (gameIsOver)
            return;

        if (PlayerStats.lives <= 0) 
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        gameIsOver = true;
        completLevelUI.SetActive(true);
    }
}
