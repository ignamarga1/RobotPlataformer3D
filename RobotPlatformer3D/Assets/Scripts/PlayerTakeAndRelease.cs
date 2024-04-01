using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeAndRelease : MonoBehaviour
{
    
    private bool takeObject = true; 
    private bool releaseObject = false;    

    private GameObject objectiveObject; // GameObject that the player wants to take
    public GameObject gripPosition;     // Empty gameObject with the position where the objective will be taken

    public float releaseDistance;  
    public float releaseHeight;

    private CharacterController characterController;   

    // Start is called before the first frame update
    void Start()
    {
        releaseDistance = 7f;
        releaseHeight = 5f;
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Uses 'Q' key to release the object
        if (Input.GetKeyDown(KeyCode.Q) && objectiveObject != null)
        {
            releaseObject = true;
        }

        if (releaseObject)
        {
            objectiveObject.transform.SetParent(null); 

            // Checks if the object doesn't have a RigidBody
            if (objectiveObject.GetComponent<Rigidbody>() != null)
            {
                objectiveObject.GetComponent<Rigidbody>().isKinematic = false;  // Object gets physics behaviour
            }
            
            // Desactivates the KeyMovement script (avoids the object go back to original position when released)
            objectiveObject.GetComponent<KeyMovement>().enabled = false; 


            Vector3 releasePosition = transform.position + transform.forward * releaseDistance; // Position where the object will be released
            releasePosition += Vector3.up * releaseHeight;          // releasePosition height adjustment
            objectiveObject.transform.position = releasePosition;   // Object position to releasePosition

            objectiveObject = null; 
            takeObject = true; 
            releaseObject = false; 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Player can take the object and collides with the object with the Key tag
        if (takeObject && (other.gameObject.tag == "Key"))
        {
            other.gameObject.transform.SetParent(gripPosition.transform);  // Makes object child of the gripPosition of the Player
            other.gameObject.transform.localPosition = Vector3.zero;

            // Checks if the object doesn't have a RigidBody
            if (other.gameObject.GetComponent<Rigidbody>() != null)
            {
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true; // Kinematic behaviour when it has rigidBody
            }

            other.gameObject.GetComponent<KeyMovement>().enabled = false;   // Desactivates the KeyMovement script 
            objectiveObject = other.gameObject;     // Gets the object
            takeObject = false;                     
        }
    }
}
