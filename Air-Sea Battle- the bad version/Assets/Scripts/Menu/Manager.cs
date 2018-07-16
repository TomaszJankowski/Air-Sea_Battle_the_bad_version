using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Manager : MonoBehaviour {

    public AudioManager audioM;

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

            audioM.currentvolume = data.volume;
        }
    }

    [Serializable]
    class PlayerData
    {
        public float volume;
    }
}

