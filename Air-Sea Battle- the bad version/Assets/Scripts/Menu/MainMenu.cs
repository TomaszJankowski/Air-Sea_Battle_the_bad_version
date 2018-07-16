using UnityEngine.SceneManagement;
using UnityEngine;


public class MainMenu : MonoBehaviour {


    public AudioClip buttonPressSound;
    [HideInInspector]
    public AudioSource source;
    [HideInInspector]
    public AudioListener masterVolume;
    public GameObject gameManager;
    public LvlChanger lvlChanger;
   

    public virtual void Awake()
    {
        if(GameObject.FindGameObjectWithTag("Manager") == null)
            Instantiate(gameManager);

        lvlChanger = FindObjectOfType<LvlChanger>();
        source = GetComponent<AudioSource>();
        source.PlayDelayed(0.3f);
    }

    public void LoadSingleSurvival()
    {
        source.PlayOneShot(buttonPressSound);
        lvlChanger.FadeToLevel(2);
    }

    public void LoadLocalvs()
    {
        source.PlayOneShot(buttonPressSound);
        lvlChanger.FadeToLevel(1);
    }

   public void Quit()
    {
        Application.Quit();
    }
}

