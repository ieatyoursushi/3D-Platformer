using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class Money : MonoBehaviour {
    public static int Currency;
    public Text score;
     
	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<AudioSource>().volume = 0.2f;
    }
 
    // Update is called once per frame
    void Update () {
        var scene = SceneManager.GetActiveScene().name == "StartMenu";
        var scene2 = SceneManager.GetActiveScene().name == "StartMenu 1";
        var scene3 = SceneManager.GetActiveScene().name == "StartMenu 2";
        var scene4 = SceneManager.GetActiveScene().name == "StartMenu 3";
        if (scene == true || scene2 == true || scene3 == true || scene4 == true)
        {
            score.text = "BALAnCE: $" + Currency.ToString();
        } else
        {
            score.text = "$" + Currency.ToString();
        }
         
	}
    
    private void OnCollisionEnter(Collision col)
    {
        var superCapsule = gameObject.tag == "superCapsule";
        if (col.gameObject.tag == "player")
        {
            
            if (superCapsule == true) 
            {
                Currency += Random.Range(34, 80);
            } else
            {
                Currency += Random.Range(5, 25);
            }
            
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            this.gameObject.GetComponent<AudioSource>().Play();

        }
    }
}
