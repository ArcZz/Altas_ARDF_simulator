using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    //DateTime start;
    int duration;
    DateTime dest;

    bool running=false;

    // Use this for initialization
    void Start () {
        setTimer(120);
        //startTimer();//test
        String disp;
        TimeSpan temp =new TimeSpan(0, duration, 0);
        if (temp.Milliseconds < 500)
        {
            if (temp.Hours == 0)
            {
                disp = Mathf.Abs(temp.Minutes).ToString("00") + ":" + Mathf.Abs(temp.Seconds).ToString("00") + ":" + (Mathf.Abs(temp.Milliseconds) / 10).ToString("00");
            }
            else
            {
                disp = Mathf.Abs(temp.Hours).ToString("00") + ":" + Mathf.Abs(temp.Minutes).ToString("00") + ":" + Mathf.Abs(temp.Seconds).ToString("00");
            }
            transform.GetComponent<Text>().text = disp;
        }

    }
	
	// Update is called once per frame
	void Update () {
        TimeSpan temp = dest.Subtract(DateTime.Now);
        //test = temp;
        String disp;
        if (running)
        {
            if (temp.Milliseconds < 500)
            {
                if (temp.Hours == 0)
                {
                    disp = Mathf.Abs(temp.Minutes).ToString("00") + ":" + Mathf.Abs(temp.Seconds).ToString("00") + ":" + (Mathf.Abs(temp.Milliseconds) / 10).ToString("00");
                }
                else
                {
                    disp = Mathf.Abs(temp.Hours).ToString("00") + ":" + Mathf.Abs(temp.Minutes).ToString("00") + ":" + Mathf.Abs(temp.Seconds).ToString("00");
                }
            }
            else
            {
                if (temp.Hours == 0)
                {
                    disp = Mathf.Abs(temp.Minutes).ToString("00") + " " + Mathf.Abs(temp.Seconds).ToString("00") + " " + (Mathf.Abs(temp.Milliseconds) / 10).ToString("00");
                }
                else
                {
                    disp = Mathf.Abs(temp.Hours).ToString("00") + " " + Mathf.Abs(temp.Minutes).ToString("00") + " " + Mathf.Abs(temp.Seconds).ToString("00");
                }
            }
            transform.GetComponent<Text>().text = disp;
        }
        //test = disp;
        //transform.Find("IDtext").GetComponent<TextMesh>().text = te;
        
        
    }

    /*
    void OnGUI()
    {
        GUI.Label(new Rect(40, 20, 480, 30), "time:"+test);
    }
    */

    public void setTimer(int duration)
    {
        this.duration = duration;
    }

    public void startTimer()
    {
        //this.duration = duration;
        //start = DateTime.Now;
        dest= DateTime.Now.AddMinutes(duration);
        running = true;
    }

    public void stopTimer()
    {
        running = false;
    }
}
