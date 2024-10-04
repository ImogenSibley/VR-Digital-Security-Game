using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Animator))]

public class DoorOpen : MonoBehaviour
{
    Animator animator;
    public GameObject door; //allows to set the door object within door parent object
    public GameObject info; //the information displayed when the objects have been picked up
    public GameObject reward; 
    private float x,y,z;
    public int DoorRotationDegree;
    public AudioClip doorSound;
    public AudioSource audioSource;
    private bool soundPlayed = false;

    public void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        collectCheck();    
    }

    // Update is called once per frame
    private void openDoor()
    {
        if (z != DoorRotationDegree)
        { //if door is not already open
          //door opens by rotating 90 degrees in Z axis
          //z = DoorRotationDegree;
          //door.transform.Rotate(x, y, z);
          //door opening animation
            animator.SetTrigger("openTrigger");
            if (!soundPlayed)
            {
                audioSource.PlayOneShot(doorSound); //play sound for door opening
                soundPlayed = true;
            }
        }
    }
    private void collectCheck()
    {
        //if objects have been collected 
        if (info.activeSelf == true) //checks the active self of the info text object
        {
            openDoor(); //open door
            //Debug.Log("Door has opened.")
            //display text to congratulate player for finding objects
            reward.SetActive(true);
           
        }
    }
}
