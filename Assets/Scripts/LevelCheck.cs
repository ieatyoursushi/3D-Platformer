using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class LevelCheck : MonoBehaviour {
    bool unlocked1 = false;
    public Text text1;
    
	// Use this for initialization
	void Start () {
		
	}
	public void unlock1()
    {
        if(scenes.level5unlock)
        {
            if (unlocked1 == false)
            {
                this.gameObject.GetComponent<AudioSource>().Play();
                Money.Currency += 400;
                unlocked1 = true;
            }
             
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
