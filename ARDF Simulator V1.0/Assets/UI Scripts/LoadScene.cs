using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {


	public void LoadByIndex(int sceneIndex)
	{
		
	

		if(sceneIndex == 1)
		{
			
		

		}
		SceneManager.LoadScene (sceneIndex);

	}
}
