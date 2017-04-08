using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transmitter : MonoBehaviour {

    [Tooltip("The signal of the transmitter.(10:MO,>=11:dummy transmitter)")]
    public int transmitterID = 12;

    // Use this for initialization
    private Vector3 position;
    private AudioSource signal;
    public int effect = 42;
    public AudioClip[] code;
    private bool shortDistance = true;
    private bool switchOn = false;

    private float power;

    private float test;


    float f = 0;
    float f2 = 0;
    float sv = 0;
    //float Hz;
    float volume;

    void OnAudioFilterRead(float[] data, int channels)
    {
        f = 0;
        for (int i = 0; i < data.Length; i++)
        {
            //data[i] = Mathf.Sin(f);
            if (data[i] != 0)
            { data[i] = Mathf.Sin(f)*volume; }
            //if (i % (int)sv == 0)
            /*
            if (i % sv <1)
            {
                f++;
            }
            */
            if (i % (int)(Mathf.Pow(power, sv)) == 0)
            {
                f += (float)1.5;
            }
        }
    }
    void Start () {
        signal = GetComponent<AudioSource>();
        signal.clip = code[transmitterID];
        signal.Play();
        
        position = this.transform.position;
        InvokeRepeating("Run", 0, 1);
        power = (float)Mathf.Pow((float)400, (float)1 / effect);
        //Debug.Log(power);
    }

    void Run()
    {
        //Hz = f - f2;
        f2 = f;
    }

    // Update is called once per frame
    void Update () {
        if (switchOn)
        {
            signal.volume = 1;
        }
        else
        {
            signal.volume = 0;
        }
        //GameObject.Find("PJ80").GetComponent<PJ80>().getAntenna();
        Vector3 p1 = GameObject.Find("P1").GetComponent<MeshFilter>().transform.position;
        Vector3 p2 = GameObject.Find("P2").GetComponent<MeshFilter>().transform.position;
        Vector3 p3 = GameObject.Find("P3").GetComponent<MeshFilter>().transform.position;
        //Vector3 ferriteRodAntenna= GameObject.Find("P1").GetComponent<MeshFilter>().transform.position- GameObject.Find("P2").GetComponent<MeshFilter>().transform.position;
        Vector3 ferriteRodAntenna = p1 - p2;
        Vector3 p12 = (p1 + p2) / 2;
        Vector3 distance = position - p12;
        float angle = Vector3.Angle(ferriteRodAntenna, distance);
        float volKnob = GameObject.Find("PJ80").GetComponent<PJ80>().getVolKnob() / (float)255;
        int freqKnob = GameObject.Find("PJ80").GetComponent<PJ80>().getFreqKnob();
        //test = volKnob;
        if (GameObject.Find("PJ80").GetComponent<PJ80>().getAntenna())
        {
            Vector3 ch = p3 - p12;
            float l = GameObject.Find("PJ80").GetComponent<PJ80>().whipAntennaLength;
            float angle3 = Vector3.Angle(ch, distance) / 180 * (float)3.1415926;
            //test4 = angle3;
            //signal.volume = Mathf.Abs(l+Mathf.Cos(angle3))/(l+1);
            volume = Mathf.Abs(l + Mathf.Cos(angle3)) / (l + 1);
        }
        else
        {
            
            if (angle > 90)
            {
                angle = 180 - angle;
            }
            float angle2 = angle / 180 * (float)3.1415926;
            float tan2 = Mathf.Tan(angle2) * Mathf.Tan(angle2);
            //signal.volume = Mathf.Sqrt(tan2 * tan2 + tan2) / (1 + tan2) * (float)0.9 + (float)0.1;
            volume = Mathf.Sqrt(tan2 * tan2 + tan2) / (1 + tan2) * (float)0.9 + (float)0.1;
        }
        //signal.volume = signal.volume * volKnob;
        int freqKnobDiff;
        if (shortDistance || (transmitterID == 10))
        {
            freqKnobDiff = effect / 2 - Mathf.Abs(freqKnob - (transmitterID * 21 + 21));
        }
        else
        {
            freqKnobDiff = effect / 2 - Mathf.Abs(freqKnob - (5 * 21 + 21));
        }
        if(freqKnobDiff<0)
        {
            freqKnobDiff = 0;
            sv = 0;
        }
        else
        {
            if (shortDistance || (transmitterID==10))
            {
                sv = -freqKnob + (transmitterID * 21 + 21) + effect / 2;
            }
            else
            {
                sv = -freqKnob + (5 * 21 + 21) + effect / 2;
            }
            
        }
        float freqVol = (float)(Mathf.Sqrt(((float)freqKnobDiff / ((float)effect / 2))));
        //freqVol = 1;
        volume = volume * volKnob* freqVol;
        test = freqVol;

        //test = signal.volume;
        //test2 = angle;
    }

    
    public void switchPowerOn(bool sw)
    {
        switchOn = sw;
    }

    public void setShortDistance(bool sd)
    {
        shortDistance = sd;
    }
    

    
}
