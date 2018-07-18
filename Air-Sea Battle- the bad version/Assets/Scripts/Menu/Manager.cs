using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using TMPro;
using System.Collections;

public class Manager : MonoBehaviour {

    public AudioManager audioM;

    public TMP_Dropdown quality;

    public Toggle toggle;
    bool dont;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        toggle = FindObjectOfType<Dropdown>().toggle;
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
        bf.Serialize(SaveFile, data);
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
            Debug.Log(Screen.fullScreen);
            audioM.currentvolume = data.volume;
            QualitySettings.SetQualityLevel(data.qualitySetting);
            quality.value = QualitySettings.GetQualityLevel();
            toggle.isOn = Screen.fullScreen;
            
        }
    }

    [Serializable]
    class PlayerData
    {
        public float volume;
        public int qualitySetting;
    }
}

