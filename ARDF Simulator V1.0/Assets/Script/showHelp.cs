using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showHelp : MonoBehaviour {

    private bool enable = false;

	// Use this for initialization
	void Start () {
        //rend(false);
        //rend();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void rend()
    {
        //gameObject.GetComponent<Renderer>().enabled= !gameObject.GetComponent<Renderer>().enabled;
        //gameObject.SetActive(false);
        enable = !enable;
        if (enable)
        {
            //transform.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            //GameObject.Find("dark").GetComponent<Image>().color = new Color32(0, 0, 0, 157);
            gameObject.SetActive(true);
            //GameObject.Find("dark").SetActive(true);
            //this.gameObject.SetActive(true);
        }
        else
        {
            //transform.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
            //GameObject.Find("dark").GetComponent<Image>().color = new Color32(0, 0, 0, 0);
            //GameObject.Find("dark").gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    /*
    public void rend(bool isHidden)
    {
        gameObject.GetComponent<Renderer>().enabled = !isHidden;
    }
    */
}
