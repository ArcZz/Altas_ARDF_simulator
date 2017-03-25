using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transmitter : MonoBehaviour {

    [Tooltip("The signal of the transmitter.(10:MO,>=11:dummy transmitter)")]
    public int transmitterID = 12;

    public Texture2D mouse;
    public Texture2D fingerStick;

    public float punchDistance = 10;

    public AudioSource punch;

    // Use this for initialization
    private Vector3 position;
    private AudioSource signal;

    private bool punchable;
    private bool test=false;

    private Rect windowRect = new Rect(200, 120, 240, 100);



    //private float test, test2;
    void Start () {
        signal = GetComponent<AudioSource>();
        position = this.transform.position;
        punchable = false;
    }
	
	// Update is called once per frame
	void Update () {
        //signal.volume = 1;
        //GameObject.Find("PJ80").GetComponent<PJ80>().getAntenna();
        Vector3 p1 = GameObject.Find("P1").GetComponent<MeshFilter>().transform.position;
        Vector3 p2 = GameObject.Find("P2").GetComponent<MeshFilter>().transform.position;
        //Vector3 ferriteRodAntenna= GameObject.Find("P1").GetComponent<MeshFilter>().transform.position- GameObject.Find("P2").GetComponent<MeshFilter>().transform.position;
        Vector3 ferriteRodAntenna = p1 - p2;
        Vector3 p12 = (p1 + p2) / 2;
        Vector3 distance = position - p12;
        float angle = Vector3.Angle(ferriteRodAntenna, distance);
        if (GameObject.Find("PJ80").GetComponent<PJ80>().getAntenna())
        {
            float l = GameObject.Find("PJ80").GetComponent<PJ80>().whipAntennaLength;
            float angle3 = angle / 180 * (float)3.1415926;
            signal.volume = Mathf.Abs(l+Mathf.Cos(angle3-(float)3.1415926/2));
        }
        else
        {
            
            if (angle > 90)
            {
                angle = 180 - angle;
            }
            float angle2 = angle / 180 * (float)3.1415926;
            float tan2 = Mathf.Tan(angle2) * Mathf.Tan(angle2);
            signal.volume = Mathf.Sqrt(tan2 * tan2 + tan2) / (1 + tan2) * (float)0.9 + (float)0.1;
        }
        if (punchable == true)
        {
            Vector3 player = GameObject.Find("PJ80").transform.position;
            if (Vector3.Distance(player, position) > punchDistance)
            {
                Cursor.SetCursor(mouse, Vector2.zero, CursorMode.Auto);
                punchable = false;
            }
        }

        //test = signal.volume;
        //test2 = angle;
    }

    /*
    void OnGUI()
    {
        GUI.Label(new Rect(40, 20, 480, 30), "v: " + test+"ang:"+test2);
    }
    */

    private void OnMouseEnter()
    {
        Vector3 player = GameObject.Find("PJ80").transform.position;
        if(Vector3.Distance(player,position)<punchDistance)
        {
            Cursor.SetCursor(fingerStick, Vector2.zero, CursorMode.Auto);
            punchable = true;
        }
    }

    private void OnMouseExit()
    {
        if(punchable==true)
        {
            Cursor.SetCursor(mouse, Vector2.zero, CursorMode.Auto);
            punchable = false;
        }
    }

    private void OnMouseUp()
    {
        if(punchable==true)
        {
            punch.Play();
            test = true;
        }
    }

    void DoMyWindow(int windowID)
    {
        if (GUI.Button(new Rect(70, 60, 100, 20), "Exit"))
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
	            Application.Quit ();
            #endif
        }

    }

    private void OnGUI()
    {
        if(test)
            windowRect = GUI.Window(0, windowRect, DoMyWindow, "Congratulation!");
    }
}
