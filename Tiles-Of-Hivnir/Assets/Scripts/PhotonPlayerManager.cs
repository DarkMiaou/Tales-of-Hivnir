using UnityEngine;
using Photon.Pun;
using System.Collections.Generic;

public class PhotonPlayerManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject playerPrefab;
    private List<GameObject> players = new List<GameObject>();

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(0.5f,0.5f,0), Quaternion.identity);
        }
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            GameObject newPlayerObject = PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
            players.Add(newPlayerObject);
            newPlayerObject.GetComponent<PhotonView>().TransferOwnership(newPlayer);
        }
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            foreach (GameObject playerObject in players)
            {
                if (playerObject.GetComponent<PhotonView>().Owner == otherPlayer)
                {
                    players.Remove(playerObject);
                    PhotonNetwork.Destroy(playerObject);
                    break;
                }
            }
        }
    }
}