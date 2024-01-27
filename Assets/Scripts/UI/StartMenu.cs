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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SoundsManager.Instant.PlayMusic(GameEnums.ESoundName.Theme);
    }

    public void EndGame()
    {
        Application.Quit();
    }


}
