using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MainMenu {

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI,endGameScreen,scoreCanvas;

    GameObject[] player;

    public override void Awake()
    {
        source = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectsWithTag("Player");
    }
    public void Update()
    {
        if (endGameScreen.activeSelf == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }

        if(player[0] == null || player[1] == null)
        {
            endGameScreen.SetActive(true);
            scoreCanvas.SetActive(false);

        }
    }


    public void Resume()
    {
        source.PlayOneShot(buttonPressSound);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Restart()
    {
        source.PlayOneShot(buttonPressSound);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(0);
    }

}
