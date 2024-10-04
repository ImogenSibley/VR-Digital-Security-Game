using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Animator))]

public class FinalDoorOpen : MonoBehaviour
{
    Animator animator;
    public GameObject door; //allows to set the door object within door parent object
    public GameObject info1; //the information displayed when the objects have been picked up
    public GameObject info2;
    public GameObject info3;
    public GameObject info4;
    public GameObject reward;
    private float x, y, z;
    public int DoorRotationDegree;
    public AudioClip doorSound;
    public AudioClip victorySound;
    public AudioSource audioSource;
    private bool soundPlayed = false;

    // Start is called before the first frame update
    public void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
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
            animator.SetTrigger("finalOpenTrigger");
            //play sound for door opening
            if (!soundPlayed)
            {
                audioSource.PlayOneShot(doorSound); //play sound for door opening
                audioSource.PlayOneShot(victorySound);
                soundPlayed = true;
            }
        }
    }
    private void collectCheck()
    {
        //if objects have been collected 
        if ((info1.activeSelf == true) && (info2.activeSelf == true) && (info3.activeSelf == true) && (info4.activeSelf == true)) //checks the active self of the info text object
        {
            openDoor(); //open door
            //Debug.Log("Door has opened.");
            //display text to congratulate player for finding objects
            reward.SetActive(true);

        }
    }
}
