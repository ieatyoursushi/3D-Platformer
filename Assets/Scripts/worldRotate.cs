using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldRotate : MonoBehaviour {
    //grab the world itself
    public Vector3 offset;
    public GameObject World;
    public GameObject Player;
    //determine how fast the world will rotate
    public float speed = 60f;
    //on awake grab the world game object
    private void Awake()
    {
        World = gameObject;
    }
    private void FixedUpdate()
    {
         
        //key press rotate right
        if (Input.GetKey("e"))
        {
            //World.transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }
        if (Input.GetKey("q"))
        {
            //World.transform.Rotate(-Vector3.up * speed * Time.deltaTime);
        }
    }
    //get the key press to rotate it right 

    //get the key press to rotate it left 

}
