using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player
{
	public Image panel;
	public Text text;
	public Button button;
}

[System.Serializable]
public class PlayerColor
{
	public Color panelColor;
	public Color textColor;
}

public class GameController : MonoBehaviour {

	public Text[] buttonList;

	public string playerSideOne;
	public string playerSideTwo;
	public bool whoseSide;
	private int moveCount;

	public GameObject gameOverPanel;
	public Text gameOverText;

	public GameObject restartButton;

	public Player playerX;
	public Player playerO;
	public PlayerColor activePlayer;
	public PlayerColor inactivePlayer;

	public Text playerTextX;
	public Text playerTextO;
	private static int winsPlayerX;
	private static int winsPlayerO;

	public string playerNameOne;
	public string playerNameTwo;

	public GameObject turnButtonPanel;
	public Text turnButton;

	public GameObject startInfo;
	public Text startInfoText;

	public bool isPlayerOne;

	void Awake()
	{
		gameOverPanel.SetActive (false);
		SetGameControllerReferenceOnButtons ();
		moveCount = 0;
		restartButton.SetActive (false);
		startInfo.SetActive (true);
		whoseSide = true;
		isPlayerOne = true;

		winsPlayerX = 0;
		winsPlayerO = 0;

		playerNameOne = MainMenuManager.playerOneName;
		playerNameTwo = MainMenuManager.playerTwoName;


		if (playerNameOne == null || playerNameOne == "") {
			playerNameOne = "Player 1";
		}

		if (playerNameTwo == null || playerNameTwo == "") {
			playerNameTwo = "Player 2";
		}

		playerTextX.text = playerNameOne + " Wins: " + winsPlayerX;
		playerTextO.text = playerNameTwo + " Wins: " + winsPlayerO;

		turnButtonPanel.SetActive (false);
		turnButton.text = playerNameOne + "'s Turn";

		startInfoText.text = playerNameOne + "\r\n" + "Choose A Side!";
	}

	void SetGameControllerReferenceOnButtons()
	{
		for (int i = 0; i < buttonList.Length; i++) 
		{
			buttonList [i].GetComponentInParent<GridSpace> ().SetGameControllerReference (this);
		}
	}

	void SetPlayerColors(Player newPlayer, Player oldPlayer)
	{
		newPlayer.panel.color = activePlayer.panelColor;
		newPlayer.text.color = activePlayer.textColor;
		oldPlayer.panel.color = inactivePlayer.panelColor;
		oldPlayer.text.color = inactivePlayer.textColor;
	}

	public void SetStartingSides(string startingSide)
	{
		if (isPlayerOne == true) {
			playerSideOne = startingSide;
			if (playerSideOne == "X") {
				playerSideTwo = "O";
				SetPlayerColors (playerX, playerO);
			} else if (playerSideOne == "O") {
				playerSideTwo = "X";
				SetPlayerColors (playerO, playerX);
			}
		} else {
			playerSideTwo = startingSide;
			if (playerSideTwo == "X") {
				playerSideOne = "O";
				SetPlayerColors (playerX, playerO);
			} else if (playerSideTwo == "O") {
				playerSideOne = "X";
				SetPlayerColors (playerO, playerX);
			}
		}




		StartGame ();
	}

	void StartGame()
	{
		ToggleButtonInteractable (true);
		TogglePanelButtons (false);
		startInfo.SetActive (false);
		turnButtonPanel.SetActive (true);
	}

	void ChangeSides()
	{
		//playerSideOne = (playerSideOne == "X") ? "O" : "X";

		whoseSide = (whoseSide == true) ? false : true;

		//if (playerSideOne == "X") {
		if(whoseSide == true){
			if (playerSideOne == "X") {
				SetPlayerColors (playerX, playerO);
			} else {
				SetPlayerColors (playerO, playerX);
			}
			turnButton.text = playerNameOne + "'s Turn";
		} else {
			if (playerSideOne == "X") {
				SetPlayerColors (playerO, playerX);
			} else {
				SetPlayerColors (playerX, playerO);
			}
			turnButton.text = playerNameTwo + "'s Turn";
		}
	}

