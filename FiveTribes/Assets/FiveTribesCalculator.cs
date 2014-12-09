using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FiveTribesCalculator : MonoBehaviour {

    public GameObject[] playerOneInputs;
    public GameObject[] playerTwoInputs;
    public GameObject[] playerThreeInputs;
    public GameObject[] playerFourInputs;

    public InputField playerOneName;
    public InputField playerTwoName;
    public InputField playerThreeName;
    public InputField playerFourName;

    public Text playerOneTotalScore;
    public Text playerTwoTotalScore;
    public Text playerThreeTotalScore;
    public Text playerFourTotalScore;

    public GameObject ClearScore;

	void Start () {
        playerOneInputs = GameObject.FindGameObjectsWithTag("PlayerOne");
        playerTwoInputs = GameObject.FindGameObjectsWithTag("PlayerTwo");
        playerThreeInputs = GameObject.FindGameObjectsWithTag("PlayerThree");
        playerFourInputs = GameObject.FindGameObjectsWithTag("PlayerFour");
	}

    public void CalculateScore()
    {
        CalculatePlayerScore(playerOneName, playerOneInputs, playerOneTotalScore);
        CalculatePlayerScore(playerTwoName, playerTwoInputs, playerTwoTotalScore);
        CalculatePlayerScore(playerThreeName, playerThreeInputs, playerThreeTotalScore);
        CalculatePlayerScore(playerFourName, playerFourInputs, playerFourTotalScore);
    }

    public void ClearScoreBoard()
    {
        ClearPlayerScore(playerOneName, playerOneInputs, playerOneTotalScore);
        ClearPlayerScore(playerTwoName, playerTwoInputs, playerTwoTotalScore);
        ClearPlayerScore(playerThreeName, playerThreeInputs, playerThreeTotalScore);
        ClearPlayerScore(playerFourName, playerFourInputs, playerFourTotalScore);
    }

    void CalculatePlayerScore(InputField playerName, GameObject[] playerInput, Text playerTotalScore)
    {
        if (!string.IsNullOrEmpty(playerName.value))
        {
            Debug.Log("here");
            int playerScore = 0;

            for (int i = 0; i < playerInput.Length; i++)
            {
                if (string.IsNullOrEmpty(playerInput[i].GetComponentInChildren<InputField>().value))
                    playerScore += 0;
                else
                    playerScore += int.Parse(playerInput[i].GetComponentInChildren<InputField>().value);
            }

            playerTotalScore.text = playerScore.ToString();
        }

        ClearScore.SetActive(true);
    }

    void ClearPlayerScore(InputField playerName, GameObject[] playerInput, Text playerTotalScore)
    {
        playerName.value = "";

        for (int i = 0; i < playerInput.Length; i++)
        {
            playerInput[i].GetComponentInChildren<InputField>().value = "";
        }

        playerTotalScore.text = "0";

        ClearScore.SetActive(false);
    }

}
