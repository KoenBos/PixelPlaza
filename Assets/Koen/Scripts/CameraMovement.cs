using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
//update is called once per frame
    void Update()
    {
        //if the mouse is pressed down and moved the camera will move with the mouse movement based on the orthographic size of the camera
        if (Input.GetMouseButton(0))
        {
            //the camera will move with the mouse movement
            transform.Translate(-Input.GetAxis("Mouse X") * Time.deltaTime * 10, -Input.GetAxis("Mouse Y") * Time.deltaTime * 10, 0);
        }
        //scrolling in and out will change the orthographic size of the camera to zoom in and out
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            GetComponent<Camera>().orthographicSize -= 1;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            GetComponent<Camera>().orthographicSize += 1;
        }
    }
}