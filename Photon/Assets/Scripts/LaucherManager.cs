using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class LaucherManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField roomNameInput;
    [SerializeField] private TextMeshProUGUI roomNameText;
    [SerializeField] private Transform playerListContainer;
    [SerializeField] private GameObject playerItem;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Connecting to server");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Connected To Server");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("Joined Lobby");

        MenuManager.instance.OpenMenu("mainmenu");
    }

    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(roomNameInput.text)) //roomName.text != "" || roomName.text != null
        {
            return;
        }

        PhotonNetwork.CreateRoom(roomNameInput.text);
        MenuManager.instance.OpenMenu("loadingmenu");
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("RoomCreated");
        MenuManager.instance.OpenMenu("roommenu");
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;

        Player[] players = PhotonNetwork.PlayerList;

        for (int i = 0; i < players.Length; i++)
        {
            Instantiate(playerItem, playerListContainer).GetComponent<TextMeshProUGUI>().text = players[i].NickName;
        }
    }
}
