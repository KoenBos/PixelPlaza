using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AI : MonoBehaviour
{

    private Vector2 target = new Vector2(0, 0);
    private float speed = 0.3f;
    
    //time between each move
    private float waitime = 10f;

    private float timer = 0;


    // Start is called before the first frame update
    void Start()
    {
        //a random offset for the timer so that the objects don't all move at the same time
        timer = Random.Range(0, 10);
        waitime = Random.Range(7, 10);
        
        target = transform.position;
    }



    // Update is called once per frame
    void Update()
    {
        //add 1 to the timer every second
        timer += Time.deltaTime;
        //if the timer is greater than the waittime then move towards the target
        if (timer > waitime)
        {
            //move towards target with a lerping speed
            //if the distance between the target and the object is less than 0.1 then change the target to a new random position on the screen and reset the timer to 0
            timer = 0;
            target = new Vector2(Random.Range(-8, 8), Random.Range(-5, 5));
        }
        transform.position = Vector2.Lerp(transform.position, target, speed * Time.deltaTime);





    }
}
