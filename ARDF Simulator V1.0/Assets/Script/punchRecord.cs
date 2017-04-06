using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punchRecord : MonoBehaviour {

    bool test = false;

    List<int> IDRecord;
    List<DateTime> timeRecord;

	// Use this for initialization
	void Start () {
        IDRecord = new List<int>();
        timeRecord = new List<DateTime>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void punch(int puncherID)
    {
        IDRecord.Add(puncherID);
        timeRecord.Add(DateTime.Now);
        if (puncherID == -1)
        {
            GameObject.Find("Clock").GetComponent<Timer>().startTimer();
        }
        if (puncherID == -2)
        {
            GameObject.Find("Clock").GetComponent<Timer>().stopTimer();
        }
        if (puncherID == -3)
        {
            IDRecord.Clear();
            timeRecord.Clear();
        }
        if (puncherID==-4)
        {
            GameObject.Find("mainControl").GetComponent<main>().finish();
            //test = true;
        }
    }

    String getResult()
    {
        int l = IDRecord.Count;
        if (timeRecord.Count != l)
        {
            Debug.Log("error!");
            return "error!";
        }
        DateTime start = DateTime.Now, finish=DateTime.Now;
        bool isStart=false, isFinish=false;
        String output = "result:\n";
        int i;
        for (i = 0; i < l; i++)
        {
            if (IDRecord[i] == -1)
            {
                isStart = true;
                start = timeRecord[i];                
                continue;
            }
            if (IDRecord[i] == -2)
            {
                isFinish = true;
                finish = timeRecord[i];
                continue;
            }
            if (IDRecord[i] == -4)
            {
                continue;
            }

            output += IDRecord[i] + "\t" + timeRecord[i].ToString() + "\n";
        }
        if(isStart==false || isFinish==false)
        {
            output = "Time Error!";
        }
        else
        {
            if(DateTime.Compare(start,finish)>=0)
            {
                output = "Time Error!";
            }
            else
            {
                TimeSpan usage = finish.Subtract(start);
                output += "\nTime usage:\t" + usage.ToString();
            }
        }
        return output;
    }


    void OnGUI()
    {
        Rect windowRect = new Rect(200, 120, 300, 300);
        //GUI.Label(new Rect(40, 20, 480, 30), "v: " + signal.volume + "ang:" + test4);
        if (test)
        {
            
            windowRect = GUI.Window(0, windowRect, DoMyWindow, getResult());
        }
    }
    void DoMyWindow(int windowID)
    {
        if (GUI.Button(new Rect(70, 240, 100, 20), "Exit"))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
	            Application.Quit ();
#endif
        }

    }
    public List<int> getIDRecord()
    {
        return IDRecord;
    }
    public List<DateTime> getTimeRecord()
    {
        return timeRecord;
    }
    
}
