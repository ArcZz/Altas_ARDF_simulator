using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PJ80 : MonoBehaviour {

    // Use this for initialization
    //private string mes;
    private Boolean antenna;
    private int volKnob;
    private int freqKnob;
    private Animator anmi;
    public float whipAntennaLength=2;

    void Start () {
        //string test = ReadWrite.get();

        //Debug.Log("OK2");
        antenna = false;
        freqKnob = 0xd0;
        volKnob = 0xff;
        //anmi = GetComponent<Animator>();
        anmi = GameObject.Find("antenna").GetComponent<Animator>();
        anmi.speed = 4;
    }
	
	// Update is called once per frame
	void Update () {
        int r_q0 = Int32.Parse(ReadWrite.mes.Substring(20, 4), System.Globalization.NumberStyles.HexNumber);
        int r_q1 = Int32.Parse(ReadWrite.mes.Substring(24, 4), System.Globalization.NumberStyles.HexNumber);
        int r_q2 = Int32.Parse(ReadWrite.mes.Substring(28, 4), System.Globalization.NumberStyles.HexNumber);
        int r_q3 = Int32.Parse(ReadWrite.mes.Substring(32, 4), System.Globalization.NumberStyles.HexNumber);

        //Debug.Log(r_q3);
        r_q0 = r_q0 << 16;
        if (r_q0 < 0)
        {
            r_q0 = r_q0 | 65535;
        }
        r_q0 = r_q0 / 65536;
        r_q1 = r_q1 << 16;
        if (r_q1 < 0)
        {
            r_q1 = r_q1 | 65535;
        }
        r_q1 = r_q1 / 65536;
        r_q2 = r_q2 << 16;
        if (r_q2 < 0)
        {
            r_q2 = r_q2 | 65535;
        }
        r_q2 = r_q2 / 65536;
        r_q3 = r_q3 << 16;
        if (r_q3 < 0)
        {
            r_q3 = r_q3 | 65535;
        }
        r_q3 = r_q3 / 65536;
        double q0 = r_q0 / 10000.0;
        double q1 = r_q1 / 10000.0;
        double q2 = r_q2 / 10000.0;
        double q3 = r_q3 / 10000.0;
  
        Quaternion t= new Quaternion((float)q1, (float)q2, (float)q3, (float)q0);
        t=t* Quaternion.Euler(0, 0, 0);
        //Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        this.transform.localRotation = t;
        //Debug.Log("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb");
        this.transform.Rotate(0, 90, -90, Space.Self);
        //Debug.Log("cccccccccccccccccccccccccccccccccccc");

        int s1 = Int32.Parse(ReadWrite.mes.Substring(1, 1), System.Globalization.NumberStyles.HexNumber);
        if(s1==1)
        {
            GameObject.Find("S1").GetComponent<MeshFilter>().transform.localPosition = new Vector3((float)0.0238, (float)0.0366, 0);
            if(antenna!=true)
            {
                anmi.Play("up", -1, 0f);
            }
            antenna = true;
            
        }
        else
        {
            GameObject.Find("S1").GetComponent<MeshFilter>().transform.localPosition = new Vector3((float)0.0272, (float)0.0366, 0);
            if (antenna != false)
            {
                anmi.Play("down", -1, 0f);
            }
            antenna = false;
        }

        freqKnob = Int32.Parse(ReadWrite.mes.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
        volKnob = Int32.Parse(ReadWrite.mes.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        GameObject.Find("frequencyKnob").transform.localRotation = Quaternion.Euler(-315*freqKnob/0xff-140, 0, 90);
        GameObject.Find("volumeKnob").transform.localRotation = Quaternion.Euler(-315 * volKnob / 0xff-40, 0, 90);

    }

    /*
    void OnGUI()
    {
        GUI.Label(new Rect(40, 10, 480, 30), "message: " + ReadWrite.mes);
    }
    */

    public Boolean getAntenna()
    {
        return antenna;
    }

    public int getFreqKnob()
    {
        return freqKnob;
    }

    public int getVolKnob()
    {
        return volKnob;
    }
}
