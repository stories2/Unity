20160724-3
프로젝트소스를 시각화한 그림파일을 첨부하였다

20160724-2
친구 목록에서 친구의 아이디가 짤려서 나오는 버그 픽스
페이스북에 공유할 때 내가 얻은 점수를 보여주는 방향으로 변경

20160724-1
생각해보니 멍청하게도 점수 개념을 빼먹고 있었다
Definder 클래스에 resultScore 을 추가하여 점수를 DB와 연동할 수 있게끔 추가하였다

20160724
페이스북 공유 부분을 조금 고쳤다
게임의 아이콘을 추가하였으며 문이 그려져 있던 그래픽에서 꽃으로 바꾸었다
버튼이 사라지는 버그와 몇 M 남았는지 알려주는 라벨이 사라져있던 버그를 픽스했다
각각의 이유는 이벤트 초기화와 우선순위 문제였다
구글플레이스토어에도 앱을 업로드 하였다
https://play.google.com/store/apps/details?id=com.stories2.congcong

20160723-1
고쳤다. MainManager 에서 r_flag 를 이용한 Update메소드에서 한번의 초기화 과정을 거칠때
웹과 커뮤니케이션 하던 부분이 화면을 뿌려주지 못하게 하는 원인이였다
그 부분을 화면 뿌려준 후에 작업 하도록 우선순위를 뒤로 하였다
또한 버튼을 터치해도 반응이 없던 문제가 있었는데 이는 클릭이 되었는지 체크도 하기 전에 다시
값을 변경시켜버리는 바람에 스킵되어버리는 경우였다
이를 ViewManager 에서 값을 그대로 유지하도록 변경하였다

20160723
샹 갑자기 view를 그려주는 정보가 담긴 데이터 노드가 하나도 잡히지 않아 화면에 뿌려지는게 없다
시발시발

20160721
FacebookMenu 에서 본 앱의 공유와 홍보를 진행할 수 있는 기능이 마련되었다
실제 테스트도 하였으며 잘 작동함
RankMenu 에서 웹 서버와 연동하여 DB에 저장되어 있는 임의의 데이터들에 대해서
모든 유저중에 TOP 10 을 보여주는 기능과 내 친구들 중에 TOP 10 을 보여주는 기능이 구현되어 있다

20160720
FacebookMenu 에서 페이스북과 통신을 하면서 로그인처리 까지 구현이 되어있다 
이를 구현하는 과정에서 익숙치 않는 SNS 연동 과정으로 인해 새로운 프로젝트인 unity38을 만들어 테스트 하였다
pc화면은 개발자전용 ui 가 출력되지만 모바일기기에서 작동 시키면 로그인 ui 가 출력되며 정상적으로 저장까지도 된다


20160718
본격적으로 CommunicationManager를 이용한 웹 통신이 가능해졌다
StartMenu 에 자신의 정보와 필요한 데이터 업데이트를 하는 메소드가 정상작동하는것 까지 확인하였다

MariaDB [congcong]> alter table user add unique index (MacAddress);
Query OK, 0 rows affected (0.18 sec)
Records: 0  Duplicates: 0  Warnings: 0

MariaDB [congcong]> desc user;
+--------------+-------------+------+-----+---------------------+----------------+
| Field        | Type        | Null | Key | Default             | Extra          |
+--------------+-------------+------+-----+---------------------+----------------+
| MacAddress   | varchar(12) | YES  | UNI | NULL                |                |
| PlayerId     | int(11)     | NO   | PRI | NULL                | auto_increment |
| InstallTime  | timestamp   | NO   |     | CURRENT_TIMESTAMP   |                |
| ConnectTime  | timestamp   | NO   |     | 0000-00-00 00:00:00 |                |
| EOGTime      | timestamp   | NO   |     | 0000-00-00 00:00:00 |                |
| LastPlayTime | timestamp   | NO   |     | 0000-00-00 00:00:00 |                |
| FaceBookId   | text        | YES  |     | NULL                |                |
+--------------+-------------+------+-----+---------------------+----------------+
7 rows in set (0.00 sec)
를 통해 user 의 MacAddress 는 중복되는 값이 저장되지 않는다
http://lamb.kangnam.ac.kr/congcong/index.php 는 DB와 클라이언트 사이에서 관제 하는 역활을 한다
매개변수들 중 0번째는 무조건 사용할 함수 명이 나오며 그 이후에는 그 함수가 작동하는데 필요로 하는 파라미터
가 들어오게 된다


