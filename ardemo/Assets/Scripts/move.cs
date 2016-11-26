using UnityEngine;
using System.Collections;

public class move : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(new Vector3(0f, .5f, 0f));
        //Vector3 newPos = new Vector3(0f, 0f, Mathf.PingPong(Time.time, 5) + 2f);
        //transform.position = newPos;
    }
}
