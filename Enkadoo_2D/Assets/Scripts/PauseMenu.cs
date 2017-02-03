using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject PauseUI;

    private bool paused;

    void Start()
    {
        PauseUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }

        if (paused)
        {
           PauseUI.SetActive(true);
           Time.timeScale = 0; //zatrzymaneiu gry
        }
        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1; //wznowienie gry
        }
    }


    public void resume()
    {
        paused = !paused;
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void main_menu()
    {
        SceneManager.LoadScene(3);
    }
    public void quit()
    {
        Application.Quit();
    } 
}
