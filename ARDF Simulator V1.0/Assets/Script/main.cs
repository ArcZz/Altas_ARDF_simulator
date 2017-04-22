using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class main : MonoBehaviour {

    bool window1 = false;
    bool window2 = false;
    bool window3 = false;
    bool shortDistance = true;
    bool cycleControl = false;
    String output;
    int[] goal;
    int goalNum = 5;
    // Use this for initialization
    void Start () {
        Time.timeScale = 0;
        window1 = true;
        goal=new int[5];
        goal[0] = 1;
        goal[1] = 2;
        goal[2] = 3;
        goal[3] = 4;
        goal[4] = 5;
        setGoal(1, 2, 3,4,5);
        setShortDistance(true);//for test
    }
	
	// Update is called once per frame
	void Update () {
		if(GameObject.Find("ReadWrite").GetComponent<ReadWrite>().continuousNull<5)
        {
            GameObject.Find("led2").GetComponent<Image>().color = new Color32(75, 255, 75, 255);//green
        }
        else
        {
            GameObject.Find("led2").GetComponent<Image>().color = new Color32(255, 75, 75, 255);//red
        }
        if (GameObject.Find("ReadWrite").GetComponent<ReadWrite>().Connection)
        {
            GameObject.Find("led1").GetComponent<Image>().color = new Color32(75, 255, 75, 255);//green
        }
        else
        {
            GameObject.Find("led1").GetComponent<Image>().color = new Color32(255, 75, 75, 255);//red
        }
    }

    void OnGUI()
    {
        //Rect windowRect = new Rect(200, 120, 300, 300);
        //GUI.Label(new Rect(40, 20, 480, 30), "v: " + signal.volume + "ang:" + test4);
        if (window1)
        {
            Rect windowRect = new Rect(Screen.width/4, Screen.height / 3, Screen.width/2, Screen.height/3);
            windowRect = GUI.Window(0, windowRect, DoMyWindow1, "Welcome!\n\n\n\nHello! Welcome to Altas™ ARDF Simulator!");
            
        }
        if (window2)
        {
            Rect windowRect = new Rect(Screen.width / 4, Screen.height / 3, Screen.width / 2, Screen.height / 3);
            windowRect = GUI.Window(0, windowRect, DoMyWindow2, "Reminder\n\n\n\nMake sure to find the correct transmitter, \nyou can review this card anytime by press the marker flag button on the left.\nPress the HELP button for more information.");

        }
        if (window3)
        {
            Rect windowRect = new Rect(Screen.width / 4, Screen.height / 3, Screen.width / 2, Screen.height / 3);
            windowRect = GUI.Window(0, windowRect, DoMyWindow3, output);

        }
        
    }



    void DoMyWindow1(int windowID)
    {
        if (GUI.Button(new Rect(Screen.width*9/40, Screen.height/4, Screen.width / 20, Screen.height / 30), "Next"))
        {
            /*
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
*/
            int i;
            for(i=0;i<goalNum;i++)
            {
                GameObject.Find("card").GetComponent<recordCard>().edit(i+1, goal[i]);
            }
            GameObject.Find("card").GetComponent<recordCard>().show();
            window1 = false;
            window2 = true;
            if(!shortDistance)
            {
                GameObject.Find("comp1").GetComponent<compass>().rend(false);
                GameObject.Find("map").GetComponent<mapControl>().rend(false);
            }
        }

    }
    void DoMyWindow2(int windowID)
    {
        if (GUI.Button(new Rect(Screen.width * 9 / 40, Screen.height / 4, Screen.width / 20, Screen.height / 30), "Start!"))
        {

            GameObject.Find("timingPrompter").GetComponent<AudioSource>().Play(50000);
            Time.timeScale = 1;
            window2 = false;
            StartCoroutine(release(5f));
        }

    }
    void DoMyWindow3(int windowID)
    {
        if (GUI.Button(new Rect(Screen.width * 9 / 40, Screen.height / 4, Screen.width / 20, Screen.height / 30), "Exit"))
        {

            
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif

        }

    }
    

    IEnumerator release(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameObject.Find("startLineRestrict1").GetComponent<BoxCollider>().enabled = false;
        GameObject.Find("startLineRestrict2").GetComponent<BoxCollider>().enabled = false;
        turnOn();
    }

    public bool setGoal(int g1)
    {
        if (g1 < 0 || g1 > 9 )
        {
            return false;
        }
        goal[0] = g1;
        goalNum = 1;
        return true;
    }
    public bool setGoal(int g1, int g2)
    {
        if (g1 < 0 || g1 > 9 || g2 < 0 || g2 > 9 )
        {
            return false;
        }
        goal[0] = g1;
        goal[1] = g2;
        goalNum = 2;
        return true;
    }
    public bool setGoal(int g1, int g2, int g3)
    {
        if (g1 < 0 || g1 > 9 || g2 < 0 || g2 > 9 || g3 < 0 || g3 > 9 )
        {
            return false;
        }
        goal[0] = g1;
        goal[1] = g2;
        goal[2] = g3;
        goalNum = 3;
        return true;
    }
    public bool setGoal(int g1, int g2, int g3, int g4)
    {
        if (g1 < 0 || g1 > 9 || g2 < 0 || g2 > 9 || g3 < 0 || g3 > 9 || g4 < 0 || g4 > 9 )
        {
            return false;
        }
        goal[0] = g1;
        goal[1] = g2;
        goal[2] = g3;
        goal[3] = g4;
        goalNum = 4;
        return true;
    }
    public bool setGoal(int g1, int g2, int g3, int g4, int g5)
    {
        if(g1<0 || g1>9 || g2 < 0 || g2 > 9 || g3 < 0 || g3 > 9 || g4 < 0 || g4 > 9 || g5 < 0 || g5 > 9 )
        {
            return false;
        }
        goal[0] = g1;
        goal[1] = g2;
        goal[2] = g3;
        goal[3] = g4;
        goal[4] = g5;
        goalNum = 5;
        return true;
    }

    public void setShortDistance(bool d)
    {
        shortDistance = d;
    }

    public void finish()
    {
        turnOff();
        List<int> IDRecord = GameObject.Find("punchRecord").GetComponent<punchRecord>().getIDRecord();
        List<DateTime> timeRecord = GameObject.Find("punchRecord").GetComponent<punchRecord>().getTimeRecord();
        int l = IDRecord.Count;
        if (timeRecord.Count != l)
        {
            Debug.Log("error!");
            return;
        }
        DateTime start = DateTime.Now, finish = DateTime.Now;
        bool isStart = false, isFinish = false;
        output = "result:\n";
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
        if (isStart == false || isFinish == false)
        {
            output = "Time Error!";
        }
        else
        {
            if (DateTime.Compare(start, finish) >= 0)
            {
                output = "Time Error!";
            }
            else
            {
                TimeSpan usage = finish.Subtract(start);
                output += "\nTime usage:\t" + usage.ToString();
            }
        }
        window3 = true;
        return;
    }

    void turnOn()
    {
        if(shortDistance)
        {
            //SendMessage("switchPowerOn", true);
            int i;
            for (i = 0; i <= 9; i++)
            {
                String t = "transmitter" + i;
                if (GameObject.Find(t) != null)
                {
                    GameObject.Find(t).GetComponent<Transmitter>().setShortDistance(true);
                    GameObject.Find(t).GetComponent<Transmitter>().switchPowerOn(true);
                }
            }
            if (GameObject.Find("transmitterMO") != null)
            {
                GameObject.Find("transmitterMO").GetComponent<Transmitter>().setShortDistance(true);
                GameObject.Find("transmitterMO").GetComponent<Transmitter>().switchPowerOn(true);
            }
            else
            {
                Debug.Log("no MO!");
            }

        }
        else
        {
            int i;
            for (i = 1; i <= 5; i++)
            {
                String t = "transmitter" + i;
                if (GameObject.Find(t) != null)
                {
                    GameObject.Find(t).GetComponent<Transmitter>().setShortDistance(false);
                }
            }
            if (GameObject.Find("transmitterMO") != null)
            {
                GameObject.Find("transmitterMO").GetComponent<Transmitter>().setShortDistance(false);
                GameObject.Find("transmitterMO").GetComponent<Transmitter>().switchPowerOn(true);
            }
            cycleControl = true;
            StartCoroutine(cycle());
        }
    }

    void turnOff()
    {
        if (shortDistance)
        {
            int i;
            for (i = 0; i <= 9; i++)
            {
                String t = "transmitter" + i;
                if (GameObject.Find(t) != null)
                {
                    GameObject.Find(t).GetComponent<Transmitter>().switchPowerOn(false);
                }
            }
            if (GameObject.Find("transmitterMO") != null)
            {
                GameObject.Find("transmitterMO").GetComponent<Transmitter>().switchPowerOn(false);
            }

        }
        else
        {
            cycleControl = false;
            int i;
            for (i = 1; i <= 5; i++)
            {
                String t = "transmitter" + i;
                if (GameObject.Find(t) != null)
                {
                    GameObject.Find(t).GetComponent<Transmitter>().switchPowerOn(false);
                }
            }
            if (GameObject.Find("transmitterMO") != null)
            {
                GameObject.Find("transmitterMO").GetComponent<Transmitter>().switchPowerOn(false);
            }
        }
    }

    IEnumerator cycle()
    {

        
        int i;
        for (i = 0;cycleControl ; i=(i+1)%5)
        {
            String t = "transmitter" + (i+1);
            if (GameObject.Find(t) != null)
            {
                GameObject.Find(t).GetComponent<Transmitter>().switchPowerOn(true);
                yield return new WaitForSeconds(60f);
                GameObject.Find(t).GetComponent<Transmitter>().switchPowerOn(false);
            }
            else
            {
                Debug.Log(t + " missing!");
            }
        }
    }
    public bool getShortDistance()
    {
        return shortDistance;
    }
}
