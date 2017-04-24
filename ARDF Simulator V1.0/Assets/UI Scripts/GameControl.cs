using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

	public static GameControl control;
	//settings and save 

	public string ip;
	public string name;
	public string cmo;
	public float y;
	public bool online;//second screen


	//model //length //Sound type for transfer data
	public int numM;
	public int length;
	public int sounds;
	public int num1;
	public int num2;
	public int num3;
	public int num4;
	public int num5;
    public bool onlineTraining=false;


	//Ul display
	public Slider myY;
	public Text iptext;
	public Text nametext;
	public Text cmotext;
	public Toggle onlinetext;//second screen


	//public  int[] a; public void InitArray(int n) { a = new int[n]; }
	void Awake () {
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
            Load();

            Init();
        }
		else if (control != this){
			Destroy (gameObject);
		}

	}
	void Start(){
		
	



	}

    public void Init()
    {
       
       
        iptext.text = GameControl.control.ip;
        nametext.text = GameControl.control.name;
        onlinetext.isOn = GameControl.control.online;
        myY.value = GameControl.control.y;
        cmotext.text = GameControl.control.cmo;
    }
  



    public void Save(){
        Debug.Log("test");
		BinaryFormatter bf = new BinaryFormatter ();  
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");
		Debug.Log (Application.persistentDataPath);
		PlayerData player = new PlayerData ();

		player.ip = ip;
		player.name = name;
		player.online = online;
		player.y = y;
		player.cmo = cmo;

	
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
			cmo = player.cmo;
			y = player.y;

		



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
		public string cmo;
		public float y;

		//model //length //Sound type
		public int numM;
		public int num1;
		public int num2;
		public int num3;
		public int num4;
		public int num5;

		public int length;
		public int sounds;



		public PlayerData (){
			


		}
	}

}
