using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlFloat : MonoBehaviour
{
	CharacterController PlayerController;
    Rigidbody PlayerBody;

    //Movement
    Vector3 PlayerMovement;
    float PlayerX;
    float PlayerY;
    float PlayerZ;
    [SerializeField]
    public float MovementSpeed = 5f; //Multipler

    void Start()
    {
        PlayerController = GetComponent<CharacterController>();
        PlayerBody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        Move();
        //Debugging();
    }

    //WASD Floating Movement
    void Move()
    {
        if(Input.GetKey(KeyCode.W))
        {
            PlayerBody.AddForce(transform.forward * MovementSpeed * Time.deltaTime, ForceMode.Impulse);
        }
        if(Input.GetKey(KeyCode.S))
        {
            PlayerBody.AddForce(-transform.forward * MovementSpeed * Time.deltaTime, ForceMode.Impulse);
        }
        if(Input.GetKey(KeyCode.D))
        {
            PlayerBody.AddForce(transform.right * MovementSpeed * Time.deltaTime, ForceMode.Impulse);
        }
        if(Input.GetKey(KeyCode.A))
        {
            PlayerBody.AddForce(-transform.right * MovementSpeed * Time.deltaTime, ForceMode.Impulse);
        }
        if(Input.GetKey(KeyCode.Space))
        {
            PlayerBody.AddForce(transform.up * MovementSpeed * Time.deltaTime, ForceMode.Impulse);
        }
        if(Input.GetKey(KeyCode.LeftControl))
        {
            PlayerBody.AddForce(-transform.up * MovementSpeed * Time.deltaTime, ForceMode.Impulse);
        }
    }

    //Debugs
    void Debugging()
	{
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
        //
    }
}
