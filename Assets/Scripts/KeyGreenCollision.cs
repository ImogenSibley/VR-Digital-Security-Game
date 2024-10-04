using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGreenCollision : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "safe_door_green")
        { //if key object collides with green safe
            Debug.Log("collision detected");
            ContactPoint contact = collision.contacts[0];
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 position = contact.point;
            Destroy(gameObject); //key disappears when used
        }
    }
}