20160715
NetNode 에는 웹 url 링크 주소와 그 링크를 실행했을때의 결과값이 담기는 노드이다
CommunicateManager 에는 네트워크 연동하는데 쓰이는 컨트롤 메소드가 탑재되어 있다
RankMenu 에는 TOP 10 명의 랭크가 보여주는 기능을 갖고 있다
ScoreMenu 에는 GameMenu가 끝났을때의 화면이 출력된다
GameMenu 에는 캐릭터가 움직이는 중력을 계산하는 2차함수가 업데이트 되었다
서버는 lamb.kangnam.ac.kr 을 사용하며 DB 셋팅을 임시적으로 완료하였다
login as: root
root@lamb.kangnam.ac.kr's password:
Last failed login: Fri Jul 15 20:28:29 KST 2016 from 112.175.103.29 on ssh:notty
There were 15049 failed login attempts since the last successful login.
Last login: Tue Jul 12 15:44:10 2016 from 61.43.139.4
[root@localhost ~]# mysql -u root -p
Enter password:

Welcome to the MariaDB monitor.  Commands end with ; or \g.

Your MariaDB connection id is 37807
Server version: 5.5.39-MariaDB MariaDB Server

Copyright (c) 2000, 2014, Oracle, Monty Program Ab and others.

Type 'help;' or '\h' for help. Type '\c' to clear the current input statement.

MariaDB [(none)]>
MariaDB [(none)]>
MariaDB [(none)]>
MariaDB [(none)]> show databases;
+--------------------+
| Database           |
+--------------------+
| information_schema |
| mysql              |
| performance_schema |
| project_backup     |
| shcho              |
| tetris             |
| wiki_category      |
| wiki_latest_page   |
+--------------------+
8 rows in set (0.17 sec)

MariaDB [(none)]> create databases congcong default charset = utf8;
ERROR 1064 (42000): You have an error in your SQL syntax; check the manual that corresponds to your MariaDB server version for the right syntax to use near 'databases congcong default charset = utf8' at line 1
MariaDB [(none)]> create database congcong default charset = utf8;
Query OK, 1 row affected (0.02 sec)

MariaDB [(none)]> show databases;
+--------------------+
| Database           |
+--------------------+
| information_schema |
| congcong           |
| mysql              |
| performance_schema |
| project_backup     |
| shcho              |
| tetris             |
| wiki_category      |
| wiki_latest_page   |
+--------------------+
9 rows in set (0.00 sec)

MariaDB [(none)]> use congcong;
Database changed
MariaDB [congcong]> create table user (MacAddress text, PlayerId int not null primary_key auto increment, InstallTime timestamp default now(), ConnectTime timestamp, EOGTime timestamp, LastPlayTime timestamp, FaceBookId text);
ERROR 1064 (42000): You have an error in your SQL syntax; check the manual that corresponds to your MariaDB server version for the right syntax to use near 'auto increment, InstallTime timestamp default now(), ConnectTime timestamp, EOGT' at line 1
MariaDB [congcong]> create table user (MacAddress text, PlayerId int not null primary key auto_increment, InstallTime timestamp default now(), ConnectTime timestamp, EOGTime timestamp, LastPlayTime timestamp, FaceBookId text);
Query OK, 0 rows affected (0.34 sec)

MariaDB [congcong]> desc rank;
ERROR 1146 (42S02): Table 'congcong.rank' doesn't exist
MariaDB [congcong]> desc user;
+--------------+-----------+------+-----+---------------------+----------------+
| Field        | Type      | Null | Key | Default             | Extra          |
+--------------+-----------+------+-----+---------------------+----------------+
| MacAddress   | text      | YES  |     | NULL                |                |
| PlayerId     | int(11)   | NO   | PRI | NULL                | auto_increment |
| InstallTime  | timestamp | NO   |     | CURRENT_TIMESTAMP   |                |
| ConnectTime  | timestamp | NO   |     | 0000-00-00 00:00:00 |                |
| EOGTime      | timestamp | NO   |     | 0000-00-00 00:00:00 |                |
| LastPlayTime | timestamp | NO   |     | 0000-00-00 00:00:00 |                |
| FaceBookId   | text      | YES  |     | NULL                |                |
+--------------+-----------+------+-----+---------------------+----------------+
7 rows in set (0.04 sec)

