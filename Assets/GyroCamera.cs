using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GyroCamera : MonoBehaviour
{
	 void Start()
    {
        Input.gyro.enabled = true;
		Input.gyro.updateInterval = 0.02f;
        Application.targetFrameRate = 60;
       }

     void Update()
    { 
    	transform.rotation = Input.gyro.attitude;
            transform.Rotate(0f, 0f, 180f, Space.Self);
            transform.Rotate(90f, 180f, 0f, Space.World);
 
            transform.Rotate(0f, -0f, 0f, Space.World);  
		
	}

    
}