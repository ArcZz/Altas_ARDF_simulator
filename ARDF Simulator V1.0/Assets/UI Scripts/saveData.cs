using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class saveData : MonoBehaviour {

	public Text ip;
	public Text name;
	public Text cmo;
	public Toggle online;
	public Slider ony;

	public void save(){
		

	
		if (ip.text.Equals ("")) {	
			
		} else {
			GameControl.control.ip = ip.text;
		}
		if (name.text.Equals ("")) {	
			
		} else {
			GameControl.control.name = name.text;
		}
		if (cmo.text.Equals ("")) {	
			
		} else {
			GameControl.control.cmo = cmo.text;
		}
		GameControl.control.online = online.isOn;
		GameControl.control.y = ony.value;
	

		GameControl.control.Save ();
	}
}