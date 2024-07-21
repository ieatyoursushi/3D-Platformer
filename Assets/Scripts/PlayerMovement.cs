using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    public float yaw = 0.0f;
    public float pitch = 0.0f;
    public GameObject Camera;
    //player speed
    public float speed = 6f;
    //jump
    public float jumpForce = 3f;
    [SerializeField] public bool isGrounded;
    private Vector3 movement; // store the movement we want to apply to the player
    private Rigidbody playerRigidbody; // reference ot the player's rigidbody
    //audio source
    public AudioSource JumpAudio;
    public AudioSource JumpAudio2;
    public AudioSource JumpAudio3;
    // execute when the scene loads
    private void Awake()
    {
        // set player rb variable to the player's rigidbody
        playerRigidbody = GetComponent<Rigidbody>();
        Panel.SetActive(false);
    }
 


    void OnCollisionEnter(Collision col)
    {

        isGrounded = true;
        if (col.gameObject.tag == "FinishLine")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("colliee4d");
        }
        bool played = false;
        if (col.gameObject.tag == "enemy")
        {
            Invoke("The_World", 0.2f);
            Panel.SetActive(true);
            if (!JumpAudio.isPlaying)
            {
                played = true;
                JumpAudio.Play();
            }
            if (played == true)
            {
                Invoke("Mute", 0.5f);

            }

            Debug.Log("colide enemy");
        }
        if (col.gameObject.name == "Check1")
        {
            Debug.Log("collision successful");
            scenes.level2unlock = true;
        }
        if (col.gameObject.name == "Check2")
        {
            Debug.Log("collision successful");
            scenes.level4unlock = true;
        }
        if (col.gameObject.name == "Check3")
        {
            Debug.Log("collision successful");
            scenes.level5unlock = true;
        }

    }
    void death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //fires every physics update
    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
    }
    public GameObject Panel;

    private void Update()
    {
 
        //jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // add force to the player to make them jump
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //we are no longer on the ground
            isGrounded = false;
            //add sound effects
            if (!JumpAudio2.isPlaying)
            {
                JumpAudio2.Play();
            }
        }
        // restarts level when player falls
        if (playerRigidbody.position.y <= -4f)
        {
            bool played = false;
            Invoke("The_World", 0.7f);
            Panel.SetActive(true);
            if (!JumpAudio3.isPlaying)
            {
                played = true;
                JumpAudio3.Play();
            }
            if (played == true)
            {
                Invoke("Mute", 0.7f);
            }

        }
         

    }
    void The_World()
    {
        Time.timeScale = 0;
    }
    void Mute()
    {
        JumpAudio3.mute = true;
    }
    public void SceneLoad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // create move function
    void Move(float h, float v)
    {
        // set movement vector
        movement.Set(h, 0f, v);
        // normalize vectors so no speed boost is given
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }
    //skins
    public GameObject PlayerPrefab;
    static int skinNumber;
    [SerializeField] public Material[] materials = new Material[10];
     
    private void Start()
    {
        float max_value = 10;
        Time.timeScale = 1;
        PlayerPrefab.GetComponent<Renderer>().material = materials[skinNumber];
        Debug.Log("Index: " + skinNumber);
        if (Owned == true)
        {
            text1.text = "Grass \n(owned)";
        }
        if (Owned1 == true)
        {
            text2.text = "Dirt \n(owned)";
        }
        if (Owned2 == true)
        {
            text3.text = "Stone \n(owned)";
        }
        if (Owned3 == true)
        {
            text4.text = "Brick \n(owned)";
        }
        if (Owned4 == true)
        {
            text5.text = "Gold \nBrick \n(owned)";
        }
        if (Owned5 == true)
        {
            text6.text = "Rainbow \n(owned)";
        }

 
            if (Owned6 == true)
            {
                text7.text = "Matrix \n(owned)";
            }
            if (Owned7 == true)
            {
                text8.text = "Code \n(owned)";
            }
            if (Owned8 == true)
            {
                text9.text = "Tiles \n(owned)";
            }
            if (Owned9 == true)
            {
                text10.text = "Disco \n(owned)";
            }
            if (Owned10 == true)
            {
                text11.text = "Disco 2 \n(owned)";
            }
            if (Owned11 == true)
            {
                text12.text = "Ocean \n(owned)";
            }
            if (Owned12 == true)
            {
                text13.text = "Quilt \n(owned)";
            }
        if (Owned13 == true)
        {
            text14.text = "Gamma \n(owned)";
        }
        if (Owned14 == true)
        {
            text15.text = "Enemy \n(owned)";
        }
        if (Owned15 == true)
        {
            text16.text = "Yellow \n(owned)";
        }
        if (Owned16 == true)
        {
            text17.text = "Black \n(owned)";
        }
        if (Owned17 == true)
        {
            text18.text = "Blue \n(owned)";
        }




    }
    public AudioSource purchase;
    public AudioSource Equip;
    public AudioSource Deny;
    //skins
    public void skin0()
    {
        skinNumber = 0;
        if (!Equip.isPlaying)
        {
            Equip.Play();
        }
    }

    
    public void skin1()
    {
        
        if (Money.Currency >= 25 && Owned == false)
        {
            text1.text = "Grass \n(owned)";
            Owned = true;
            skinNumber = 1;
            Money.Currency -= 25;
            if(!purchase.isPlaying)
            {
                purchase.Play();
            }
        }
        if(Owned == true)
        {
            
            skinNumber = 1;
            if(!Equip.isPlaying)
            {
                Equip.Play();
            }
        } else if (Owned == false)
        {
            if(!Deny.isPlaying)
            {
                Deny.Play();
            }
        }
    }
    public void skin2()
    {
        
        if (Money.Currency >= 25 && Owned1 == false)
        {
            text2.text = "Dirt \n(owned)";
            Owned1 = true;
            skinNumber = 2;
            Money.Currency -= 25;
            if (!purchase.isPlaying)
            {
                purchase.Play();
            }
        }
        if (Owned1 == true)
        {

            skinNumber = 2;
            if (!Equip.isPlaying)
            {
                Equip.Play();
            }
        }
        else if (Owned1 == false)
        {
            if (!Deny.isPlaying)
            {
                Deny.Play();
            }
        }
    }
    public void skin3()
    {
        if (Money.Currency >=50 && Owned2 == false)
        {
            text3.text = "Stone \n(owned)";
            Owned2 = true;
            skinNumber = 3;
            Money.Currency -= 50;
            if (!purchase.isPlaying)
            {
                purchase.Play();
            }
        }
        if (Owned2 == true)
        {

            skinNumber = 3;
            if (!Equip.isPlaying)
            {
                Equip.Play();
            }
        }
        else if (Owned2 == false)
        {
            if (!Deny.isPlaying)
            {
                Deny.Play();
            }
        }
    }
    public void skin4()
    {
        if (Money.Currency >= 50 && Owned3 == false)
        {
            text4.text = "Brick \n(owned)";
            Owned3 = true;
            skinNumber = 4;
            Money.Currency -= 50;
            if (!purchase.isPlaying)
            {
                purchase.Play();
            }
        }
        if (Owned3 == true)
        {

            skinNumber = 4;
            if (!Equip.isPlaying)
            {
                Equip.Play();
            }
        }
        else if (Owned3 == false)
        {
            if (!Deny.isPlaying)
            {
                Deny.Play();
            }
        }

    }
    public void skin5()
    {
        if (Money.Currency >= 350 && Owned4 == false)
        {
            text5.text = "Gold \nBrick \n(owned)";
            Owned4 = true;
            skinNumber = 5;
            Money.Currency -= 350;
            if (!purchase.isPlaying)
            {
                purchase.Play();
            }
        }
        if (Owned4== true)
        {

            skinNumber = 5;
            if (!Equip.isPlaying)
            {
                Equip.Play();
            }
        }
        else if (Owned4 == false)
        {
            if (!Deny.isPlaying)
            {
                Deny.Play();
            }
        }
    }
    public void skin6()
    {
        if (Money.Currency >= 80 && Owned5 == false)
        {
            text6.text = "Rainbow \n(owned)";
            Owned5 = true;
            skinNumber = 6;
            Money.Currency -= 80;
            if (!purchase.isPlaying)
            {
                purchase.Play();
            }
        }
        if (Owned5 == true)
        {

            skinNumber = 6;
            if (!Equip.isPlaying)
            {
                Equip.Play();
            }
        }
        else if (Owned5 == false)
        {
            if (!Deny.isPlaying)
            {
                Deny.Play();
            }
        }
    }
    public void skin7()
    {
        if (Money.Currency >= 200 && Owned6 == false)
        {
            text7.text = "Matrix \n(owned)";
            Owned6 = true;
            skinNumber = 7;
            Money.Currency -= 200;
            if (!purchase.isPlaying)
            {
                purchase.Play();
            }
        }
        if (Owned6 == true)
        {

            skinNumber = 7;
            if (!Equip.isPlaying)
            {
                Equip.Play();
            }
        }
        else if (Owned6 == false)
        {
            if (!Deny.isPlaying)
            {
                Deny.Play();
            }
        }
    }
    public void skin8()
    {
        if (Money.Currency >= 200 && Owned7 == false)
        {
            text8.text = "Code \n(owned)";
            Owned7 = true;
            skinNumber = 8;
            Money.Currency -= 200;
            if (!purchase.isPlaying)
            {
                purchase.Play();
            }
        }
        if (Owned7 == true)
        {

            skinNumber = 8;
            if (!Equip.isPlaying)
            {
                Equip.Play();
            }
        }
        else if (Owned7 == false)
        {
            if (!Deny.isPlaying)
            {
                Deny.Play();
            }
        }
    }
    public void skin9()
    {
        if (Money.Currency >= 120 && Owned8 == false)
        {
            text9.text = "Tiles \n(owned)";
            Owned8 = true;
            skinNumber = 9;
            Money.Currency -= 120;
            if (!purchase.isPlaying)
            {
                purchase.Play();
            }
        }
        if (Owned8 == true)
        {

            skinNumber = 9;
            if (!Equip.isPlaying)
            {
                Equip.Play();
            }
        }
        else if (Owned8 == false)
        {
            if (!Deny.isPlaying)
            {
                Deny.Play();
            }
        }
    }
    public void skin10()
    {
        if (Money.Currency >= 180 && Owned9 == false)
        {
            text10.text = "Disco \n(owned)";
            Owned9 = true;
            skinNumber = 10;
            Money.Currency -= 180;
            if (!purchase.isPlaying)
            {
                purchase.Play();
            }
        }
        if (Owned9 == true)
        {

            skinNumber = 10;
            if (!Equip.isPlaying)
            {
                Equip.Play();
            }
        }
        else if (Owned9 == false)
        {
            if (!Deny.isPlaying)
            {
                Deny.Play();
            }
        }
    }
    public void skin11()
    {
        if (Money.Currency >= 180 && Owned10 == false)
        {
            text11.text = "Disco 2\n(owned)";
            Owned10 = true;
            skinNumber = 11;
            Money.Currency -= 180;
            if (!purchase.isPlaying)
            {
                purchase.Play();
            }
        }
        if (Owned10 == true)
        {

            skinNumber = 11;
            if (!Equip.isPlaying)
            {
                Equip.Play();
            }
        }
        else if (Owned10 == false)
        {
            if (!Deny.isPlaying)
            {
                Deny.Play();
            }
        }
    }
    public void skin12()
    {
        if (Money.Currency >= 150 && Owned11 == false)
        {
            text12.text = "Ocean \n(owned)";
            Owned11 = true;
            skinNumber = 12;
            Money.Currency -= 150;
            if (!purchase.isPlaying)
            {
                purchase.Play();
            }
        }
        if (Owned11 == true)
        {

            skinNumber = 12;
            if (!Equip.isPlaying)
            {
                Equip.Play();
            }
        }
        else if (Owned11 == false)
        {
            if (!Deny.isPlaying)
            {
                Deny.Play();
            }
        }
    }
    public void skin13()
    {
        if (Money.Currency >= 200 && Owned12 == false)
        {
            text13.text = "Quilt \n(owned)";
            Owned12 = true;
            skinNumber = 13;
            Money.Currency -= 200;
            if (!purchase.isPlaying)
            {
                purchase.Play();
            }
        }
        if (Owned12 == true)
        {

            skinNumber = 13;
            if (!Equip.isPlaying)
            {
                Equip.Play();
            }
        }
        else if (Owned12 == false)
        {
            if (!Deny.isPlaying)
            {
                Deny.Play();
            }
        }
    }
    public void skin14()
    {
        if (Money.Currency >= 100 && Owned13 == false)
        {
            text14.text = "Gamma \n(owned)";
            Owned13 = true;
            skinNumber = 14;
            Money.Currency -= 100;
            if (!purchase.isPlaying)
            {
                purchase.Play();
            }
        }
        if (Owned13 == true)
        {

            skinNumber = 14;
            if (!Equip.isPlaying)
            {
                Equip.Play();
            }
        }
        else if (Owned13 == false)
        {
            if (!Deny.isPlaying)
            {
                Deny.Play();
            }
        }
    }
    public void skin15()
    {
        if (Money.Currency >= 200 && Owned14 == false)
        {
            text15.text = "Enemy \n(owned)";
            Owned14 = true;
            skinNumber = 15;
            Money.Currency -= 200;
            if (!purchase.isPlaying)
            {
                purchase.Play();
            }
        }
        if (Owned14 == true)
        {

            skinNumber = 15;
            if (!Equip.isPlaying)
            {
                Equip.Play();
            }
        }
        else if (Owned14 == false)
        {
            if (!Deny.isPlaying)
            {
                Deny.Play();
            }
        }
    }
    public void skin16()
    {
        if (Money.Currency >= 10 && Owned15 == false)
        {
            text16.text = "Yellow \n(owned)";
            Owned15 = true;
            skinNumber = 16;
            Money.Currency -= 10;
            if (!purchase.isPlaying)
            {
                purchase.Play();
            }
        }
        if (Owned15 == true)
        {

            skinNumber = 16;
            if (!Equip.isPlaying)
            {
                Equip.Play();
            }
        }
        else if (Owned15 == false)
        {
            if (!Deny.isPlaying)
            {
                Deny.Play();
            }
        }
    }
    public void skin17()
    {
        if (Money.Currency >= 10 && Owned16 == false)
        {
            text17.text = "Black \n(owned)";
            Owned16 = true;
            skinNumber = 17;
            Money.Currency -= 10;
            if (!purchase.isPlaying)
            {
                purchase.Play();
            }
        }
        if (Owned16 == true)
        {

            skinNumber = 17;
            if (!Equip.isPlaying)
            {
                Equip.Play();
            }
        }
        else if (Owned16 == false)
        {
            if (!Deny.isPlaying)
            {
                Deny.Play();
            }
        }
    }
    public void skin18()
    {
        if (Money.Currency >= 10 && Owned17 == false)
        {
            text18.text = "Blue \n(owned)";
            Owned17 = true;
            skinNumber = 18;
            Money.Currency -= 10;
            if (!purchase.isPlaying)
            {
                purchase.Play();
            }
        }
        if (Owned17 == true)
        {

            skinNumber = 18;
            if (!Equip.isPlaying)
            {
                Equip.Play();
            }
        }
        else if (Owned17 == false)
        {
            if (!Deny.isPlaying)
            {
                Deny.Play();
            }
        }
    }

    [SerializeField] public Text text1;
    [SerializeField] public Text text2;
    [SerializeField] public Text text3;
    [SerializeField] public Text text4;
    [SerializeField] public Text text5;
    [SerializeField] public Text text6;
    [SerializeField] public Text text7;
    [SerializeField] public Text text8;
    [SerializeField] public Text text9;
    [SerializeField] public Text text10;
    [SerializeField] public Text text11;
    [SerializeField] public Text text12;
    [SerializeField] public Text text13;
    [SerializeField] public Text text14;
    [SerializeField] public Text text15;
    [SerializeField] public Text text16;
    [SerializeField] public Text text17;
    [SerializeField] public Text text18;

    static bool Owned = false;
    static bool Owned1 = false;
    static bool Owned2 = false;
    static bool Owned3 = false;
    static bool Owned4 = false;
    static bool Owned5 = false;
    static bool Owned6 = false;
    static bool Owned7 = false;
    static bool Owned8 = false;
    static bool Owned9 = false;
    static bool Owned10 = false;
    static bool Owned11 = false;
    static bool Owned12 = false;
    static bool Owned13 = false;
    static bool Owned14 = false;
    static bool Owned15 = false;
    static bool Owned16 = false;
    static bool Owned17 = false;
 
}
 
 