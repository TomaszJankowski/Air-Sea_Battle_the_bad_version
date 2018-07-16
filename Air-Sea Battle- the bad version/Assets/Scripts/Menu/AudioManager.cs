using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

    float volume;
    float currentvolume;
    Slider volumeSlider;

	void Update () {

        if (volumeSlider != null)
        {
            volume = volumeSlider.value;
            AudioListener.volume = volume;
            currentvolume = volume;
        }
        else
        {
            AudioListener.volume = currentvolume;
        }
    }


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLvlFinshedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLvlFinshedLoading;
    }

    void OnLvlFinshedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Menu")
        {
            volume = AudioListener.volume;
            volumeSlider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
            volumeSlider.value = volume;
        }
        Debug.Log(scene.name);
    }

}
