using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour {
    public int howManyPointsToWin;
    [HideInInspector]
    public int playerFirstScore, playerSecondScore;
    TextMeshProUGUI score;
    public TextMeshProUGUI whoWonText;
    public GameObject wonTheGameScreen;
    string plOne, plTwo;

	void Awake () {
        score = GetComponent<TextMeshProUGUI>();
        plOne = "Player One";
        plTwo = "Player Two";
        playerFirstScore = 0;
        playerSecondScore = 0;
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
        Time.timeScale = 0f;
        wonTheGameScreen.SetActive(true);
    }
}
