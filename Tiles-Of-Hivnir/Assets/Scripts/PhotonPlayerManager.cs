using UnityEngine;
using Photon.Pun;
using System.Collections.Generic;

public class PhotonPlayerManager : MonoBehaviourPunCallbacks
{
     public GameObject playerPrefab;

    public void Start()
    {
        Vector2 spawnPosition = new Vector2(0.5f,0.9f);
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition, Quaternion.identity);
        
    }
}