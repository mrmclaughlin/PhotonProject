using UnityEngine;
using Photon.Pun;

public class SphereSpawner : MonoBehaviourPun
{
    public string spherePrefabName = "SpherePrefab"; // Replace with your sphere prefab's name
    public Vector3 spawnPosition = new Vector3(0, 1, 0); // The position where the sphere will be spawned

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine && Input.GetKeyDown(KeyCode.Space)) // Press Space to spawn a sphere
        {
            SpawnSphere(new Vector3(0,1,0));
			SpawnSphere(new Vector3(0,2,0));
			SpawnSphere(new Vector3(0,3,0));
        }
    }

    void SpawnSphere(Vector3 positionValue)
    {
        PhotonNetwork.Instantiate(spherePrefabName, spawnPosition, Quaternion.identity);
    }
}
