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
    // 버전 입력
    private readonly string version = "1.0f";
    // 사용자 아이디 입력
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
        PhotonNetwork.NickName = userId; // 시작에서 만들었던 닉네임을 적용한다.
    }
    private void Update()
    {
        if (stateText!=null)
            stateText.text = PhotonNetwork.NetworkClientState.ToString(); // 현재 로비에 잘 접속했는지 접속 중인지 여부를 판단하기 위한 로그이다.
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }
    public void RandomMatch()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    // 로비에 접속 후 호출되는 콜백 함수
    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 20;    // 해당 무료버전은 최대 플레이어를 20명만 받을 수 있음
        roomOptions.IsOpen = true;      // 룸의 오픈 여부
        roomOptions.IsVisible = true;    // 로비에서 룸 목록에 노출 시킬지 여부

        // 룸 생성
        PhotonNetwork.CreateRoom("new Room", roomOptions);
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        // 만약 방이 하나도 없었을 때에 대한 예외 처리 함수
        Debug.Log($"JoinRandom Failed {returnCode} {message}");
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 20;    // 해당 무료버전은 최대 플레이어를 20명만 받을 수 있음
        roomOptions.IsOpen = true;      // 룸의 오픈 여부
        roomOptions.IsVisible = true;    // 로비에서 룸 목록에 노출 시킬지 여부

        // 룸 생성
        PhotonNetwork.CreateRoom("new Room", roomOptions);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Main");
        // Photon Network를 이용하여 메인씬으로 이동하는 것입니다.
        Debug.Log($"Player Count = {PhotonNetwork.CurrentRoom.PlayerCount}");
    }
    void MyListRenewal()
    {
        // 방 이름 버튼을 지정해주는 것입니다.
        if(myList.Count > 0)
            roomText.text = myList[0].Name;
    }
    public void MyListClick()
    {
        // 버튼을 눌렀을 때 그 게임의 방으로 이동하는 것입니다. string으로 접근합니다.
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