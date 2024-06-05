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
