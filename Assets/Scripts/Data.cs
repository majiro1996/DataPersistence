using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


[System.Serializable]
public class Data : MonoBehaviour
{
    public static Data Instance;
    public int score = 0;
    public string playerName = "Player";

    public int highScore = 0;
    public string highScorePlayerName = "Player";

    private void Awake() 
    {
        // Singleton pattern
        if (Instance == null) 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else 
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start() 
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetData() 
    {
        score = 0;
        playerName = "Player";
    }

    public void SetHighScore() 
    {
        if (score > highScore)
        {
            highScore = score;
            highScorePlayerName = playerName;
        }
    }

    public void SaveData() 
    {
        string path = Application.persistentDataPath + "/savefile.json";
        string json = JsonUtility.ToJson(this);
        File.WriteAllText(path, json);
        Debug.Log("Saved to " + path);
    }

    public void LoadData() 
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path)) 
        {
            string json = File.ReadAllText(path);
            JsonUtility.FromJsonOverwrite(json, this);
        }
    }

}