MariaDB [congcong]> create table rank (PlayerId int , Score int default 0, UpdateScoreTime timestamp default now());
Query OK, 0 rows affected (0.08 sec)

MariaDB [congcong]> desc rank;
+-----------------+-----------+------+-----+-------------------+-------+
| Field           | Type      | Null | Key | Default           | Extra |
+-----------------+-----------+------+-----+-------------------+-------+
| PlayerId        | int(11)   | YES  |     | NULL              |       |
| Score           | int(11)   | YES  |     | 0                 |       |
| UpdateScoreTime | timestamp | NO   |     | CURRENT_TIMESTAMP |       |
+-----------------+-----------+------+-----+-------------------+-------+
3 rows in set (0.00 sec)

MariaDB [congcong]> alter table rank modify PlayerId int not null primary key;
Query OK, 0 rows affected (0.28 sec)
Records: 0  Duplicates: 0  Warnings: 0

MariaDB [congcong]> desc rank;
+-----------------+-----------+------+-----+-------------------+-------+
| Field           | Type      | Null | Key | Default           | Extra |
+-----------------+-----------+------+-----+-------------------+-------+
| PlayerId        | int(11)   | NO   | PRI | NULL              |       |
| Score           | int(11)   | YES  |     | 0                 |       |
| UpdateScoreTime | timestamp | NO   |     | CURRENT_TIMESTAMP |       |
+-----------------+-----------+------+-----+-------------------+-------+
3 rows in set (0.00 sec)

MariaDB [congcong]> create table friend (PlayerId int not null primary key, FriendId int not null, UpdateTime timestamp default now(), Broke bool default false);
Query OK, 0 rows affected (0.09 sec)

MariaDB [congcong]> desc friend;
+------------+------------+------+-----+-------------------+-------+
| Field      | Type       | Null | Key | Default           | Extra |
+------------+------------+------+-----+-------------------+-------+
| PlayerId   | int(11)    | NO   | PRI | NULL              |       |
| FriendId   | int(11)    | NO   |     | NULL              |       |
| UpdateTime | timestamp  | NO   |     | CURRENT_TIMESTAMP |       |
| Broke      | tinyint(1) | YES  |     | 0                 |       |
+------------+------------+------+-----+-------------------+-------+
4 rows in set (0.01 sec)

MariaDB [congcong]>

또한 DB 연동을 위한 php 위치를 지정하였다
login as: root
root@lamb.kangnam.ac.kr's password:
Access denied
root@lamb.kangnam.ac.kr's password:
Last failed login: Fri Jul 15 21:32:14 KST 2016 from 118.130.99.186 on ssh:notty
There was 1 failed login attempt since the last successful login.
Last login: Fri Jul 15 21:06:52 2016 from 118.130.99.186
[root@localhost ~]#
[root@localhost ~]#
[root@localhost ~]#
[root@localhost ~]# ls -l
합계 4
-rw-------. 1 root root 1076  3월 16 06:11 anaconda-ks.cfg
[root@localhost ~]# cd /home/stories2/html/
[root@localhost html]# ls -l
합계 1956
-rw-r--r--  1 stories2 stories2 1989455  6월 18 12:24 Desktop.unity3d
-rw-r--r--  1 stories2 stories2    3305  6월 18 12:24 index.html
-rw-r--r--. 1 root     root          21  4월  9 09:38 info.php
lrwxrwxrwx. 1 root     root          22  4월  9 09:41 mysql -> /usr/share/phpMyAdmin/
drwxr-xr-x  6 stories2 stories2    4096  4월 26 01:06 project_backup
[root@localhost html]# mkdir congcong
[root@localhost html]# cd congcong/
[root@localhost congcong]# vim index.php
[root@localhost congcong]#


20160714
ItemNode에는 int 형 데이터가 담겨 그래픽 프로세싱 번호를 저장한다
Defined 에 draw jump max 변수는 2차함수를 이용한 frame per speed 의 최대값을 지정한다
GameMenu 에는 실질적인 게임이 진행된다
StartMenu 에는 처음 초기화면에 대한 처리를 담당한다
ConvertManager에는 캐릭터의 frame per speed 를 구하는 2차함수 가 정의되었으며, 그래픽 파일의 중심을 찾아주고
해상도에 따른 늘려주는 크기를 계산한다
MainManager 에는 메뉴 전환에 도움을 주는 함수가 정의되어있다

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