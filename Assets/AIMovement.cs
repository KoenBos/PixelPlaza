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
        direction = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the character in the current direction
        transform.position += direction * speed * Time.deltaTime;

        // If the character has moved too far in the current direction, choose a new direction
        if (transform.position.magnitude > 10f)
        {
            direction = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
        }
    }
}

