using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class AudioManager : MonoBehaviour {

    float volume;
    public float currentvolume;
    [HideInInspector]
    public Slider volumeSlider;

	void Update () {

        if (volumeSlider != null)
        {
            volume = volumeSlider.value;
            AudioListener.volume = volume;
            currentvolume = AudioListener.volume;
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
            volume = currentvolume;
            volumeSlider.value = volume;
        }
    }
}
