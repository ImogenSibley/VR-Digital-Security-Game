using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Animator))]

public class PinkSafeOpen : MonoBehaviour
{
    Animator animator;
    private int x, y, z; //transform coords
    public int DoorRotationDegree;
    public GameObject door; //door for the safe
    GameController gc;
    public AudioClip doorSound;
    public AudioSource audioSource;
    private bool soundPlayed = false;

    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (gc.collectible == 0) //if all mail objects have been sorted
        {
            //open pink safe
            openDoor();
        }
    }
    void openDoor()
    {
        if (z != DoorRotationDegree) //if door is not already open
        {
            //door opens by rotating 90 degrees in Z axis
            //z = DoorRotationDegree;
            //door.transform.Rotate(x, y, z);
            if (!soundPlayed)
            {
                audioSource.PlayOneShot(doorSound); //play sound for door opening
                soundPlayed = true;
            }
            animator.SetTrigger("openTrigger");
        }
    }
}
