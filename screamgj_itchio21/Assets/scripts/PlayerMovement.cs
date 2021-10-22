using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement and Crouch
    CharacterController characterCollider;
    public CharacterController controller;
    public float speed = 12f;
    public AudioSource[] audio = new AudioSource[1];

    // Gravity
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public Transform groundCheck;
    public  LayerMask groundMask;
    public float cTime = 0.9f;
    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        characterCollider = gameObject.GetComponent<CharacterController> ();
    }

    void Update()
    {
        // Gravity
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Movement
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xMove + transform.forward * zMove;
        controller.Move(move * speed);

        // Crouch
        if(Input.GetKey(KeyCode.LeftControl)){
            characterCollider.height = 1.0f;
        }
        else{
            if(characterCollider.height < 1.75f) {
                characterCollider.height += cTime * Time.deltaTime;
            }
            else {
                characterCollider.height = 1.75f;
            }  
        }

        int soundNum = Random.Range(0,12);

        if(characterCollider.isGrounded == true && characterCollider.velocity.magnitude > 2f && audio[0].isPlaying == false && audio[1].isPlaying == false && audio[2].isPlaying == false && audio[3].isPlaying == false && audio[4].isPlaying == false && audio[5].isPlaying == false && audio[6].isPlaying == false && audio[7].isPlaying == false && audio[8].isPlaying == false && audio[9].isPlaying == false && audio[10].isPlaying == false && audio[11].isPlaying == false && audio[12].isPlaying == false) {
            audio[soundNum].Play();
        }
        
    }
}
