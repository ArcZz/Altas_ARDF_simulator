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
    public float whipAntennaLength=1;

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

        /*
        //eular angle
        int r_roll = Int32.Parse(ReadWrite.mes.Substring(8, 4), System.Globalization.NumberStyles.HexNumber);
        int r_pitch = Int32.Parse(ReadWrite.mes.Substring(12, 4), System.Globalization.NumberStyles.HexNumber);
        int r_yaw = Int32.Parse(ReadWrite.mes.Substring(16, 4), System.Globalization.NumberStyles.HexNumber);
        
         r_roll = r_roll << 16;
        if (r_roll < 0)
        {
            r_roll = r_roll | 65535;
        }
        r_roll = r_roll / 65536;
        r_pitch = r_pitch << 16;
        if (r_pitch < 0)
        {
            r_pitch = r_pitch | 65535;
        }
        r_pitch = r_pitch / 65536;
        r_yaw = r_yaw << 16;
        if (r_yaw < 0)
        {
            r_yaw = r_yaw | 65535;
        }
        r_yaw = r_yaw / 65536;
        double roll = r_roll / 100;
        double pitch = r_pitch / 100;
        double yaw = r_yaw / 100;
         */

        int r_q0 = Int32.Parse(ReadWrite.mes.Substring(20, 4), System.Globalization.NumberStyles.HexNumber);
        int r_q1 = Int32.Parse(ReadWrite.mes.Substring(24, 4), System.Globalization.NumberStyles.HexNumber);
        int r_q2 = Int32.Parse(ReadWrite.mes.Substring(28, 4), System.Globalization.NumberStyles.HexNumber);
        int r_q3 = Int32.Parse(ReadWrite.mes.Substring(32, 4), System.Globalization.NumberStyles.HexNumber);
        

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
        /*
        if ((r_roll >> 15) == 1)
        {
            //roll = (-1) * (roll + 360);
            roll = (-1) * (((~(r_roll << 17)) >> 17)+1) / 100;
        }
        if ((r_pitch >> 15) == 1)
        {
            //pitch = (-1) * (pitch + 360);
            pitch = (-1) * (((~(r_pitch << 17)) >> 17)+1) / 100;
        }
        if ((r_yaw >> 15) == 1)
        {
            //yaw = (-1) * (yaw + 360);
            yaw = (-1) * (((~(r_yaw << 17)) >> 17)+1) / 100;
        }
        */
        //double pitch =  r_pitch* 360 / 65536;
        //double yaw = r_yaw * 360 / 65536;
        //this.transform.Rotate(0, 0, 133);
        //this.transform.eulerAngles.Set(0, 0, 133);
        //this.transform.Translate(new Vector3(0, 0, 133), Space.Self);
        //this.transform.rotation.Set(0, 0, 0, 36);
        //this.transform.rotation = Quaternion.Euler((roll+90)%360, (pitch+315)%360, yaw);

        //this.transform.rotation = Quaternion.Euler((float)roll, (float)pitch , (float)yaw);
        //this.transform.rotation = Quaternion.Euler(0, 0, 0);
        //this.transform.Rotate(0, 0, 90);
        Quaternion t= new Quaternion((float)q1, (float)q2, (float)q3, (float)q0);
        t=t* Quaternion.Euler(0, 0, 0);
        //this.transform.localRotation = new Quaternion((float)q1, (float)q2, (float)q3, (float)q0);
        this.transform.localRotation = t;
        this.transform.Rotate(0, 90, -90, Space.Self);
        //this.transform.Rotate(120,0,0,Space.World);

        int s1 = Int32.Parse(ReadWrite.mes.Substring(1, 1), System.Globalization.NumberStyles.HexNumber);
        //bool tempAntenna = antenna;
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

    void OnGUI()
    {
        //GUI.Label(new Rect(40, 10, 480, 30), "message: " + mes);
        GUI.Label(new Rect(40, 10, 480, 30), "message: " + ReadWrite.mes);
        //GUI.Label(new Rect(40, 20, 480, 30), "freqKnob: " + freqKnob);
        //ReadWrite.mes.Substring(8, 4);
        //GUI.Label(new Rect(40, 20, 480, 30), "ROLL: " + ReadWrite.mes.Substring(8, 4));
        /*
        float roll = Int32.Parse(ReadWrite.mes.Substring(8, 4), System.Globalization.NumberStyles.HexNumber) * 360 / 65536;
        float pitch = Int32.Parse(ReadWrite.mes.Substring(12, 4), System.Globalization.NumberStyles.HexNumber) * 360 / 65536;
        float yaw = Int32.Parse(ReadWrite.mes.Substring(16, 4), System.Globalization.NumberStyles.HexNumber) * 360 / 65536;
        
    */
        /*
            //eular angle
            int r_roll = Int32.Parse(ReadWrite.mes.Substring(8, 4), System.Globalization.NumberStyles.HexNumber);
            int r_pitch = Int32.Parse(ReadWrite.mes.Substring(12, 4), System.Globalization.NumberStyles.HexNumber);
            int r_yaw = Int32.Parse(ReadWrite.mes.Substring(16, 4), System.Globalization.NumberStyles.HexNumber);

            r_roll = r_roll << 16;
            if(r_roll<0)
            {
                r_roll = r_roll | 65535;
            }
            r_roll = r_roll / 65536;
            r_pitch = r_pitch << 16;
            if (r_pitch < 0)
            {
                r_pitch = r_pitch | 65535;
            }
            r_pitch = r_pitch / 65536;
            r_yaw = r_yaw << 16;
            if (r_yaw < 0)
            {
                r_yaw = r_yaw | 65535;
            }
            r_yaw = r_yaw / 65536;
            double roll = r_roll / 100.0;
            double pitch = r_pitch / 100.0;
            double yaw = r_yaw / 100.0;
            */
        /*
        if ((r_roll >> 15) == 1)
        {
            //roll = (-1) * (roll + 360);
            roll = (-1) * (((~(r_roll << 17)) >> 17) + 1) / 100;
        }
        if ((r_pitch >> 15) == 1)
        {
            //pitch = (-1) * (pitch + 360);
            pitch = (-1) * (((~(r_pitch << 17)) >> 17) + 1) / 100;
        }
        if ((r_yaw >> 15) == 1)
        {
            //yaw = (-1) * (yaw + 360);
            yaw = (-1) * (((~(r_yaw << 17)) >> 17) + 1) / 100;
        }
        */
        //GUI.Label(new Rect(40, 20, 480, 30), "ROLL: " + roll);
        //GUI.Label(new Rect(40, 30, 480, 30), "PITCH: " + pitch);
        //GUI.Label(new Rect(40, 40, 480, 30), "YAW: " + yaw);

        //GUIStyle a=new GUIStyle();
        //GUI.Slider(new Rect(40, 50, 480, 30),50,100,0,100,a,a,true,0);
        //GUILayout.HorizontalSlider(50, 0, 100);
        //float p1x=GameObject.Find("S1").GetComponent<MeshFilter>().transform.position.x;
        //GUI.Label(new Rect(40, 20, 480, 30), "p1x: " + p1x);
    }

    public Boolean getAntenna()
    {
        return antenna;
    }

    int getFreqKnob()
    {
        return freqKnob;
    }

    int getVolKnob()
    {
        return volKnob;
    }
}