	public void EndTurn()
	{
		moveCount++;

		if (buttonList [0].text == playerSideOne && buttonList [1].text == playerSideOne && buttonList [2].text == playerSideOne) {
			GameOver (playerSideOne);
		} else if (buttonList [3].text == playerSideOne && buttonList [4].text == playerSideOne && buttonList [5].text == playerSideOne) {
			GameOver (playerSideOne);
		} else if (buttonList [6].text == playerSideOne && buttonList [7].text == playerSideOne && buttonList [8].text == playerSideOne) {
			GameOver (playerSideOne);
		} else if (buttonList [0].text == playerSideOne && buttonList [3].text == playerSideOne && buttonList [6].text == playerSideOne) {
			GameOver (playerSideOne);
		} else if (buttonList [1].text == playerSideOne && buttonList [4].text == playerSideOne && buttonList [7].text == playerSideOne) {
			GameOver (playerSideOne);
		} else if (buttonList [2].text == playerSideOne && buttonList [5].text == playerSideOne && buttonList [8].text == playerSideOne) {
			GameOver (playerSideOne);
		} else if (buttonList [0].text == playerSideOne && buttonList [4].text == playerSideOne && buttonList [8].text == playerSideOne) {
			GameOver (playerSideOne);
		} else if (buttonList [2].text == playerSideOne && buttonList [4].text == playerSideOne && buttonList [6].text == playerSideOne) {
			GameOver (playerSideOne);
		}else if (buttonList [0].text == playerSideTwo && buttonList [1].text == playerSideTwo && buttonList [2].text == playerSideTwo) {
			GameOver (playerSideTwo);
		} else if (buttonList [3].text == playerSideTwo && buttonList [4].text == playerSideTwo && buttonList [5].text == playerSideTwo) {
			GameOver (playerSideTwo);
		} else if (buttonList [6].text == playerSideTwo && buttonList [7].text == playerSideTwo && buttonList [8].text == playerSideTwo) {
			GameOver (playerSideTwo);
		} else if (buttonList [0].text == playerSideTwo && buttonList [3].text == playerSideTwo && buttonList [6].text == playerSideTwo) {
			GameOver (playerSideTwo);
		} else if (buttonList [1].text == playerSideTwo && buttonList [4].text == playerSideTwo && buttonList [7].text == playerSideTwo) {
			GameOver (playerSideTwo);
		} else if (buttonList [2].text == playerSideTwo && buttonList [5].text == playerSideTwo && buttonList [8].text == playerSideTwo) {
			GameOver (playerSideTwo);
		} else if (buttonList [0].text == playerSideTwo && buttonList [4].text == playerSideTwo && buttonList [8].text == playerSideTwo) {
			GameOver (playerSideTwo);
		} else if (buttonList [2].text == playerSideTwo && buttonList [4].text == playerSideTwo && buttonList [6].text == playerSideTwo) {
			GameOver (playerSideTwo);
		}
		else if (moveCount >= 9) {
			GameOver ("draw");
		} else {
			ChangeSides ();
		}
	}

	void GameOver(string winningPlayer)
	{
		ToggleButtonInteractable (false);
		turnButtonPanel.SetActive (false);

		if (winningPlayer == "draw") {
			SetGameOverText ("It is a draw!");
			SetPanelInactive ();
		} else {
			if (winningPlayer == playerSideOne) {
				SetGameOverText (playerNameOne + " Wins!");
			}else {
				SetGameOverText (playerNameTwo + " Wins!");
			}

			if (winningPlayer == playerSideOne) {
				winsPlayerX++;
				playerTextX.text = playerNameOne + " Wins: " + winsPlayerX;
			} else {
				winsPlayerO++;
				playerTextO.text = playerNameTwo + " Wins: " + winsPlayerO;
			}
		}

		gameOverPanel.SetActive (true);

		restartButton.SetActive (true);
	}

	void SetGameOverText(string value)
	{
		gameOverText.text = value;
	}

	public void RestartGame()
	{
		gameOverPanel.SetActive (false);
		moveCount = 0;
		restartButton.SetActive (false);
		SetPanelInactive ();
		TogglePanelButtons (true);
		startInfo.SetActive (true);
		turnButtonPanel.SetActive (false);

		if (isPlayerOne == true) {
			isPlayerOne = false;
			whoseSide = false;
			ToggleStartingSide (isPlayerOne);
		} else {
			isPlayerOne = true;
			whoseSide = true;
			ToggleStartingSide (isPlayerOne);
		}




		for (int i = 0; i < buttonList.Length; i++)
		{
			buttonList [i].text = "";
		}
	
	}

	void ToggleButtonInteractable(bool toggle)
	{
		for (int i = 0; i < buttonList.Length; i++)
		{
			buttonList [i].GetComponentInParent<Button> ().interactable = toggle;
		}
	}

	void SetPanelInactive()
	{
		playerX.panel.color = inactivePlayer.panelColor;
		playerX.text.color = inactivePlayer.textColor;
		playerO.panel.color = inactivePlayer.panelColor;
		playerO.text.color = inactivePlayer.textColor;
	}

	void TogglePanelButtons(bool toggle)
	{
		playerX.button.interactable = toggle;
		playerO.button.interactable = toggle;
	}

	void ToggleStartingSide(bool toggle)
	{
		if (toggle == true) {
			startInfoText.text = playerNameOne + "\r\n" + "Choose A Side!";
			turnButton.text = playerNameOne + "'s Turn";
		} else {
			startInfoText.text = playerNameTwo + "\r\n" + "Choose A Side!";
			turnButton.text = playerNameTwo + "'s Turn";
		}
	}
}
