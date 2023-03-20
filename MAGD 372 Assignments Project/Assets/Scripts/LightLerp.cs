using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLerp : MonoBehaviour
{
    public float smooth = 2;
    private Vector3 newPosition;
    private float newIntensity; 
    Light myLight;
    private Color newColor; 
    
    void Awake()
    {
        newPosition = transform.position;
        myLight = GetComponent<Light>();
        newColor = myLight.color; 
    }

    // Update is called once per frame
    void Update()
    {
        positionChanging();
        IntensityChanging();
        ColorChanging(); 
    }

    void positionChanging()
    {
        Vector3 positionA = new Vector3(-5, 3, 0);
        Vector3 positionB = new Vector3(5, 3, 0);

        if(Input.GetKeyDown(KeyCode.Q))
        {
            newPosition = positionA; 
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            newPosition = positionB; 
        }
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * smooth); 
    }

    void IntensityChanging()
    {
        float intensityA = 8f;
        float intensityB = 16f;

        if (Input.GetKeyDown(KeyCode.A))
        {
            newIntensity = intensityA;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            newIntensity = intensityB;
        }
        myLight.intensity = Mathf.Lerp(myLight.intensity, newIntensity, Time.deltaTime * smooth);
    }

    void ColorChanging()
    {
        Color colorA = Color.red;
        Color colorB = Color.green;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            newColor = colorA;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            newColor = colorB;
        }
        myLight.color = Color.Lerp(myLight.color, newColor, Time.deltaTime * smooth);

    }
}
