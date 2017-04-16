using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {


	public void LoadByIndex(int sceneIndex)
	{
		int a = GameControl.control.a;
		string b = "Guo";
		int c = GameControl.control.b;

		if(sceneIndex == 1)
		{
			//Data.DataObject data = new Data.DataObject(a,b,c);
		
			Debug.Log (GameControl.control.a);
			Debug.Log (GameControl.control.b);
		}
		SceneManager.LoadScene (sceneIndex);

	}
}
