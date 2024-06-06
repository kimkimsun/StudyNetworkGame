## 네트워크를 이용한 Unity 멀티게임 구현
## 개발 환경
![Windows](https://img.shields.io/badge/Windows-0078D6?style=for-the-badge&logo=windows&logoColor=white)
![Unity](https://img.shields.io/badge/unity-%23000000.svg?style=for-the-badge&logo=unity&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white)
![AWS](https://img.shields.io/badge/AWS-%23FF9900.svg?style=for-the-badge&logo=amazon-aws&logoColor=white)
## Photon Network
![0](https://github.com/kimkimsun/StudyNetworkGame/assets/116052108/137d11da-439b-4c8d-963b-6e292d9e5b71)
#### 포톤 네트워크는 크래스 플랫폼을 지원해주는 대표적인 네트워크 엔진 입니다.
## 사용 법
![1](https://github.com/kimkimsun/StudyNetworkGame/assets/116052108/7c83626c-e548-413a-8193-6fe81e994965)
#### 1번과 2번을 해주시고
![2](https://github.com/kimkimsun/StudyNetworkGame/assets/116052108/5e7c3e0e-7d49-4553-b2fb-bf7aabc70f32)
#### SDK 종류는 PUN으로 설정합니다. PUN은 Photon Unity Networking의 약자로 대놓고 Unity를 위한 네트워크 서비스 라는 것을 알 수 있습니다.
#### 이렇게 만들어주면 사이트에서의 설정은 끝납니다.
![3](https://github.com/kimkimsun/StudyNetworkGame/assets/116052108/85bee29f-e4c1-4d2d-8c67-af06b071d570)
#### 그리고 에셋스토어에 가셔서 photon중 공짜로 되어있는 photon을 다운로드 해줍니다.
![4](https://github.com/kimkimsun/StudyNetworkGame/assets/116052108/1ab19d22-b13c-4dbe-9cd6-4b7f03bdbfd9)
![5](https://github.com/kimkimsun/StudyNetworkGame/assets/116052108/7ab2b2b6-e9ec-40f2-9d96-68c1a1dc4c79)
#### Appid or Email란에는 사이트에 있는 파란색으로 물들인 저 주소를 복붙 하면 됩니다.
#### 그러면 포톤에 대한 준비는 마치게 되었고 스크립트를 작성해 봅시다.
![6](https://github.com/kimkimsun/StudyNetworkGame/assets/116052108/b82238fd-c611-4556-a030-f7c72bfef7cb)
#### 포톤을 사용하기 위해선 빨간색 네모 부분을 반드시 사용해야 합니다.
#### 나머지 코드들은 주석으로 설명을 해놨습니다.
#### 로그를 찍음으로써 해당 코드가 어떤식으로 작동하는지 판단하기 쉬울 것입니다.
#### 여기까지는 서버와 로비에 접속하는 코드였습니다. 그럼 룸에 입장하는 코드를 만들어 보겠습니다.
![7](https://github.com/kimkimsun/StudyNetworkGame/assets/116052108/b02ca6c5-cd84-436f-bdf6-0ee18f217922)
#### 주석 참고 바랍니다.
#### 이제 같은 방에 있는 유저들끼리의 데이터를 연동하고 동기화해주는 모듈을 만들어 볼 겁니다.
#### 네트워크 대역폭과 성능상의 이유로 Photon View는 1개만 사용을 권장합니다.
![8](https://github.com/kimkimsun/StudyNetworkGame/assets/116052108/8d5bfe6d-0f05-4111-801b-8b6cd143c583)
![9](https://github.com/kimkimsun/StudyNetworkGame/assets/116052108/eb6305c2-185b-4d36-8429-75c32fd831f7)
출처 : youtube 유니티쳐
#### 해당 사항들은 동기화를 어떻게 처리할지에 대한 여부를 결정해라 라는 것인데 저는 맨 밑에 것을 쓰겠습니다.
![10](https://github.com/kimkimsun/StudyNetworkGame/assets/116052108/f6e46023-663e-4776-8897-5162e9bb6dd8)
#### 해당 컴포넌트들도 추가해줍니다.
#### 저는 애니메이터를 사용하지 않을 것이지만 혹여나 사용하게 된다면 이것또한 사용해야 됩니다.
#### 함수들에 대해 대충이나마 알아봤습니다. 그럼 이제 로비, 방 생성, 플레이어끼리 만나게 해보겠습니다.

#### 준비물은 3개의 씬이 필요합니다. 시작,로비,방
#### 먼저 시작부터 보겠습니다.
![1](https://github.com/kimkimsun/StudyNetworkGame/assets/116052108/288ad8bc-5438-44c8-8d38-e79e7772e4c4)
#### 닉네임을 적을 수 있고 버튼을 누르면 Lobby로 이동합니다.
![2](https://github.com/kimkimsun/StudyNetworkGame/assets/116052108/29793b89-02ad-498c-9bdd-fd29fa3818b7)
#### 해당 스크립트는 매우 간단하니 이해하는데 어렵지 않을 것입니다.

![4](https://github.com/kimkimsun/StudyNetworkGame/assets/116052108/bf5381e3-3f7d-4f52-9b19-f27cfaa3971b)
#### 다음은 Lobby 스크립트입니다.
![3](https://github.com/kimkimsun/StudyNetworkGame/assets/116052108/96f72010-bcd3-4aa6-b97e-692324c3e9c3)
#### 위에 있던 사진들과 다른 부분에만 주석을 달겠습니다.
![5](https://github.com/kimkimsun/StudyNetworkGame/assets/116052108/7a03ad44-8618-4738-8101-8de4abebcf0c)
#### 현재는 방이 1개만 존재하고 2명이서 플레이한다는 전제로 만든 코드이지만 여러개를 사용할 경우 for문을 사용하면 쉽게 구현 가능합니다.

#### 다음은 메인 화면입니다.
![6](https://github.com/kimkimsun/StudyNetworkGame/assets/116052108/1ab04bda-1886-454f-84b3-bd13904539e0)
#### 우리가 알던 instantiate가 아닌 포톤 클래스를 사용해야 동기화가 가능합니다.
#### 처음에 있는 "Player"라는 문자열은 Editor안에 있는 Resources 파일 안에서 문자열로 찾습니다.
#### !주의 Player라는 오브젝트를 Prefab한 뒤 프로젝트에선 삭제하고 Resources폴더 안에 넣으며, 그 객체는 Photon View와 Photon transform 스크립트가 존재해야 합니다.

#### 이렇게 하면 모든 준비는 마쳤습니다. 기본만을 다뤘지만 
#### 포톤을 이용하여 원하는 멀티플레이 게임을 만드는데 있어 중요한 함수는 모두 사용하고 설명하였으니 쉽게 구현이 가능 할 것입니다.

### 끝까지 읽어주셔서 감사합니다.
