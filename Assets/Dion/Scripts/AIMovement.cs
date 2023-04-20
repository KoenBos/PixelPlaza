using UnityEngine;

public class AIMovement : MonoBehaviour
{
    // The speed at which the character moves
    public float speed = 2f;

    // The direction in which the character is currently moving
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        // Set the initial direction of the character to a random direction
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
        transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5), 0f);
    }


    // Update is called once per frame
    void Update()
    {
        // Move the character in the current direction
        transform.position += new Vector3(direction.x, direction.y, 0f) * speed * Time.deltaTime;

        // If the character has moved too far in the current direction, choose a new direction
        if (transform.position.magnitude > 10f)
        {
            direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
        }
    }
}

