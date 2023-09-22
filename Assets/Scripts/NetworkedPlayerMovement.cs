using UnityEngine;
using Photon.Pun;

public class NetworkedPlayerMovement : MonoBehaviourPun
{
    public float moveSpeed = 5.0f;

    void Update()
    {
        // Only allow movement for the local player
        if (photonView.IsMine)
        {
            // Get input from the keyboard
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            // Create a vector to determine the direction to move in
            Vector3 moveDirection = new Vector3(horizontal, 0.0f, vertical);

            // Normalize the direction vector to ensure consistent speed regardless of direction
            if (moveDirection != Vector3.zero)
            {
                moveDirection.Normalize();
            }

            // Move the player
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}
 