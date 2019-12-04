using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerAI
{
	public Image panel;
	public Text text;
	public Button button;
}

[System.Serializable]
public class PlayerColorAI
{
	public Color panelColor;
	public Color textColor;
}

public class GameControllerAI : MonoBehaviour {

	public Text[] buttonList;

	public string playerSide;
	public string computerSide;
	public bool playerTurn;
	public float delay;
	private int value;
	public int delayValue;

	private int moveCount;

	public GameObject gameOverPanel;
	public Text gameOverText;

	public GameObject restartButton;
	public GameObject startInfo;

	public PlayerAI playerX;
	public PlayerAI playerO;
	public PlayerColorAI activePlayer;
	public PlayerColorAI inactivePlayer;

	public Text playerTextX;
	public Text playerTextO;
	private static int winsPlayerX;
	private static int winsPlayerO;




	void Awake()
	{
		gameOverPanel.SetActive (false);
		SetGameControllerReferenceOnButtons ();
		moveCount = 0;
		restartButton.SetActive (false);
		startInfo.SetActive (true);

		playerTurn = true;

		winsPlayerX = 0;
		winsPlayerO = 0;
	}

	void Update()
	{
		if (playerTurn == false) {
			delay += delay * Time.deltaTime;

			if (delay >= 100) {
				value = Random.Range (0, 8);

				if (buttonList [value].GetComponentInParent<Button> ().interactable == true) {
					buttonList [value].text = computerSide;
					buttonList [value].GetComponentInParent<Button> ().interactable = false;
					EndTurn ();
				}
			}
		}
	}

	void SetGameControllerReferenceOnButtons()
	{
		for (int i = 0; i < buttonList.Length; i++) 
		{
			buttonList [i].GetComponentInParent<GridSpaceAI> ().SetGameControllerReference (this);
		}
	}

	void SetPlayerColors(PlayerAI newPlayer, PlayerAI oldPlayer)
	{
		newPlayer.panel.color = activePlayer.panelColor;
		newPlayer.text.color = activePlayer.textColor;
		oldPlayer.panel.color = inactivePlayer.panelColor;
		oldPlayer.text.color = inactivePlayer.textColor;
	}

	public void SetStartingSides(string startingSide)
	{
		playerSide = startingSide;

		if (playerSide == "X") {
			computerSide = "O";
			SetPlayerColors (playerX, playerO);
		} else {
			computerSide = "X";
			SetPlayerColors (playerO, playerX);
		}

		StartGame ();
	}

	void StartGame()
	{
		ToggleButtonInteractable (true);
		TogglePanelButtons (false);
		startInfo.SetActive (false);
	}

	void ChangeSides()
	{
		//playerSide = (playerSide == "X") ? "O" : "X";

		playerTurn = (playerTurn == true) ? false : true;

		//if (playerSide == "X") {
		if(playerTurn == true){
			if (playerSide == "X") {
				SetPlayerColors (playerX, playerO);
			} else {
				SetPlayerColors (playerO, playerX);
			}
		} else {
			if (playerSide == "X") {
				SetPlayerColors (playerO, playerX);
			} else {
				SetPlayerColors (playerX, playerO);
			}
		}
	}

	public void EndTurn()
	{
		moveCount++;

		if (buttonList [0].text == playerSide && buttonList [1].text == playerSide && buttonList [2].text == playerSide) {
			GameOver (playerSide);
		} else if (buttonList [3].text == playerSide && buttonList [4].text == playerSide && buttonList [5].text == playerSide) {
			GameOver (playerSide);
		} else if (buttonList [6].text == playerSide && buttonList [7].text == playerSide && buttonList [8].text == playerSide) {
			GameOver (playerSide);
		} else if (buttonList [0].text == playerSide && buttonList [3].text == playerSide && buttonList [6].text == playerSide) {
			GameOver (playerSide);
		} else if (buttonList [1].text == playerSide && buttonList [4].text == playerSide && buttonList [7].text == playerSide) {
			GameOver (playerSide);
		} else if (buttonList [2].text == playerSide && buttonList [5].text == playerSide && buttonList [8].text == playerSide) {
			GameOver (playerSide);
		} else if (buttonList [0].text == playerSide && buttonList [4].text == playerSide && buttonList [8].text == playerSide) {
			GameOver (playerSide);
		} else if (buttonList [2].text == playerSide && buttonList [4].text == playerSide && buttonList [6].text == playerSide) {
			GameOver (playerSide);
		}else if (buttonList [0].text == computerSide && buttonList [1].text == computerSide && buttonList [2].text == computerSide) {
			GameOver (computerSide);
		} else if (buttonList [3].text == computerSide && buttonList [4].text == computerSide && buttonList [5].text == computerSide) {
			GameOver (computerSide);
		} else if (buttonList [6].text == computerSide && buttonList [7].text == computerSide && buttonList [8].text == computerSide) {
			GameOver (computerSide);
		} else if (buttonList [0].text == computerSide && buttonList [3].text == computerSide && buttonList [6].text == computerSide) {
			GameOver (computerSide);
		} else if (buttonList [1].text == computerSide && buttonList [4].text == computerSide && buttonList [7].text == computerSide) {
			GameOver (computerSide);
		} else if (buttonList [2].text == computerSide && buttonList [5].text == computerSide && buttonList [8].text == computerSide) {
			GameOver (computerSide);
		} else if (buttonList [0].text == computerSide && buttonList [4].text == computerSide && buttonList [8].text == computerSide) {
			GameOver (computerSide);
		} else if (buttonList [2].text == computerSide && buttonList [4].text == computerSide && buttonList [6].text == computerSide) {
			GameOver (computerSide);
		}
		else if (moveCount >= 9) {
			GameOver ("draw");
		} else {
			ChangeSides ();
			ReturnDelay ();
		}
	}

	void GameOver(string winningPlayer)
	{
		ToggleButtonInteractable (false);

		if (winningPlayer == "draw") {
			SetGameOverText ("It is a draw!");
			SetPanelInactive ();
		} else {
			if (winningPlayer == playerSide) {
				SetGameOverText ("Player Wins!");
			}else {
				SetGameOverText ("Computer Wins!");
			}

			if (winningPlayer == playerSide) {
				winsPlayerX++;
				playerTextX.text = "Player Wins: " + winsPlayerX;
			} else {
				winsPlayerO++;
				playerTextO.text = "Computer Wins: " + winsPlayerO;
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

		playerTurn = true;
		ReturnDelay ();

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

	float ReturnDelay()
	{
		delay = delayValue;
		return delay;
	}
}
