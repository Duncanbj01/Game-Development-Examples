using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpRotation : MonoBehaviour
{
    Vector3 relativePosition;
    Quaternion targetRotation;

    public Transform target;
    public float speed = 0.1f;

    bool rotating = false;

    float rotationTime; //when rotationTime == 1, will have rotated to our target

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            relativePosition = target.position - transform.position;
            targetRotation = Quaternion.LookRotation(relativePosition);
            rotating = true;
            rotationTime = 0; 
        }

        if (rotating)
        {
            rotationTime += Time.deltaTime; 

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationTime);
        }

        if(rotationTime > 1)
        {
            rotating = false; 
        }
    }
}


//rotating FROM A -------> B
//             
//              0 -------> 1.
