using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using TMPro;


public class Manager : MonoBehaviour {

    public AudioManager audioM;
    public TMP_Dropdown quality;
    public Toggle fullscreen;


    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        Load();
    }

    private void OnDisable()
    {
        Save();
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream SaveFile = File.Create(Application.persistentDataPath + "/SavedData.dat");
        PlayerData data = new PlayerData();

        data.volume = audioM.currentvolume;
        data.qualitySetting = QualitySettings.GetQualityLevel();
        data.fullscreenState = Screen.fullScreen;
        bf.Serialize(SaveFile, data);
        Debug.Log(fullscreen.isOn + " " + data.fullscreenState);
        SaveFile.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/SavedData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream loadFile = File.Open(Application.persistentDataPath + "/SavedData.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(loadFile);
            loadFile.Close();

            audioM.currentvolume = data.volume;
            quality.value = data.qualitySetting;
            QualitySettings.SetQualityLevel(data.qualitySetting);
            fullscreen.isOn = data.fullscreenState;
            Screen.fullScreen = data.fullscreenState;
            Debug.Log(fullscreen.isOn + " " + data.fullscreenState);

        }
    }

    [Serializable]
    class PlayerData
    {
        public float volume;
        public int qualitySetting;
        public bool fullscreenState;
    }
}

