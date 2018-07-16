using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {

    private static AudioManager instance;
    float volume;
    float currentvolume;
    Slider volumeSlider;

    private void Start()
    {
        volumeSlider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
        volume = AudioListener.volume;
    }
    void Awake () {
        DontDestroyOnLoad(gameObject);
    }
	

	void Update () {

        if (volumeSlider != null)
        {
            volume = volumeSlider.value;
            AudioListener.volume = volume;
            currentvolume = volume;
            volumeSlider.value = currentvolume;
        }
        else
        {
            AudioListener.volume = currentvolume;
        }
    }

    
}
