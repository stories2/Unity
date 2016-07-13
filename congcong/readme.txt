20160713 - 1
DrawNode 에는 화면에 그려질 데이터가 저장된 노드이다
DrawManager 에는 DrawNode 를 관리하는 루트 클레스이다, 새치기 큐가 구현되어 있다
ViewManager 에는 DrawManager를 연동하여 DrawNode에 저장된 데이터를 실행하여 화면에 뿌려주는 역활을 한다
MainManager 에는 ViewManager에 그릴 데이터 2개를 임의로 저장하여 우선순위 드로잉과 노멀 드로잉을 테스트한다

20160713
congcong이라는 android 게임을 개발
Resources 폴더에는 101.png 부터 236.png 까지 그래픽 자료가 들어가 있다
Scence 폴더에는 main 씬이 들어가 있다
Source 폴더에는 구현에 쓰인 소스가 들어가 있다

MainManager 에서는 게임의 모든 API와 그 매커니즘이 전부 들어가게 된다
BufferManager 에서는 객체 링크드리스트를 구현하는데 쓰이는 노드가 정의된다
DefineManager 에서는 static 으로 선언된 변수들을 관리한다
IoManager 에서는 입출력을 담당한다
NetworkManager 에서는 네트워크 통신을 담당한다
ProcessManager 에서는 수학적 처리와 좌표 계산을 주로 한다
ViewManager 에서는 UI를 담당하며 사용자에게 직접 보여지게 되는 부분이다

BufferManager 에서 GraphicNode 가 정의되어있으며 이는 노드 하나당 Texture2D 데이터가 담기게 된다
FileManager 에서는 그래픽 파일을 로드하고 이를 버퍼형식으로 제공하는 역활을 한다
ResourceManager 에서는 그래픽파일을 링킹하고 추가, 삭제 기능을 담고 있다
ViewManager 에서는 화면을 출력하기위해 OnGUI메소드가 정의되어 있다