using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

	public static GameControl control;
	//settings
	public string ip;
	public string name;
	public bool online;

	//controller
	public float y;

	//model //length //Sound type
	public int numM;
	public int length;
	public int sounds;

	//Ul display
	public Text iptext;
	public Text nametext;
	public Toggle onlinetext;


	//public  int[] a; public void InitArray(int n) { a = new int[n]; }
	void Awake () {
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		}
		else if (control != this){
			Destroy (gameObject);
		}

	}
	void Start(){
		Load ();

		iptext.text = GameControl.control.ip;
		nametext.text = GameControl.control.name;
		onlinetext.isOn = GameControl.control.online;


	



	}
	public void Save(){
		BinaryFormatter bf = new BinaryFormatter ();  
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");
		Debug.Log (Application.persistentDataPath);
		PlayerData player = new PlayerData ();

		player.ip = ip;
		player.name = name;
		player.online = online;
		player.y = y;

		player.numM = numM;
		player.length = length;
		player.sounds = sounds;
	
		bf.Serialize (file, player);
		file.Close ();

	}
	public void Load(){
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData player = (PlayerData)bf.Deserialize(file);

			ip = player.ip;
			name = player.name;
			online = player.online;

			y = player.y;

			numM = player.numM;
			length = player.length;
			sounds = player.sounds;



		} else {
			
		}
	}
	    

	[System.Serializable]
	public class PlayerData
	{
		//settings
		public string ip;
		public string name;
		public bool online;

		//controller
		public float y;

		//model //length //Sound type
		public int numM;
		public int length;
		public int sounds;


		public PlayerData (){
			


		}
	}

}
