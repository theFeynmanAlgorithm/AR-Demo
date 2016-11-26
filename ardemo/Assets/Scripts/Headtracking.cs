using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Headtracking : MonoBehaviour {

    //public Text rotX;
    //public Text rotY;
    //public Text rotZ;

    [Range(0f,1f)]
    public float smoothingFactor;
    
    float smoothedRotationX;
    float smoothedRotationY;
    float smoothedRotationZ;

    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Input.gyro.enabled = true;

        smoothedRotationX = Input.acceleration.x * 90f;
        smoothedRotationY = Input.acceleration.y * 90f;
        smoothedRotationZ = Input.gyro.attitude.eulerAngles.z - 180f;
    }

	void Update()
    {
        float xRotate = Input.acceleration.x * 90;
        float yRotate = Input.acceleration.y * 90;
        float zRotate = Input.gyro.attitude.eulerAngles.z - 180f;
        
        smoothedRotationX = smoothingFactor * xRotate + (1 - smoothingFactor) * smoothedRotationX;
        smoothedRotationY = smoothingFactor * yRotate + (1 - smoothingFactor) * smoothedRotationY;
        smoothedRotationZ = smoothingFactor * zRotate + (1 - smoothingFactor) * smoothedRotationZ;

        transform.rotation = Quaternion.Euler(new Vector3(smoothedRotationY, smoothedRotationZ, smoothedRotationX));
        //rotX.text = "X: " + smoothedRotationX.ToString("F1");
        //rotY.text = "Y: " + smoothedRotationY.ToString("F1");
        //rotZ.text = zRotate.ToString("F1");
    }
}
