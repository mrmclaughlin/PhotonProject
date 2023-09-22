using UnityEngine;
using Photon.Pun;

public class PickUp : MonoBehaviourPun
{
     public float pickUpRange = 3.0f; // Range within which the sphere can be picked up
    public float throwForce = 10.0f; // Force with which the sphere will be thrown

    private GameObject pickedUpObject = null; // Reference to the picked-up object

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
             PickUpSphere();
			  
        }
        else if (Input.GetMouseButtonUp(0))
        {
            
            ThrowSphere();
        }
    }
	
	
	private void PickUpSphere()
    {
        // Create a Raycast to check for objects in front of the player
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, pickUpRange))
        {
            // Check if the hit object has a Rigidbody (i.e., it's a sphere we can pick up)
            Rigidbody rb = hit.collider.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Set the sphere's position and make it a child of the player
                rb.transform.position = transform.position + transform.forward * 2;
                rb.transform.SetParent(transform);
                
                // Disable physics while we're holding it
                rb.isKinematic = true;

                // Store the picked-up object
                pickedUpObject = rb.gameObject;
            }
        }
    }
	
	
	private void ThrowSphere()
    {
        if (pickedUpObject != null)
        {
            // Detach the object and re-enable physics
            pickedUpObject.transform.SetParent(null);
            Rigidbody rb = pickedUpObject.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            
            // Add force to throw the sphere
            rb.AddForce(transform.forward * throwForce, ForceMode.Impulse);

            // Clear the reference to the picked-up object
            pickedUpObject = null;
        }
    }
	
	
	
	
	
	
}