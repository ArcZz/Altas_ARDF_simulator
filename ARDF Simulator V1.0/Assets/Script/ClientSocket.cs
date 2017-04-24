   using UnityEngine;  
using System.Collections;  
using System.Net;  
using System.Net.Sockets;  
using System.IO; 
using System.Threading;
namespace Net
{
	public class ClientSocket
	{
        //standard distance: mode 1, short distance: mode 0
        public static char mode='8';
        public static int[] transmitterId = new int[5];
        //public static char numoftransmitter;
        //wave distance
        public static char distance='D';
        //number of transmitter
        public static int transmitterNum=1;

		private static byte[] result = new byte[1024];  
		private static Socket clientSocket;  
		//是否已连接的标识  
		public bool IsConnected = false;  

		public ClientSocket(){  
			clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);  
		}  

		/// <summary>  
		/// 连接指定IP和端口的服务器  
		/// </summary>  
		/// <param name="ip"></param>  
		/// <param name="port"></param>  
		public void ConnectServer(string ip,int port)  
		{  
			IPAddress mIp = IPAddress.Parse(ip);  
			IPEndPoint ip_end_point = new IPEndPoint(mIp, port);  

			try {  
				clientSocket.Connect(ip_end_point); 
				//clientSocket.Blocking = false;
				IsConnected = true;  
				//Debug.Log("Connect server success.");  
			}  
			catch  
			{  
				IsConnected = false;  
				//Debug.Log("Connect server failed.");  
				return;  
			}  
			//服务器下发数据长度 
				int receiveLength = clientSocket.Receive(result);  
				ByteBuffer buffer = new ByteBuffer(result);  
				int len = buffer.ReadShort();  
				string data = buffer.ReadString();
				//如果服务器返回等待命令，程序暂停执行
				if (data == "Waiting") {
					Debug.Log ("Server returns data：" + data);
					
					GameObject.Find ("FPSController").SetActive (false);
				} else {
					GameObject.Find ("FPSController").SetActive (true);
					//Debug.Log ("Server returns data：" + data);
				}
				

		}  
		public void receiveData(){
			//Debug.Log("we are entering now");
			Socket mClientSocket = (Socket)clientSocket;
			while (IsConnected) {
                //Debug.Log("we are service connect now");
                int receiveNumber = mClientSocket.Receive (result);
				//Console.WriteLine("接收客户端{0}消息， 长度为{1}", mClientSocket.RemoteEndPoint.ToString(), receiveNumber);
				ByteBuffer buff = new ByteBuffer (result);
				//数据长度  
				int len = buff.ReadShort ();
				//int protoId = buff.ReadShort();
                
				//数据内容  
				string data = buff.ReadString ();
                string basic_info = data;
                //Debug.Log("data receive"+data);
                if (data.Contains("Basic information: ")) {
                    basic_info = basic_info.Replace("Basic information: ", "");
                    //string[] string_arr = basic_info.Split('/');
                    mode = basic_info[0];
                    if (mode == '2')
                    {
                        GameControl.control.length = 1;
                    }
                    else
                    {
                        GameControl.control.length = 0;
                    }
                    distance = basic_info[1];
                    if (distance == 'D')
                    {
                        GameControl.control.numM = 1;
                    }
                    else
                    {
                        GameControl.control.numM = 0;
                    }
                    transmitterNum = (int)basic_info[2]-48;
                    GameControl.control.sounds = transmitterNum - 1;
                    //int leneg = transmitter.Length;
                    //transmitterId[i]

                    //numoftransmitter = transmitter[0];
                    for (int i = 0; i< 5; i++)
                    {
                        if (basic_info[i + 3] != 'N')
                        {
                            transmitterId[i] = (int)basic_info[i + 3]-48;
                            //Debug.Log("transmitterId:" + transmitterId[i]);
                        }
                        else
                        {
                            transmitterId[i] = 0;
                        }
                        
                        //Debug.Log("transmitterId:" + transmitterId[i]);
                    }
                    GameControl.control.num1 = transmitterId[0];
                    GameControl.control.num2 = transmitterId[1];
                    GameControl.control.num3 = transmitterId[2];
                    GameControl.control.num4 = transmitterId[3];
                    GameControl.control.num5 = transmitterId[4];

                }
                if (data == "You are stopped by Teacher") {
					Debug.Log("we are entering now 4");
					Debug.Log ("Please contact your teacher APSP：" + data);
					IsConnected = false;
				} else {
                    //GameObject.FindGameObjectWithTag ("player").SetActive (true);
                    //Debug.Log("Reieved data" + data);
				}
			}
		}

		/// <summary>  
		/// 发送数据给服务器  
		/// </summary>  
		public void SendMessage(string data)  
		{  
			if (IsConnected == false)  
				return;  
			try  
			{  
				ByteBuffer buffer = new ByteBuffer();  
				buffer.WriteString(data);  
				clientSocket.Send(WriteMessage(buffer.ToBytes()));  
			}  
			catch  
			{  
				IsConnected = false;  
				clientSocket.Shutdown(SocketShutdown.Both);  
				clientSocket.Close();  
			}  
		}  

		/// <summary>  
		/// 数据转换，网络发送需要两部分数据，一是数据长度，二是主体数据  
		/// </summary>  
		/// <param name="message"></param>  
		/// <returns></returns>  
		private static byte[] WriteMessage(byte[] message)  
		{  
			MemoryStream ms = null;  
			using (ms = new MemoryStream())  
			{  
				ms.Position = 0;  
				BinaryWriter writer = new BinaryWriter(ms);  
				ushort msglen = (ushort)message.Length;  
				writer.Write(msglen);  
				writer.Write(message);  
				writer.Flush();  
				return ms.ToArray();  
			}  
		}
        
        public int getTrsNum()
        {
            return transmitterNum;
        }  

        public int getTrsID(int n)
        {
            if (n < 1 || n > 5)
            {
                return -2;
            }
            else
            {
                return transmitterId[n];
            }
        }

        public bool getShort()
        {
            if(distance=='D')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool get2m()
        {
            if(mode=='2')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
	}
}

