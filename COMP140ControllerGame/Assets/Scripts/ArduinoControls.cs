using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;
using System.Collections;

public class ArduinoControls : MonoBehaviour
{

    public GameObject hook;
    public bool controllerActive = false;
    public int commPort = 0;

    private SerialPort serial = null;
    private bool connected = false;

    // Use this for initialization
    void Start()
    {
        ConnectToSerial();
    }

    void ConnectToSerial()
    {
        Debug.Log("Attempting Serial: " + commPort);
        serial = new SerialPort("\\\\.\\COM" + commPort, 9600);
        serial.ReadTimeout = 50;
        serial.Open();
    }

    // Update is called once per frame
    void Update()
    {

        if (controllerActive)
        {
            WriteToArduino("I");                // Ask for the positions
            String value = ReadFromArduino(50); // read the positions

            if (value != null)                  // check to see if we got what we need
            {
                // EXPECTED VALUE FORMAT: "0-1023"
                string[] values = value.Split('-');     // split the values

                if (values.Length == 2)
                {
                    positionPlayers(values);
                    Debug.Log(values);
                }
            }
        }

        
    }

    void positionPlayers(String[] values)
    {
        if (hook != null)
        {
            float yPos = Remap(int.Parse(values[0]), 0, 1023, 0, 10);         // scale the input. this could be done on the Arduino as well.

            Vector3 newPosition = new Vector3(hook.transform.position.x,       // create a new Vector for the position
                yPos, hook.transform.position.z);

            hook.transform.position = newPosition;        // apply the new position
        }
    }

    void WriteToArduino(string message)
    {
        serial.WriteLine(message);
        serial.BaseStream.Flush();
    }

    public string ReadFromArduino(int timeout = 0)
    {
        serial.ReadTimeout = timeout;
        try
        {
            return serial.ReadLine();
        }
        catch (TimeoutException e)
        {
            return null;
        }
    }

    void OnDestroy()
    {
        Debug.Log("Exiting");
        serial.Close();
    }

    float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
