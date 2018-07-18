using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MainMenu {

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI,endGameScreen,scoreCanvas, wonGameScreen;

    int currentlvl;
    bool disablePause;
    GameObject[] player;

    public override void Awake()
    {
        currentlvl = SceneManager.GetActiveScene().buildIndex;
        source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        lvlChanger = FindObjectOfType<LvlChanger>();
        player = GameObject.FindGameObjectsWithTag("Player");
    }

    public void LateUpdate()
    {
        if (player[0] == null || player[1] == null)
        {
            endGameScreen.SetActive(true);
            scoreCanvas.SetActive(false);
        }
        if(!endGameScreen.activeSelf || !wonGameScreen.activeSelf)
        {
            disablePause = true;
        }

        if (!disablePause)
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
        lvlChanger.FadeToLevel(currentlvl);
        Wait();
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        lvlChanger.FadeToLevel(0);
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(3f);
        GameIsPaused = false;
    }

}
