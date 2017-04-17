using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class saveData : MonoBehaviour {

	public Text ip;
	public Text name;
	//public Toggle check;
	//public boolean check;

	public void save(){
		

		GameControl.control.ip = ip.text;
		GameControl.control.name = name.text;
		//GameControl.control.check = check.isOn;

		//Debug.Log (GameControl.control.check);
		GameControl.control.Save ();
	}



}
