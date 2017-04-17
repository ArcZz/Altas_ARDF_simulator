using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {


	public void LoadByIndex(int sceneIndex)
	{
		
		string b = "Guo";
		int c = GameControl.control.numT;

		if(sceneIndex == 1)
		{
			
		

		}
		SceneManager.LoadScene (sceneIndex);

	}
}
