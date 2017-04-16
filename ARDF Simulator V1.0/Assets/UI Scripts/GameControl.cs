using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public class GameControl : MonoBehaviour {

	public static GameControl control;
	public int numT;
	public int[] goalID;
	public string ip;
	public string name;
	public bool online;
	public bool shortm;
	public bool langth;
	public bool RND;
	void Awake () {
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		}
		else if (control != this){
			Destroy (gameObject);
		}

	}
	public void Save(){
		BinaryFormatter bf = new BinaryFormatter ();
		CreateFile(Application.persistentDataPath +"/","playernfo.dat");    
		FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
		Debug.Log (Application.persistentDataPath);
		PlayerData player = new PlayerData ();
		player.b = b;
		player.a = a;
		player.check = check;
		player.ip = ip;
		player.name = name;
		bf.Serialize (file, player);
		file.Close ();

	}
	public void Load(){
		if (File.Exists (Application.persistentDataPath, "/playernfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData player = (PlayerData)bf.Deserialize(file);
			file.Close ();

		} else {
			
		}
	}
	void CreateFile(string path,string name)    
	{    
		 
		StreamWriter sw;    
		FileInfo t = new FileInfo(path+"//"+ name);    
		if(!t.Exists)    
		{    
			
			sw = t.CreateText();   
		}    
		else  
		{    
			
			sw = t.AppendText();    
		}    
			
		sw.Close();    
		sw.Dispose();    
	}    

	[System.Serializable]
	public class PlayerData
	{
		public int b;
		public int a;
		public string ip;
		public string name;
		public bool check;
		public PlayerData (){


		}
	}

}
