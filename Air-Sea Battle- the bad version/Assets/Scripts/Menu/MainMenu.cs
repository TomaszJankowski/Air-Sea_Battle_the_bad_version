using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour {
    GameObject manager;
    public GameObject gameManager;
    public Slider slider;

    public AudioClip buttonPressSound;
    [HideInInspector]
    public AudioSource source;
    [HideInInspector]
    public AudioListener masterVolume;
    [HideInInspector]
    public LvlChanger lvlChanger;
    
   
    public virtual void Awake()
    {
        if (GameObject.FindGameObjectWithTag("Manager") == null)
        {
            manager = Instantiate(gameManager);
            manager.GetComponentInChildren<AudioManager>().volumeSlider = slider;
        }

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

