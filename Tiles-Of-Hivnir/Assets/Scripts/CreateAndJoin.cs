using System;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateAndJoin : MonoBehaviourPunCallbacks
{
   public InputField input_create;
   public InputField input_join;

   public void CreateRoom()
   {
      PhotonNetwork.CreateRoom(input_create.text, new RoomOptions(){MaxPlayers = 4, IsVisible = true, IsOpen = true});
   }

   public void JoinRoom()
   {
      PhotonNetwork.JoinRoom(input_join.text);
   }

   public override void OnJoinedRoom()
   {
      PhotonNetwork.LoadLevel("Multi");
   }
}