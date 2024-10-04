using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Animator))]

public class BlueSafeOpen : MonoBehaviour
{
    Animator animator;
    public GameObject door; //door for the blue safe
    public Toggle toggle1;
    public Toggle toggle2;
    public Toggle toggle3;
    private int x, y, z; //transform coords
    public int DoorRotationDegree;
    public AudioClip doorSound;
    public AudioSource audioSource;
    private bool soundPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        ToggleSelected(); 
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
            animator.SetTrigger("openTrigger"); //open animation
        }
    }
        // Update is called once per frame
        void ToggleSelected()
    {
        //if toggle group 1 green selected && group 2 pink selected && group 3 yellow selected
        if ((toggle1.isOn) && (toggle2.isOn) && (toggle3.isOn))
        {
            //Debug.Log("Safe should open.");
            openDoor();

        }
        else
        {
            //Debug.Log("Safe should stay shut."); ;
        }
    }
}
