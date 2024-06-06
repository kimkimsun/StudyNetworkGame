using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class StartManager : MonoBehaviourPunCallbacks
{
    public static StartManager instance;

    public TextMeshProUGUI nickName;
    public void StartButton()
    {
        OnConnectedToMaster();
        SceneManager.LoadScene("Lobby");
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("������ ���ӿϷ�");
        Debug.Log($"PhotonNetwork.inLobby = {PhotonNetwork.InLobby}");
        PhotonNetwork.JoinLobby();
        PhotonManager.userId = nickName.text;
    }
}