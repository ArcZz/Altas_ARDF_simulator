using UnityEngine;  
using System.Collections;  
using Net;  
using System.Threading;
public class OnlineSocket : MonoBehaviour {  

	// Use this for initialization 
	ClientSocket mSocket = new ClientSocket(); 
	//定义一个Transform类型的player  
	private Transform player;

	void Start () {
        player = GameObject.Find("FPSController").transform;
        Debug.Log("0");
        //mSocket.SendMessage("Player: " + player.tag);


        Thread thread = new Thread(mSocket.receiveData);
        thread.Start(mSocket);
        mSocket.ConnectServer("10.7.8.84", 8088);
        Debug.Log("1");
        //player = GameObject.FindGameObjectWithTag("player").transform;
        
        //Debug.Log(player.position.x);
		
        //mSocket.receiveData ();
    }  

	// Update is called once per frame  
	void Update () {
		string send = "O";
		float xf = ((player.position.x ) * 2);
		float zf = ((player.position.z ) * 2);
		int x = (int)xf;
		int z = (int)zf;
        x = 999 - x;
        z = 999 - z;
		if (x > 999) {
			x = 999;
		}
		if (z > 999) {
			z = 999;
		}
		if (x < 0) {
			x = 0;
		}
		if (z < 0) {
			z = 0;
		}
        //x = 777;
        //z = 777;
		string coordianteX = x.ToString ("000");
		string coordianteZ = z.ToString ("000");
		send = send + coordianteX + coordianteZ +"F";

		//Debug.Log ("X = " + coordianteX + " & Z = " + coordianteZ);
		Debug.Log("send = "+send);
		//mSocket.SendMessage("Player:sdfddfdsfjdsfjsdfasdfadsfdsfadsfsdfsdfsdfasdfsdfasdfasdfsdfasdfsdfsdfsdfasdfsfasdfadsfdsfsdfsdfdsfdsfdsfdsfgsdgksfwejjrklnnsmfjsdhflwknf2");
		//mSocket.SendMessage("Player:sdfddfdsfjdsfjsdfasdfadsfdsfadsfsdfsdfsdfasdfsdfasdfasdfsdfasdfsdfsdfsdfasdfsfasdfadsfdsfsdfsdfdsfdsfdsfdsfgsdgksfwejjrklnnsmfjsdhflwknf3");
		//mSocket.SendMessage (player.position.ToString("G4"));
		mSocket.SendMessage (send);
		
		//mSocket.receiveData();
		if (mSocket.IsConnected == false) { 
			//System.Threading.Thread.Sleep(10000);
			//To do: exit because of force exit	
		}

	}  
}  