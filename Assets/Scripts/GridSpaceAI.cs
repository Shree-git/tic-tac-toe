using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpaceAI : MonoBehaviour {

	public Button button;
	public Text buttonText;

	private GameControllerAI gameController;

	public void SetSpace()
	{
		if (gameController.playerTurn == true) {
			buttonText.text = gameController.playerSide;
			button.interactable = false;
			gameController.EndTurn ();
		} 
		/*else {
			buttonText.text = gameController.computerSide;
			button.interactable = false;
			gameController.EndTurn ();
		}
		*/
	}

	public void SetGameControllerReference(GameControllerAI controller)
	{
		gameController = controller;
	}
}
