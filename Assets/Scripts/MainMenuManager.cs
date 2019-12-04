using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {


	public GameObject OneVOne;
	public GameObject OneVComputer;
	public GameObject playerNamesPanel;

	public InputField playerOne;
	public InputField playerTwo;

	public static string playerOneName;
	public static string playerTwoName;

	//private TouchScreenKeyboard keyboard;

	void Awake()
	{
		//DontDestroyOnLoad (this);
		playerNamesPanel.SetActive (false);
	}

	public void OnPressOneVOne()
	{
		playerNamesPanel.SetActive (true);

		//keyboard = TouchScreenKeyboard.Open ("", TouchScreenKeyboardType.Default, false, false, true, true);

		OneVOne.GetComponent<Button> ().interactable = false;
		OneVComputer.GetComponent<Button> ().interactable = false;
	}



	public void OnPressBack()
	{
		playerNamesPanel.SetActive (false);
		OneVOne.GetComponent<Button> ().interactable = true;
		OneVComputer.GetComponent<Button> ().interactable = true;
	}
		

	public void OnNameOneEnter(){
		playerOneName = playerOne.text;
	}

	public void OnNameTwoEnter(){
		playerTwoName = playerTwo.text;
	}

}
