using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class saveData : MonoBehaviour {

	public Text ip;
	public Text name;
	public Toggle online;


	public void save(){
		
		if (ip.text != ""){
		GameControl.control.ip = ip.text;
		GameControl.control.name = name.text;
		GameControl.control.online = online.isOn;

		Debug.Log (GameControl.control.ip);

		
		}



	}
}