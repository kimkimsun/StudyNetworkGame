using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class PhotonManager : MonoBehaviourPunCallbacks
{
    // ���� �Է�
    private readonly string version = "1.0f";
    // ����� ���̵� �Է�
    private string userId = "StudyPT";

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene= true;
        PhotonNetwork.GameVersion = version;
        PhotonNetwork.NickName = userId;
        Debug.Log(PhotonNetwork.SendRate);
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("������ ���ӿϷ�");
        Debug.Log($"PhotonNetwork.inLobby = { PhotonNetwork.InLobby}");
        PhotonNetwork.JoinLobby();
    }

    // �κ� ���� �� ȣ��Ǵ� �ݹ� �Լ�
    public override void OnJoinedLobby()
    {
        Debug.Log($"PhotonNetwork.inLobby = {PhotonNetwork.InLobby}");
        PhotonNetwork.JoinRandomRoom(); // ���� ��Ī
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        // ���� ���� �ϳ��� ������ ���� ���� ���� ó�� �Լ�
        Debug.Log($"JoinRandom Failed {returnCode} {message}");
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 20;    // �ش� ��������� �ִ� �÷��̾ 20�� ���� �� ����
        roomOptions.IsOpen = true;      // ���� ���� ����
        roomOptions.IsVisible= true;    // �κ񿡼� �� ��Ͽ� ���� ��ų�� ����

        // �� ����
        PhotonNetwork.CreateRoom("new Room", roomOptions);
    }

    // �� ������ �Ϸ�� �� ȣ��Ǵ� �ݹ� �Լ�
    public override void OnCreatedRoom()
    {
        Debug.Log("Created Room");
        Debug.Log($"Room Name = {PhotonNetwork.CurrentRoom.Name}");
    }
    // �뿡 ������ �� ȣ��Ǵ� �ݹ� �Լ�

    public override void OnJoinedRoom()
    {
        // ������ �� �ƴ��� Ȯ���ϴ� �α�
        Debug.Log($"PhotonNetword.InRoom = {PhotonNetwork.InRoom}");
        // �÷��̾� �� Ȯ��
        Debug.Log($"Player Count = {PhotonNetwork.CurrentRoom.PlayerCount}");

        foreach(var player in PhotonNetwork.CurrentRoom.Players)
        {
            Debug.Log($"{player.Value.NickName}{player.Value.ActorNumber}");
        }
        // �÷��̾���� ������ �������� foreach��
    }
}