using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public Text highScoreText;
    //input field
    public TMP_InputField PlayerNameText;
    // Start is called before the first frame update
    void Start()
    {
        Data.Instance.LoadData();
        highScoreText.text = "Best Score: " + Data.Instance.highScorePlayerName + " - " + Data.Instance.highScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Data.Instance.SaveData();
        Application.Quit();
    }

    public void StartGame()
    {
        Debug.Log("Start");
        UnityEngine.SceneManagement.SceneManager.LoadScene("main");
        Data.Instance.playerName = PlayerNameText.text;
    }

}
