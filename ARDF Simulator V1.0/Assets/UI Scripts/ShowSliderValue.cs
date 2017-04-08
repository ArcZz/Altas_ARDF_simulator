using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowSliderValue : MonoBehaviour
{
	public Slider showText;
	public float value;
	public Text label;

	public void Update(){
		Debug.Log (value);
		value = showText.value;
		label.text = value.ToString();

	}

}
