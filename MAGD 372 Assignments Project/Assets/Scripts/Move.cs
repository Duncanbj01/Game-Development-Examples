using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class Move : MonoBehaviour
{
    //Unity connects to serial port 
    SerialPort sp = new SerialPort("COM5", 9600);
   // public string recievedString; 

   
    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 100;  
        
    }

    void Update()
    {
        if (sp.IsOpen)
        {
            try
            {
                
                if (sp.ReadByte() == 1)
                {
                    transform.Translate(Vector3.up * Time.deltaTime * 4);
                    Debug.Log("Up"); 
                }
                if (sp.ReadByte() == 2)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * 4);
                    Debug.Log("Left");
                }
                if (sp.ReadByte() == 3)
                {
                    transform.Translate(Vector3.down * Time.deltaTime * 4);
                    Debug.Log("Down");
                }
                if (sp.ReadByte() == 4)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * 4);
                    Debug.Log("Right");
                }
                if (sp.ReadByte() == 5)
                {
                    transform.Translate(Vector3.up * Time.deltaTime * 4);
                    Debug.Log("Triangle");
                }

                if (sp.ReadByte() == 6)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * 4);
                    Debug.Log("Square");
                }
                if (sp.ReadByte() == 7)
                {
                    transform.Translate(Vector3.down * Time.deltaTime * 4);
                    Debug.Log("X");
                }
                if (sp.ReadByte() == 8)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * 4);
                    Debug.Log("Circle");
                }
            }
            catch (System.Exception)
            {

            }

        }
    }
}