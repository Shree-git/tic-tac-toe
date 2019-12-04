using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour {

	public Button button;
	public Text buttonText;

	private GameController gameController;

	public void SetSpace()
	{
		if (gameController.whoseSide == true) {
			buttonText.text = gameController.playerSideOne;
			button.interactable = false;
			gameController.EndTurn ();
		} else {
			buttonText.text = gameController.playerSideTwo;
			button.interactable = false;
			gameController.EndTurn ();
		}
	}

	public void SetGameControllerReference(GameController controller)
	{
		gameController = controller;
	}
}
