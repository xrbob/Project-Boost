using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 175f;

    Rigidbody rigidBody;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start() {

        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

    }


    // Update is called once per frame
    void Update() {
        Thrust();
        Rotate();
    }


    private void Thrust() {

        float thrustThisFrame = mainThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space)) {
            rigidBody.AddRelativeForce(Vector3.up * thrustThisFrame);
            if (!audioSource.isPlaying) {
                audioSource.Play();
            }
        } else {
            audioSource.Stop();

        }
    }


    private void Rotate() {
        
        float rotationThisFrame = rcsThrust * Time.deltaTime;

        //rigidBody.freezeRotation = true;

        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) {
            //transform.Rotate(Vector3.forward * rotationThisFrame);
            rigidBody.AddRelativeTorque(Vector3.forward * rotationThisFrame);
        }

        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)) {
            //transform.Rotate(-Vector3.forward * rotationThisFrame);
            rigidBody.AddRelativeTorque(-Vector3.forward * rotationThisFrame);
        }

        //rigidBody.freezeRotation = false;
    }

    void OnCollisionEnter(Collision collision) {
        
        switch(collision.gameObject.tag) {

            case "Friendly":
                print("HAPPY"); // TODO :: Change this one to pickups and fuel
                break;
            
            default:
                print("DEATH"); 
                break;
        }
    }

}
