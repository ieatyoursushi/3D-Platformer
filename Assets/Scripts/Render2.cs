using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Render2 : MonoBehaviour
{
    bool invisible = true;
    public float delay = 0.5f;
    public float StartDelay = 0.5f;
    // Use this for initialization
    void Start()
    {
        var Render = this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        var notRender = this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        Invoke("notInvisible", StartDelay);
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        if (invisible)
        {
            Invoke("notInvisible", delay);
        }
        else if (!invisible)
        {
            Invoke("Invisible", delay);
        }
    }
    void Invisible()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.GetComponent<Collider>().enabled = false;
        invisible = true;
    }

    void notInvisible()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        this.gameObject.GetComponent<Collider>().enabled = true;
        invisible = false;
    }
}
