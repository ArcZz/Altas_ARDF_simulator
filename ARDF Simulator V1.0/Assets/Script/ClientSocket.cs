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
				Debug.Log("Connect server success.");  
			}  
			catch  
			{  
				IsConnected = false;  
				Debug.Log("Connect server failed.");  
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
					
					GameObject.FindGameObjectWithTag ("FPSController").SetActive (false);
				} else {
					GameObject.FindGameObjectWithTag ("FPSController").SetActive (true);
					Debug.Log ("Server returns data：" + data);
				}
				

		}  
		public void receiveData(){
			//Debug.Log("we are entering now");
			Socket mClientSocket = (Socket)clientSocket;
			while (IsConnected) {
				
				int receiveNumber = mClientSocket.Receive (result);
				//Console.WriteLine("接收客户端{0}消息， 长度为{1}", mClientSocket.RemoteEndPoint.ToString(), receiveNumber);
				ByteBuffer buff = new ByteBuffer (result);
				//数据长度  
				int len = buff.ReadShort ();
				//int protoId = buff.ReadShort();
				//数据内容  
				string data = buff.ReadString ();
				if (data == "You are stopped by Teacher") {
					Debug.Log("we are entering now 4");
					Debug.Log ("Please contact your teacher APSP：" + data);
					IsConnected = false;
				} else {
					//GameObject.FindGameObjectWithTag ("player").SetActive (true);

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
	}
}

