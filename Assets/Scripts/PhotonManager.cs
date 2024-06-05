using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class PhotonManager : MonoBehaviourPunCallbacks
{
    // 버전 입력
    private readonly string version = "1.0f";
    // 사용자 아이디 입력
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
        Debug.Log("서버에 접속완료");
        Debug.Log($"PhotonNetwork.inLobby = { PhotonNetwork.InLobby}");
        PhotonNetwork.JoinLobby();
    }

    // 로비에 접속 후 호출되는 콜백 함수
    public override void OnJoinedLobby()
    {
        Debug.Log($"PhotonNetwork.inLobby = {PhotonNetwork.InLobby}");
        PhotonNetwork.JoinRandomRoom(); // 랜덤 매칭
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        // 만약 방이 하나도 없었을 때에 대한 예외 처리 함수
        Debug.Log($"JoinRandom Failed {returnCode} {message}");
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 20;    // 해당 무료버전은 최대 플레이어를 20명만 받을 수 있음
        roomOptions.IsOpen = true;      // 룸의 오픈 여부
        roomOptions.IsVisible= true;    // 로비에서 룸 목록에 노출 시킬지 여부

        // 룸 생성
        PhotonNetwork.CreateRoom("new Room", roomOptions);
    }

    // 룸 생성이 완료된 후 호출되는 콜백 함수
    public override void OnCreatedRoom()
    {
        Debug.Log("Created Room");
        Debug.Log($"Room Name = {PhotonNetwork.CurrentRoom.Name}");
    }
    // 룸에 입장한 후 호출되는 콜백 함수

    public override void OnJoinedRoom()
    {
        // 입장이 잘 됐는지 확인하는 로그
        Debug.Log($"PhotonNetword.InRoom = {PhotonNetwork.InRoom}");
        // 플레이어 수 확인
        Debug.Log($"Player Count = {PhotonNetwork.CurrentRoom.PlayerCount}");

        foreach(var player in PhotonNetwork.CurrentRoom.Players)
        {
            Debug.Log($"{player.Value.NickName}{player.Value.ActorNumber}");
        }
        // 플레이어들의 정보를 가져오는 foreach문
    }
}