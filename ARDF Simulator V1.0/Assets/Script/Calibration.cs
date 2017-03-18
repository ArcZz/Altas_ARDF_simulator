using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calibration : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.transform.localRotation = Quaternion.Euler(90, 0, 35);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
