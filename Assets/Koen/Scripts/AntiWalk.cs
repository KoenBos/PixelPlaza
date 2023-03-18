using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiWalk : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //make sprite invisible when game starts
        GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
