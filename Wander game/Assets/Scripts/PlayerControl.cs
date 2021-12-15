using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject EText;
    public GameObject CameraAnimation;
    public Animator SongVol;
    bool AnimationScene = false;
	CharacterController PlayerController;

    //Movement
    Vector3 PlayerMovement;
    float PlayerX;
    float PlayerZ;
    [SerializeField]
    public float MovementSpeed = 5f; //Multipler

    //Gravity
    //Vector3 GravityVector;
    [SerializeField]
    private float Gravity = 9.81f;

    //Jump
    [SerializeField]
    private float JumpSpeed = 1.4f;
    private float PlayerDirection_Y;


    void Start()
    {
        PlayerController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Move();
        //Debugging();

        //To change scenes
        if(AnimationScene == true)
        {
            EText.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                CameraAnimation.SetActive(true);
                SongVol.enabled = true;
            }
        }
        else if(AnimationScene == false && EText != null && CameraAnimation != null)
        {
            EText.SetActive(false);
            CameraAnimation.SetActive(false);
            SongVol.enabled = false;
        }
    }

    void Move()
    {
        //WASD movement
        PlayerX = Input.GetAxis("Horizontal");
        PlayerZ = Input.GetAxis("Vertical");
        PlayerMovement = transform.right * PlayerX + transform.forward * PlayerZ;    

        //Press Space to jump
        if (Input.GetKeyDown(KeyCode.Space) && PlayerController.isGrounded)
        {
            PlayerDirection_Y = JumpSpeed;
        }

        // Add gravity to Y-axis movement
        PlayerDirection_Y -= Gravity * Time.deltaTime;
        PlayerMovement.y = PlayerDirection_Y;

        // Finally, move the player
        PlayerController.Move(PlayerMovement * MovementSpeed * Time.deltaTime);

    }

    //Debugs
    void Debugging()
	{
		//Touching Ground
        /*if(PlayerController.isGrounded)
        {
        	Debug.Log("Grounded");
        }*/

        //Console Writes
    	if(Input.GetKey(KeyCode.W))
    	{
    		Debug.Log("Forward");
    	}
    	else if(Input.GetKey(KeyCode.S))
    	{
    		Debug.Log("Backwards");
    	}
    	else if(Input.GetKey(KeyCode.D))
    	{
    		Debug.Log("Right");
    	}
        else if(Input.GetKey(KeyCode.A))
        {
            Debug.Log("Left");
        }
	}

    //Collider Triggers
    void OnTriggerEnter(Collider TchEnt)
    {
        if(TchEnt.gameObject.name == "Sit Animation Activation")
        {
            AnimationScene = true;
        }

        if(TchEnt.gameObject.name == "Trigger 1")
        {
            //Something Happen Here
        }

        if(TchEnt.gameObject.name == "Trigger 2")
        {
            //Something Happen Here
        }

        if(TchEnt.gameObject.name == "Trigger 3")
        {
            //Something Happen Here
        }
    }

    void OnTriggerExit(Collider TchExt)
    {
        if(TchExt.gameObject.name == "Sit Animation Activation")
        {
            AnimationScene = false;
        }
    }
}
