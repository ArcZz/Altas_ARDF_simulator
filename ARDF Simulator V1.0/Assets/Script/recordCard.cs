using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class recordCard : MonoBehaviour {

    int moveSpeed=0;

	// Use this for initialization
	void Start () {
        this.transform.position = this.transform.position + Vector3.up * (int)(Screen.height * 0.4);
        transform.Find("tar1").GetComponent<Text>().text = " ";
        transform.Find("tar2").GetComponent<Text>().text = " ";
        transform.Find("tar3").GetComponent<Text>().text = " ";
        transform.Find("tar4").GetComponent<Text>().text = " ";
        transform.Find("tar5").GetComponent<Text>().text = " ";
        transform.Find("tick1").GetComponent<Text>().text = " ";
        transform.Find("tick2").GetComponent<Text>().text = " ";
        transform.Find("tick3").GetComponent<Text>().text = " ";
        transform.Find("tick4").GetComponent<Text>().text = " ";
        transform.Find("tick5").GetComponent<Text>().text = " ";
        transform.Find("error").GetComponent<Text>().text = " ";
        //show();
        //edit(1, 2);
        //check(3);
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.position = Vector3.Lerp(this.transform.position, this.transform.position + Vector3.up * moveSpeed, 1);
        if(this.transform.position.y<Screen.height*0.8 || this.transform.position.y>Screen.height*1.2)
        {
            moveSpeed = 0;
        }
    }

    public void show()
    {
        //Debug.Log("show");
        StartCoroutine(showI());
    }

    /*
    void OnGUI()
    {
        GUI.Label(new Rect(40, 20, 480, 30), "h:" + this.transform.position.y);
    }
    */

    IEnumerator showI()
    {
        moveSpeed = -Screen.width/80;
        yield return new WaitForSeconds(3f);
        moveSpeed = Screen.width / 80;
    }

    public void edit(int no,int transmitterID)
    {
        //Debug.Log(transmitterID);
        if (no <= 5 && no >= 1 && transmitterID <= 9 && transmitterID >= 0)
        {
            string s = "tar" + no;
            transform.Find(s).GetComponent<Text>().text = transmitterID.ToString();
        }
        else
        {
            Debug.Log("error!");
        }
    }

    public void check(int transmitterID)
    {
        int i;
        for(i=1;i<=5;i++)
        {
            //Debug.Log(i);
            if (transform.Find("tar" + i).GetComponent<Text>().text.Equals(transmitterID.ToString()))
            {
                if (transform.Find("tick" + i).GetComponent<Text>().text.Equals(" "))
                {
                    StartCoroutine(checkI(i));
                }
                else
                {
                    show();
                    
                }
                break;
            }
            
        }
        if(i==6)
        {
            StartCoroutine(checkI(-1));
        }
    }

    IEnumerator checkI(int no)
    {
        moveSpeed = -Screen.width / 80;
        yield return new WaitForSeconds(1.5f);
        if(no==-1)
        {
            transform.Find("error").GetComponent<Text>().text += "x ";
        }
        else
        {
            transform.Find("tick" + no).GetComponent<Text>().text = "v";
        }
        
        yield return new WaitForSeconds(1.5f);
        moveSpeed = Screen.width / 80;
    }
}
