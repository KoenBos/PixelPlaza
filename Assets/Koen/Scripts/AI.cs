using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AI : MonoBehaviour
{
    private Vector2 target = new Vector2(0, 0);
    private float maxSpeed = 0.3f;
    private float startSpeed = 0.05f;
    private float waitime = 10f;
    private float timer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(0, 10);
        waitime = Random.Range(7, 10);
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitime)
        {
            timer = 0;
            target = new Vector2(Random.Range(-8, 8), Random.Range(-5, 5));
        }
        
        float distance = Vector2.Distance(transform.position, target);
        float speed = Mathf.Lerp(startSpeed, maxSpeed, Mathf.Min(1f, timer / 10f));
        transform.position = Vector2.Lerp(transform.position, target, speed * Time.deltaTime);
    }
}
