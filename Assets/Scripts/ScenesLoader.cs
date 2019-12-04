using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesLoader : MonoBehaviour {

	public void LoadMainMenu()
	{
		SceneManager.LoadScene (0);
	}

	public void LoadOneVOne()
	{
		SceneManager.LoadScene (1);
	}

	public void LoadOneVComputer()
	{
		SceneManager.LoadScene (2);
	}
}
