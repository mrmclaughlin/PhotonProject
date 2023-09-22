using Photon.Pun;
using UnityEngine;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master.");
        PhotonNetwork.JoinOrCreateRoom("Room", new Photon.Realtime.RoomOptions { MaxPlayers = 4 }, null);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room.");
        PhotonNetwork.Instantiate("PlayerPrefab", Vector3.zero, Quaternion.identity);
		PhotonNe