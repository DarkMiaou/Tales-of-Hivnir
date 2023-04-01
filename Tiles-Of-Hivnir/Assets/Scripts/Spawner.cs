using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate("Player",new Vector3(0.5f,0.5f,0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
