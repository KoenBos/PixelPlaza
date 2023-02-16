using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorScript : MonoBehaviour
{

//a private reference to the mouse position
private Vector2 mousePosition;

void Update()
{
    foreach (GameObject character in GameObject.Find("Spawner").GetComponent<Spawner>().characters)
    {
        //if the mouse is pressed down
        if (Input.GetMouseButtonDown(0))
        {
            //get the mouse position
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //if the mouse position is inside the collider of the character
            if (character.GetComponent<Collider2D>().OverlapPoint(mousePosition))
            {
                //set the character to selected
                character.GetComponent<AI>().selected = true;
            }
            else
            {
                //set the character to not selected
                character.GetComponent<AI>().selected = false;
            }
        }
    }
}

}
