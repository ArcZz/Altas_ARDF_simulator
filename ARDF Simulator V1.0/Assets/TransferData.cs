using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;





public class TransferData : MonoBehaviour {
	
	public Dropdown dropdown;
	public Dropdown Length;
	public Dropdown sounds;
	public Dropdown num1;
	public Dropdown num2;
	public Dropdown num3;
	public Dropdown num4;
	public Dropdown num5;
	public GameObject n1;
	public GameObject n2;
	public GameObject n3;
	public GameObject n4;
	public GameObject n5;

	public void godata(){
		GameControl.control.numM = dropdown.value;
		GameControl.control.length = Length.value;
		GameControl.control.sounds = sounds.value;
			GameControl.control.num1 = num1.value;
			GameControl.control.num2 = num2.value;
			GameControl.control.num3 = num3.value;
			GameControl.control.num4 = num4.value;
			GameControl.control.num5 = num5.value;						
			Debug.Log (dropdown.value);
		Debug.Log ("1 shows" + GameControl.control.num1);
		Debug.Log ("2 shows" + GameControl.control.num2);
		Debug.Log ("3 shows" + GameControl.control.num3);
		Debug.Log ("4 shows" + GameControl.control.num4);
		Debug.Log ("5 shows" + GameControl.control.num5);

			
	}
	public void change(){

		Debug.Log (sounds.value); 

		switch (sounds.value)
		{
		//5
		case 4: 
			
			n1.SetActive (true);
			n2.SetActive (true);
			n3.SetActive (true);
			n4.SetActive (true);
			n5.SetActive (true);
			break;
		//4
		case 3:
			n1.SetActive (true);
			n2.SetActive (true);
			n3.SetActive (true);
			n4.SetActive (true);
			n5.SetActive (false);

			break;
		//3
		case 2:
			n1.SetActive (true);
			n2.SetActive (true);
			n3.SetActive (true);
			n4.SetActive (false);
			n5.SetActive (false);
			break;
		//2
		case 1:
			n1.SetActive (true);
			n2.SetActive (true);
			n3.SetActive (false);
			n4.SetActive (false);
			n5.SetActive (false);
			break;
		default:
			n1.SetActive (true);
			n2.SetActive (false);
			n3.SetActive (false);
			n4.SetActive (false);
			n5.SetActive (false);
			break;
		}
	}
}
