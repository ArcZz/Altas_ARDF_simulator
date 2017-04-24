using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calibration2 : MonoBehaviour {

    //Slider sl;

	// Use this for initialization
	void Start () {
        //sl = GameObject.Find("GameControl").GetComponent<GameControl>().myY;
        float cal = GameObject.Find("GameControl").GetComponent<GameControl>().y;
        this.transform.localRotation = Quaternion.Euler(90, 0, cal);
    }
	
	// Update is called once per frame
	void Update () {
        //this.transform.localRotation = Quaternion.Euler(90, 0, sl.value);
    }
}
