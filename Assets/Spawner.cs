using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    // The game object to spawn
    public GameObject Prefab;

    // The rate at which to spawn it
    public float SpawnRate;
    
    // The x range in which the object will spawn
    public float MinX;
    public float MaxX;

    //private float time;

    // Use this for initialization
    void Start ()
    {
        // Repeatedly call the Spawn method, every 'SpawnRate' seconds
        InvokeRepeating("Spawn", 0, SpawnRate);
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Without the InvokeRepeating method, something akin to the following code would be necessary in order to repeatedly
        // call the Spawn() method

        //time += Time.deltaTime;
        //if (time > SpawnRate)
        //{
        //    Spawn();
        //    time -= SpawnRate;
        //}
    }

    void Spawn()
    {
        // Set the spawn position to the position of this object
        Vector3 spawnPosition = transform.position;

        // Generate a random number in the range (-10, 10)
        float randomX = Random.Range(MinX, MaxX);

        // Assign the spawnPosition vector's x-coordinate to the randomX value, causing the cube to spawn somewhere along the 
        // top of the screen
        spawnPosition.x = randomX;

        // Create a cube prefab, at spawn position with no rotation.
        Instantiate(Prefab, spawnPosition, Quaternion.identity);
    }
}
