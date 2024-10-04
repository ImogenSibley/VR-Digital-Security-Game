using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]

public class GreenSafeOpen : MonoBehaviour
{
    Animator animator;
    public GameObject door;//door to safe
    public GameObject keyLock; //lock on safe
    public GameObject key; //green key
    private float x, y, z;
    public int DoorRotationDegree;
    public AudioClip doorSound;
    public AudioSource audioSource;
    private bool soundPlayed = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void openDoor()
    {
        keyLock.SetActive(false); //remove lock
        if (z != DoorRotationDegree)
        { //if door is not already open
          //door opens by rotating 90 degrees in Z axis
          //z = DoorRotationDegree;
          //door.transform.Rotate(x, y, z);
            if (!soundPlayed) //if sound not already played
            {
                audioSource.PlayOneShot(doorSound); //play sound for door opening
                soundPlayed = true;
            }
            animator.SetTrigger("openTrigger");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "sm_key_01")
        { //if key object collides with green safe
            Debug.Log("collision detected");
            ContactPoint contact = collision.contacts[0];
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 position = contact.point;
            //open door
            openDoor();
        }
    }
}

