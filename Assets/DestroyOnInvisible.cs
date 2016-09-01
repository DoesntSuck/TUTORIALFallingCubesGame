using UnityEngine;
using System.Collections;

public class DestroyOnInvisible : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Method is called when the object is no longer visible to ANY camera. 
    // Object has to have been seen before this method will be called.
    public void OnBecameInvisible()
    {
        // Get rid of the cube to prevent cubes from filling up the hierarchy
        Destroy(gameObject);
    }
}
