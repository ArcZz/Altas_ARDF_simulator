using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {



	public void LoadByIndex(int sceneIndex)
	{

		Debug.Log (sceneIndex);
		SceneManager.LoadScene (sceneIndex);

	}
}
