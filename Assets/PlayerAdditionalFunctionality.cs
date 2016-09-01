using UnityEngine;
using System.Collections;

public class PlayerAdditionalFunctionality : MonoBehaviour
{
    // The fastest that this object will move per second
    public float Speed = 10;

    // The number of times the player can get hit by a cube before dying
    public int StartLives = 3;

    // The colour the player starts and the colour the player becomes when damaged
    public Color StartColour;
    public Color DamageColour;

    private int currentLives;

    // Use this for initialization
    void Start ()
    {
        currentLives = StartLives;

        // Get ths attached Renderer component
        Renderer renderer = GetComponent<Renderer>();

        // Get the renderer's material. The material stores information about how an object is drawn.
        Material material = renderer.material;

        // Set the renderers colour to the player's beginning colour
        material.color = StartColour;
	}

    // Update is called once per frame
    void Update()
    {
        // GetAxis translates a key press into a scalar value between -1 and 1 based on which of the axis keys is pressed, 
        // and for how long. Input keys for the horizontal axis are 'a' and 'd', and 'left' and 'right'
        float horizontalInput = Input.GetAxis("Horizontal");

        // Vector3.right and the sign (+/-) of 'horizontalInput' describe the DIRECTION of movment
        // The value of 'horizontalInput' and MaximumSpeed describe the DISTANCE of movement
        // Time.deltaTime describes the rate (per second)
        Vector3 movement = Vector3.right * Speed * horizontalInput * Time.deltaTime;

        // transform.Translate moves THIS object in the direction and distance describe by the given vector
        transform.Translate(movement);
    }

    // Called when the object is contacted by another collider that has a rigidbody component attached to it
    void OnCollisionEnter()
    {
        // Hit by a cube: lose a life
        currentLives--;

        // Calculates a colour that is part-way between DamageColour and StartColour. 't' determines how
        // far between: 
            // t = 0.0 = all DamageColour, 
            // t = 1.0 = all StartColour, 
            // t = 0.5 = 50% DamageCoour 50% StartColour
        float t = currentLives / (float)StartLives;
        Color colour = Color.Lerp(DamageColour, StartColour, t);

        // Get ths attached Renderer component
        Renderer renderer = GetComponent<Renderer>();

        // Get the renderer's material
        Material material = renderer.material;

        // Set the renderers colour to the calculated colour
        material.color = colour;

        if (currentLives == 0)
        {
            // Kill the player game object. All attached components are also destroyed because the GameObject is their container
            Destroy(gameObject);

            // Find the game object named 'CubeSpawner' in the scene, by name
            GameObject cubeSpawnObject = GameObject.Find("CubeSpawner");

            // Get the 'CubeSpawner' component from the gameObject
            Spawner cubeSpawner = cubeSpawnObject.GetComponent<Spawner>();

            // Tell the cubeSpawner to stop spawning cubes
            cubeSpawner.CancelInvoke();
        }
    }
}
