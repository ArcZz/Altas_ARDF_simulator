/**
 * SerialCommUnity (Serial Communication for Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using System.Collections;

/**
 * Sample for reading using polling by yourself, and writing too.
 */
public class ReadWrite : MonoBehaviour
{
    public SerialController serialController;
    public static string mes;
    public int continuousNull;
    public bool Connection;
    // Initialization
    void Start()
    {
        //Debug.Log("OK");
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
        //mes = "error________________________________";
        mes = "S0fd0000000000000000226fffd4ffba1270F";
        continuousNull = 5;
        Connection = false;
    }

    // Executed each frame
    void Update()
    {
        //---------------------------------------------------------------------
        // Send data
        //---------------------------------------------------------------------

        // If you press one of these keys send it to the serial device. A
        // sample serial device that accepts this input is given in the README.
        /*
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Sending");
            byte[] a = { 0xa5, 0x22, 0xc7 };
            serialController.SendSerialMessage(a);
        }
        */

        /*
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Sending Z");
            serialController.SendSerialMessage("Z");
        }
        */

        //---------------------------------------------------------------------
        // Receive data
        //---------------------------------------------------------------------

        string message = serialController.ReadSerialMessage();

        if (message == null)
        {
            //Debug.Log("null message");
            continuousNull++;
            return;
        }

        // Check if the message is plain data or a connect/disconnect event.
        if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
        {
            Debug.Log("Connection established");
            Connection = true;
        }

        else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
        {
            //Debug.Log("Connection attempt failed or disconnection detected");
            Connection = false;
        }
        else
        {
            //Debug.Log("Message arrived: " + message);
            continuousNull = 0;
            mes = message;
        }
    }
    
    public void enablePJ80()
    {
        byte[] a = { 0xa5, 0x22, 0xc7 };
        serialController.SendSerialMessage(a);
    }
}
