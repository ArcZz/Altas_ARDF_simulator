using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour {

	public Slider mainSlider;
	// Use this for initialization
	public void SubmitSliderSetting()
	{

		Debug.Log(mainSlider.value);
		GameControl.control.Save();
	}
}

