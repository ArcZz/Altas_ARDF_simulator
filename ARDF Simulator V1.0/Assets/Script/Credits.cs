using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {
    public GameObject mainscene;
    public GameObject showscene;
    public GameObject showback;
    public Vector3 init;
    float moveSpeed = 1.5f;
    // Use this for initialization
    void Start () {
        init = this.transform.localPosition;
        Debug.Log(init);
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = Vector3.Lerp(this.transform.position, this.transform.position + Vector3.up * moveSpeed, 1);
        if(Input.anyKeyDown)
        {
            mainscene.SetActive(true);
            showscene.SetActive(false);
            showback.SetActive(false);
            this.transform.localPosition = init;



        }
    }
}
