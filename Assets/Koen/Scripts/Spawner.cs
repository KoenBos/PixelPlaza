using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //a list of all the characters in the scene
    public List<GameObject> characters = new List<GameObject>();

    [SerializeField] private GameObject prefab;


    // Start is called before the first frame update
    void Start()
    {
            for (int i = 0; i < 10; i++)
            {
                //create a new character from the prefab
                GameObject character = Instantiate(prefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity, transform);

                //add the character to layer 3 (characters)
                character.layer = 3;
                
                //put the character in the list
                characters.Add(character);
            }
        }
    }
