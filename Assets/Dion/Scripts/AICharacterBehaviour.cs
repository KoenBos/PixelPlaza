using UnityEngine;

public class AICharacterBehavior : MonoBehaviour
{
    // The character data from the JSON
    public int ID;
    public string firstName;
    public string lastName;
    public int cohort;
    public string portfolioLink;

    // The AI movement and behavior parameters
    public float moveSpeed = 2f;
    public float minMoveTime = 1f;
    public float maxMoveTime = 3f;

    private float moveTime = 0f;
    private Vector2 moveDirection = Vector2.zero;

    private void Start()
    {
        // Set the initial movement direction and time
        moveDirection = GetRandomMoveDirection();
        moveTime = GetRandomMoveTime();
    }

    private void Update()
    {
        // Move the character in the current direction
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Check if it's time to change the movement direction
        moveTime -= Time.deltaTime;
        if (moveTime <= 0f)
        {
            moveDirection = GetRandomMoveDirection();
            moveTime = GetRandomMoveTime();
        }
    }

    private Vector2 GetRandomMoveDirection()
    {
        // Generate a random movement direction
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        return new Vector2(x, y).normalized;
    }

    private float GetRandomMoveTime()
    {
        // Generate a random time for the character to move in a single direction
        return Random.Range(minMoveTime, maxMoveTime);
    }
}

