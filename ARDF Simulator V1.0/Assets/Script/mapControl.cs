using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapControl : MonoBehaviour {

    int statu = 1;
    //bool enable=false;

	// Use this for initialization
	void Start () {
        rend(true);
	}
	
	// Update is called once per frame
	void Update () {
		if(statu==0)
        {
            transform.localRotation = Quaternion.Euler(1.732f, 0, 0);
            transform.localPosition = new Vector3(0, 0, 0);
        }
        else if(statu==1)
        {
            transform.localRotation = Quaternion.Euler(1.732f, 180 - transform.root.rotation.eulerAngles.y, 0);
            transform.localPosition = new Vector3(0, 0, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(90, 0, 0);
            transform.localPosition = new Vector3(0.111f, 0.631f, 0.66f);
            //transform.Translate();
        }
        //localRotation = Quaternion.Euler(0, 360 - transform.root.rotation.eulerAngles.y, 0);
    }

    public void changeView()
    {
        statu = (statu + 1) % 3;
    }



    public void rend()
    {
        if(GameObject.Find("mainControl").GetComponent<main>().getShortDistance())
        {
            return;
        }
        Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            r.enabled = !r.enabled;
        }

    }

    public void rend(bool isHidden)
    {
        if (GameObject.Find("mainControl").GetComponent<main>().getShortDistance() && !isHidden)
        {
            return;
        }
        Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            r.enabled = !isHidden;
        }
    }
}
