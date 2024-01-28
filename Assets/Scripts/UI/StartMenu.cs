using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame()
    {
        TimeCountController.Instant._elapsedTime = 0;
        UIManager.Instant.PopDownLoosePanel();
        UIManager.Instant.PopDownWinPanel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SoundsManager.Instant.PlayMusic(GameEnums.ESoundName.Theme);
    }

    public void ReturnHome()
    {
        SceneManager.LoadScene(0);
        UIManager.Instant.PopDownLoosePanel();
        UIManager.Instant.PopDownWinPanel();
        SoundsManager.Instant.PlayMusic(GameEnums.ESoundName.StartScreen);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void ReloadScene()
    {
        UIManager.Instant.PopDownLoosePanel();
        UIManager.Instant.PopDownWinPanel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        UIManager.Instant.PopDownLoosePanel();
    }


}
