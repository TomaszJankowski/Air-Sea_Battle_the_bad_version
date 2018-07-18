using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour {
    public int howManyPointsToWin;
    [HideInInspector]
    public int playerFirstScore, playerSecondScore;
    TextMeshProUGUI score;
    public TextMeshProUGUI whoWonText;
    public GameObject wonTheGameScreen, tips;
    string plOne, plTwo;

	void Awake () {
        score = GetComponent<TextMeshProUGUI>();
        plOne = "Player One";
        plTwo = "Player Two";
        playerFirstScore = 0;
        playerSecondScore = 0;
    }

    private void Start()
    {
        Invoke("DisableTips",2.5f);
    }

    void Update () {
        score.text = "Punkty: " + playerFirstScore + " | "+ playerSecondScore;
        if(playerFirstScore >= howManyPointsToWin)
        {
            WonTheGame(plOne);
        }
        if(playerSecondScore >= howManyPointsToWin)
        {
            WonTheGame(plTwo);
        }
	}

    void WonTheGame(string playerWhoWon)
    {
        whoWonText.text = "Congrats " + playerWhoWon + " you won the game";
        score.gameObject.SetActive(false);
        wonTheGameScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    void DisableTips()
    {
        tips.SetActive(false);
    }
}
