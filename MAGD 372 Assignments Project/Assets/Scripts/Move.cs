using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports; //Contains classes for controlling serial ports.


public class Move : MonoBehaviour
{
    //Unity connects to the serial port that the Arduino is using which in this case is "COM5".  
    SerialPort sp = new SerialPort("COM5", 9600);

   
    void Start()
    {
        sp.Open();. //Opens the serial port connection. 
        sp.ReadTimeout = 100;  //Sets the number of milliseconds before a timeout occurs when a read operation doesnt finish. 
                               //This happens if the server takes too long to responds and send information. 

    }

    void Update()
    {
        if (sp.IsOpen) //tracks whether the port is open for use by the caller which in this case is Unity
        {
            try // the try statment allows you to test a block of code (button inputs) for errors while the code is being executed
            {
                if (sp.ReadByte() == 1) //Synchronously reads a byte from the serial port. //Communicates with Unity and recognizes input as pin_button1 which allows the game object to move up. 
                {
                    transform.Translate(Vector3.up * Time.deltaTime * 4); //C# code that allows the game object to move in a direction depending on what button is pressed. 
                                                                          //Time.deltaTime * 4 controls the speed of the game object. 

                    Debug.Log("Up"); //prints the input to the console inside of unity. 
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
            catch (System.Exception) // if an error occurs (button input doesnt work) either the system or application(Unity) reports it to the user
                                     // by throwing an exception containing info about the error. 
            {

            }

        }
    }
}