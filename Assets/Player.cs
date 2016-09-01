using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    // The fastest that this object will move per second
    public float Speed;

    // Use this for initialization
    void Start()
    {
        // Nothing to initialize
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
        // Kill the player game object. All attached components are also destroyed because the GameObject is their container
        Destroy(gameObject);
    }
}
    