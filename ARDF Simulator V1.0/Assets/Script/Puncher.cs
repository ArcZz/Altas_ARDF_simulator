using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puncher : MonoBehaviour {

    
    [Tooltip("The signal of the transmitter.(10:MO,>=11:dummy transmitter)")]
    public int puncherID = 12;

    public Texture2D mouse;
    public Texture2D fingerStick;

    public float punchDistance = 10;

    public AudioSource punch;
    private bool punchable;
    //private bool test = false;
    private Vector3 position;
    public Material m1, m2;

    // Use this for initialization
    void Start () {
        position = this.transform.position;
        punchable = false;
        string te;
        te = "  ";
        if (puncherID >= 0 && puncherID <= 99)
        {
            te = puncherID.ToString();
            if (puncherID < 10 && puncherID >= 0)
                te = '0' + te;
            if (puncherID == 10)
                te = "MO";
        }
        else if(puncherID==-1)
        {
            te = "start";
            transform.Find("IDtext").GetComponent<TextMesh>().fontSize = 28;
        }
        else if (puncherID == -2)
        {
            te = "finish";
            transform.Find("IDtext").GetComponent<TextMesh>().fontSize = 28;
        }
        else if (puncherID == -3)
        {
            te = "clear";
            transform.Find("IDtext").GetComponent<TextMesh>().fontSize = 28;
        }
        else if (puncherID == -4)
        {
            te = "master";
            transform.Find("IDtext").GetComponent<TextMesh>().fontSize = 20;
        }

        transform.Find("IDtext").GetComponent<TextMesh>().text = te;
    }
	
	// Update is called once per frame
	void Update () {
        if (punchable == true)
        {
            Vector3 player = GameObject.Find("PJ80").transform.position;
            if (Vector3.Distance(player, position) > punchDistance)
            {
                Cursor.SetCursor(mouse, Vector2.zero, CursorMode.Auto);
                punchable = false;
            }
        }
    }


    private void OnMouseEnter()
    {
        Vector3 player = GameObject.Find("PJ80").transform.position;
        if (Vector3.Distance(player, position) < punchDistance)
        {
            Cursor.SetCursor(fingerStick, Vector2.zero, CursorMode.Auto);
            punchable = true;
        }
    }

    private void OnMouseExit()
    {
        if (punchable == true)
        {
            Cursor.SetCursor(mouse, Vector2.zero, CursorMode.Auto);
            punchable = false;
        }
    }

    private void OnMouseUp()
    {
        if (punchable == true)
        {
            punch.Play();
            StartCoroutine(li());
            //test = true;
            GameObject.Find("punchRecord").GetComponent<punchRecord>().punch(puncherID);
            if (puncherID <= 9 && puncherID >= 0)
            {
                GameObject.Find("card").GetComponent<recordCard>().check(puncherID);
            }
            if(puncherID==-1)
            {
                //GameObject.Find("timingPrompter").GetComponent<AudioSource>().Play(100000);
            }

        }
    }

    

    

    IEnumerator li()
    {

        transform.Find("Cylinder001").GetComponent<Renderer>().sharedMaterial = m2;
        
        transform.Find("Cylinder002").GetComponent<Renderer>().sharedMaterial = m2;
        yield return new WaitForSeconds((float)0.2);
        transform.Find("Cylinder001").GetComponent<Renderer>().sharedMaterial = m1;
        
        transform.Find("Cylinder002").GetComponent<Renderer>().sharedMaterial = m1;
    }
}
