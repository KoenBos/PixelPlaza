using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AI : MonoBehaviour
{
    //a bool to check if the character is selected
    public bool selected = false;
    private Vector3 target = new Vector3(0, 0, 0);
    private float maxSpeed = 0.3f;
    private float startSpeed = 0.05f;
    private float waittime = 25f;
    private float timer = 0;

    //a refrence to the panel in canvas in this prefab
    [SerializeField] private GameObject panel;

    //a reference to the bool walking in the animator
    private Animator animator;

    
    // Start is called before the first frame update
    void Start()
    {
        //dont collide with other characters
        Physics2D.IgnoreLayerCollision(3, 3, true);

        animator = GetComponent<Animator>();
        timer = Random.Range(0, 25);
        waittime = Random.Range(25, 30);
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waittime)
        {
            timer = 0;
            target = new Vector3(Random.Range(transform.position.x - 4, transform.position.x + 4), Random.Range(transform.position.y - 4, transform.position.y + 4), 0);
            while(target.x > 10.2 || target.x < -10.2 || target.y > 10.2 || target.y < -10.2){
                Debug.Log("Making new target");
                target = new Vector3(Random.Range(transform.position.x - 4, transform.position.x + 4), Random.Range(transform.position.y - 4, transform.position.y + 4), 0);
            }

            if  (target.x > 10.2 || target.x < -10.2 || target.y > 10.2 || target.y < -10.2)
            {
                //log outside of the map
                Debug.Log("outside of the map");
            }
        }
        
        float distance = Vector2.Distance(transform.position, target);
        float speed = Mathf.Lerp(startSpeed, maxSpeed, Mathf.Min(1f, timer / 10f));
        transform.position = Vector2.Lerp(transform.position, target, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target) < 0.5f)
        {
            animator.SetBool("walking", false);
        }
        else
        {
            animator.SetBool("walking", true);
        }
        if (selected == true)
        {
            //the panel will be active
            panel.SetActive(true);

        }
        else
        {
            //the panel will be inactive
            panel.SetActive(false);
        }

    }


}
