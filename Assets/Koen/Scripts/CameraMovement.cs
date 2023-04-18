using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    bool anySelected = false;
    void Update()
    {
        //Move speed for the camera based on the orthographic size of the camera
        float moveSpeed = GetComponent<Camera>().orthographicSize * 4.5f;
        //is there is a character selected the camera will not move and will follow the character and zoom in and out with the character
        foreach (GameObject character in GameObject.Find("Spawner").GetComponent<Spawner>().characters)
        {
            if (character.GetComponent<AI>().selected == true)
            {
                anySelected = true;
                //the camera will follow the character with a lerping effect
                transform.position = Vector3.Lerp(transform.position, new Vector3(character.transform.position.x, character.transform.position.y, -10), Time.deltaTime * 4);
                //the camera will zoom in and out with the character with a lerping effect without a maxspeed
                GetComponent<Camera>().orthographicSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize, 0.7f, Time.deltaTime * 1);
            }
            else
            {
                anySelected = false;
            }
        }
        //if the mouse is pressed down and moved the camera will move with the mouse movement based on the orthographic size of the camera
        if (Input.GetMouseButton(0))
        {
            //the camera will move with the mouse movement
            transform.Translate(-Input.GetAxis("Mouse X") * Time.deltaTime * moveSpeed, -Input.GetAxis("Mouse Y") * Time.deltaTime * moveSpeed, 0);
        }
        //scrolling in and out will change the orthographic size of the camera to zoom in and out
        if (GetComponent<Camera>().orthographicSize >= 0.60f && anySelected  == false && Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            GetComponent<Camera>().orthographicSize -= 0.30f;
        }
        if (GetComponent<Camera>().orthographicSize <= 5f && anySelected  == false && Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            GetComponent<Camera>().orthographicSize += 0.30f;
        }
    }
}