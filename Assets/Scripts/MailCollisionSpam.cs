using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//scripts written using unity documentation on collisions https://docs.unity3d.com/ScriptReference/Collider.OnCollisionEnter.html
public class MailCollisionSpam : MonoBehaviour
{ 
    public GameObject hint;
    private Vector3 startPosition;
    GameController gc;

    void Start()
    {
        startPosition = transform.position;
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        gc.collectible++;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "SpamBin") { //if mail object is sorted correctly
            Debug.Log("collision detected");
            ContactPoint contact = collision.contacts[0];
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 position = contact.point;
            //reward.SetActive(true); //sets reward text active
            Destroy(gameObject);
            gc.collectible--; //removes one from the mail counter
            //play sound for correct answer
            FindObjectOfType<AudioManager>().Play("Correct");
        }
        else if (collision.gameObject.name == "SafeBin") // if mail object is sorted incorrectly
        {
            Debug.Log("collision detected");
            ContactPoint contact = collision.contacts[0];
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 position = contact.point;
            //tryAgain.SetActive(true); //sets try again text active
            transform.position = startPosition;//transform to starting location
            hint.SetActive(true);
            //play sound for incorrect answer
            FindObjectOfType<AudioManager>().Play("Incorrect");
        }

    }
}
