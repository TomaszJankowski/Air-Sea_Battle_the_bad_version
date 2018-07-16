using UnityEngine.SceneManagement;
using UnityEngine;


public class MainMenu : MonoBehaviour {


    public AudioClip buttonPressSound;
    [HideInInspector]
    public AudioSource source;
    [HideInInspector]
    public AudioListener masterVolume;
    public GameObject audioManager;
    

    public virtual void Awake()
    {
        if(GameObject.FindGameObjectWithTag("Audio") == null)
            Instantiate(audioManager);

        source = GetComponent<AudioSource>();
        source.PlayDelayed(0.2f);
    }

    public void LoadSingleSurvival()
    {
        source.PlayOneShot(buttonPressSound);
        SceneManager.LoadScene(2);
    }

    public void LoadLocalvs()
    {
        source.PlayOneShot(buttonPressSound);
        SceneManager.LoadScene(1);
    }

   public void Quit()
    {
        Application.Quit();
    }
}

