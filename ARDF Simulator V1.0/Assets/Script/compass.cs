using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compass : MonoBehaviour {

	// Use this for initialization
    
	void Start () {
        rend(true);
	}
	
	// Update is called once per frame
	void Update () {
        //Vector3 v = new Vector3(0, 90, 0);
        transform.Find("comp2").transform.localRotation = Quaternion.Euler(0, 360 - transform.root.rotation.eulerAngles.y, 0);
        //transform.Find("comp2").rotation = Quaternion.Euler(0, 0, this.transform.rotation.eulerAngles.z)*this.transform.rotation;
        //Debug.Log(this.transform.rotation.eulerAngles.y);
        
    }

    public void rend()
    {
        Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            r.enabled = !r.enabled;
        }

    }

    public void rend(bool isHidden)
    {
        Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            r.enabled = !isHidden;
        }
    }
}
