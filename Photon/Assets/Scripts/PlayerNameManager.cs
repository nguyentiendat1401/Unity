using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerNameManager : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField playerNameInput;

    private void Start()
    {
        if (PlayerPrefs.HasKey("userName"))
        {
            playerNameInput.text = PlayerPrefs.GetString("userName");
            PhotonNetwork.NickName = PlayerPrefs.GetString("userName");
        }
        else
        {
            playerNameInput.text = "Player-" + Random.Range(0, 1000);
            OnUsernameInputChanged();
        }
    }
    public void OnUsernameInputChanged()
    {
        PhotonNetwork.NickName = playerNameInput.text;
        PlayerPrefs.SetString("userName", playerNameInput.text);
    }
}
