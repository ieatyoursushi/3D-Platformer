using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class scenes : MonoBehaviour {

    [SerializeField] public static bool level1beat = false;
    [SerializeField] public static bool level2unlock = false;
    [SerializeField] public static bool level4unlock= false;
    [SerializeField] public static bool level5unlock = false;
    [SerializeField] public static bool[] levelsUnlocked = new bool[4];

    public Text text1;
    public Text text2;
    public Text text3;
    // Use this for initialization
    void Start () {
		if(level2unlock)
        {
            text1.text = "Level 2".ToString(); 
        }
        if (level4unlock)
        {
            text2.text = "Level 3";
        }
        if (level5unlock)
        {
            text3.text = "Level 4";
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Level2()
    {
        if (level2unlock)
        {
            SceneManager.LoadScene("Level2");
            
        }
    }
    public void Level4()
    {
        if (level4unlock)
        {
            SceneManager.LoadScene("Level4");
            
        }
    }
    public void Level5()
    {
        if (level5unlock)
        {
            SceneManager.LoadScene("Level5");
             
        }
    }
    public void StartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void shop()
    {
        SceneManager.LoadScene("StartMenu 1");
    }
    public void shop2()
    {
        SceneManager.LoadScene("StartMenu 2");
    }
    public void shop3()
    {
        SceneManager.LoadScene("StartMenu 3");
    }
    public void levels()
    {
        SceneManager.LoadScene("StartMenu 4");
    }
    public void achievements()
    {
        SceneManager.LoadScene("StartMenu 6");
    }
}
