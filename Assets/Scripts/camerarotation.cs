using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerarotation : MonoBehaviour {
    public GameObject player;
    private Vector3 offset;
    // Use this for initialization
    void Start () {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        offset = transform.position - player.transform.position;
	}

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
    public float yaw = 0.0f;
    public float pitch = 0.0f;
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            yaw += 2.0f * Input.GetAxis("Mouse X");
            pitch -= 2.0f * Input.GetAxis("Mouse Y");
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
 
    }
}
