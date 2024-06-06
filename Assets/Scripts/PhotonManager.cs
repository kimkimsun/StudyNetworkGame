using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
public class PhotonManager : MonoBehaviourPunCallbacks
{
    public PhotonView pv;
    List<RoomInfo> myList = new List<RoomInfo>();
    public static PhotonManager Instance;
    public TextMeshProUGUI roomText;
    public TextMeshProUGUI stateText;
    // ���� �Է�
    private readonly string version = "1.0f";
    // ����� ���̵� �Է�
    public static string userId;
    void Awake()
    {
        if(Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        PhotonNetwork.AutomaticallySyncScene= true;
        PhotonNetwork.GameVersion = version;
        PhotonNetwork.ConnectUsingSettings();
        pv = GetComponent<PhotonView>();
    }
    private void Start()
    {
        PhotonNetwork.NickName = userId; // ���ۿ��� ������� �г����� �����Ѵ�.
    }
    private void Update()
    {
        if (stateText!=null)
            stateText.text = PhotonNetwork.NetworkClientState.ToString(); // ���� �κ� �� �����ߴ��� ���� ������ ���θ� �Ǵ��ϱ� ���� �α��̴�.
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }
    public void RandomMatch()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    // �κ� ���� �� ȣ��Ǵ� �ݹ� �Լ�
    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 20;    // �ش� ��������� �ִ� �÷��̾ 20�� ���� �� ����
        roomOptions.IsOpen = true;      // ���� ���� ����
        roomOptions.IsVisible = true;    // �κ񿡼� �� ��Ͽ� ���� ��ų�� ����

        // �� ����
        PhotonNetwork.CreateRoom("new Room", roomOptions);
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        // ���� ���� �ϳ��� ������ ���� ���� ���� ó�� �Լ�
        Debug.Log($"JoinRandom Failed {returnCode} {message}");
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 20;    // �ش� ��������� �ִ� �÷��̾ 20�� ���� �� ����
        roomOptions.IsOpen = true;      // ���� ���� ����
        roomOptions.IsVisible = true;    // �κ񿡼� �� ��Ͽ� ���� ��ų�� ����

        // �� ����
        PhotonNetwork.CreateRoom("new Room", roomOptions);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Main");
        // Photon Network�� �̿��Ͽ� ���ξ����� �̵��ϴ� ���Դϴ�.
        Debug.Log($"Player Count = {PhotonNetwork.CurrentRoom.PlayerCount}");
    }
    void MyListRenewal()
    {
        // �� �̸� ��ư�� �������ִ� ���Դϴ�.
        if(myList.Count > 0)
            roomText.text = myList[0].Name;
    }
    public void MyListClick()
    {
        // ��ư�� ������ �� �� ������ ������ �̵��ϴ� ���Դϴ�. string���� �����մϴ�.
        PhotonNetwork.JoinRoom(myList[0].Name);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        int roomCount = roomList.Count;
        for (int i = 0; i < roomCount; i++)
        {
            if (!roomList[i].RemovedFromList)
            {
                if (!myList.Contains(roomList[i])) 
                    myList.Add(roomList[i]);
                else 
                    myList[myList.IndexOf(roomList[i])] = roomList[i];
            }
            else if (myList.IndexOf(roomList[i]) != -1) 
                myList.RemoveAt(myList.IndexOf(roomList[i]));
        }
        MyListRenewal();
    }
}