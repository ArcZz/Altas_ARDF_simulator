using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class saveController : MonoBehaviour {

	public Slider mainSlider;


	public void save(){

		if (mainSlider.value != 0){
			GameControl.control.y = mainSlider.value;

			Debug.Log (GameControl.control.y);


		}



	}
}
