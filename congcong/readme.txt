20160724-3
������Ʈ�ҽ��� �ð�ȭ�� �׸������� ÷���Ͽ���

20160724-2
ģ�� ��Ͽ��� ģ���� ���̵� ©���� ������ ���� �Ƚ�
���̽��Ͽ� ������ �� ���� ���� ������ �����ִ� �������� ����

20160724-1
�����غ��� ��û�ϰԵ� ���� ������ ���԰� �־���
Definder Ŭ������ resultScore �� �߰��Ͽ� ������ DB�� ������ �� �ְԲ� �߰��Ͽ���

20160724
���̽��� ���� �κ��� ���� ���ƴ�
������ �������� �߰��Ͽ����� ���� �׷��� �ִ� �׷��ȿ��� ������ �ٲپ���
��ư�� ������� ���׿� �� M ���Ҵ��� �˷��ִ� ���� ������ִ� ���׸� �Ƚ��ߴ�
������ ������ �̺�Ʈ �ʱ�ȭ�� �켱���� ��������
�����÷��̽����� ���� ���ε� �Ͽ���
https://play.google.com/store/apps/details?id=com.stories2.congcong

20160723-1
���ƴ�. MainManager ���� r_flag �� �̿��� Update�޼ҵ忡�� �ѹ��� �ʱ�ȭ ������ ��ĥ��
���� Ŀ�´����̼� �ϴ� �κ��� ȭ���� �ѷ����� ���ϰ� �ϴ� �����̿���
�� �κ��� ȭ�� �ѷ��� �Ŀ� �۾� �ϵ��� �켱������ �ڷ� �Ͽ���
���� ��ư�� ��ġ�ص� ������ ���� ������ �־��µ� �̴� Ŭ���� �Ǿ����� üũ�� �ϱ� ���� �ٽ�
���� ������ѹ����� �ٶ��� ��ŵ�Ǿ������ ��쿴��
�̸� ViewManager ���� ���� �״�� �����ϵ��� �����Ͽ���

20160723
�� ���ڱ� view�� �׷��ִ� ������ ��� ������ ��尡 �ϳ��� ������ �ʾ� ȭ�鿡 �ѷ����°� ����
�ù߽ù�

20160721
FacebookMenu ���� �� ���� ������ ȫ���� ������ �� �ִ� ����� ���õǾ���
���� �׽�Ʈ�� �Ͽ����� �� �۵���
RankMenu ���� �� ������ �����Ͽ� DB�� ����Ǿ� �ִ� ������ �����͵鿡 ���ؼ�
��� �����߿� TOP 10 �� �����ִ� ��ɰ� �� ģ���� �߿� TOP 10 �� �����ִ� ����� �����Ǿ� �ִ�

20160720
FacebookMenu ���� ���̽��ϰ� ����� �ϸ鼭 �α���ó�� ���� ������ �Ǿ��ִ� 
�̸� �����ϴ� �������� �ͼ�ġ �ʴ� SNS ���� �������� ���� ���ο� ������Ʈ�� unity38�� ����� �׽�Ʈ �Ͽ���
pcȭ���� ���������� ui �� ��µ����� ����ϱ�⿡�� �۵� ��Ű�� �α��� ui �� ��µǸ� ���������� ��������� �ȴ�


20160718
���������� CommunicationManager�� �̿��� �� ����� ����������
StartMenu �� �ڽ��� ������ �ʿ��� ������ ������Ʈ�� �ϴ� �޼ҵ尡 �����۵��ϴ°� ���� Ȯ���Ͽ���

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
�� ���� user �� MacAddress �� �ߺ��Ǵ� ���� ������� �ʴ´�
http://lamb.kangnam.ac.kr/congcong/index.php �� DB�� Ŭ���̾�Ʈ ���̿��� ���� �ϴ� ��Ȱ�� �Ѵ�
�Ű������� �� 0��°�� ������ ����� �Լ� ���� ������ �� ���Ŀ��� �� �Լ��� �۵��ϴµ� �ʿ�� �ϴ� �Ķ����
�� ������ �ȴ�


20160715
NetNode ���� �� url ��ũ �ּҿ� �� ��ũ�� ������������ ������� ���� ����̴�
CommunicateManager ���� ��Ʈ��ũ �����ϴµ� ���̴� ��Ʈ�� �޼ҵ尡 ž��Ǿ� �ִ�
RankMenu ���� TOP 10 ���� ��ũ�� �����ִ� ����� ���� �ִ�
ScoreMenu ���� GameMenu�� ���������� ȭ���� ��µȴ�
GameMenu ���� ĳ���Ͱ� �����̴� �߷��� ����ϴ� 2���Լ��� ������Ʈ �Ǿ���
������ lamb.kangnam.ac.kr �� ����ϸ� DB ������ �ӽ������� �Ϸ��Ͽ���
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

���� DB ������ ���� php ��ġ�� �����Ͽ���
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
�հ� 4
-rw-------. 1 root root 1076  3�� 16 06:11 anaconda-ks.cfg
[root@localhost ~]# cd /home/stories2/html/
[root@localhost html]# ls -l
�հ� 1956
-rw-r--r--  1 stories2 stories2 1989455  6�� 18 12:24 Desktop.unity3d
-rw-r--r--  1 stories2 stories2    3305  6�� 18 12:24 index.html
-rw-r--r--. 1 root     root          21  4��  9 09:38 info.php
lrwxrwxrwx. 1 root     root          22  4��  9 09:41 mysql -> /usr/share/phpMyAdmin/
drwxr-xr-x  6 stories2 stories2    4096  4�� 26 01:06 project_backup
[root@localhost html]# mkdir congcong
[root@localhost html]# cd congcong/
[root@localhost congcong]# vim index.php
[root@localhost congcong]#


20160714
ItemNode���� int �� �����Ͱ� ��� �׷��� ���μ��� ��ȣ�� �����Ѵ�
Defined �� draw jump max ������ 2���Լ��� �̿��� frame per speed �� �ִ밪�� �����Ѵ�
GameMenu ���� �������� ������ ����ȴ�
StartMenu ���� ó�� �ʱ�ȭ�鿡 ���� ó���� ����Ѵ�
ConvertManager���� ĳ������ frame per speed �� ���ϴ� 2���Լ� �� ���ǵǾ�����, �׷��� ������ �߽��� ã���ְ�
�ػ󵵿� ���� �÷��ִ� ũ�⸦ ����Ѵ�
MainManager ���� �޴� ��ȯ�� ������ �ִ� �Լ��� ���ǵǾ��ִ�

20160713 - 1
DrawNode ���� ȭ�鿡 �׷��� �����Ͱ� ����� ����̴�
DrawManager ���� DrawNode �� �����ϴ� ��Ʈ Ŭ�����̴�, ��ġ�� ť�� �����Ǿ� �ִ�
ViewManager ���� DrawManager�� �����Ͽ� DrawNode�� ����� �����͸� �����Ͽ� ȭ�鿡 �ѷ��ִ� ��Ȱ�� �Ѵ�
MainManager ���� ViewManager�� �׸� ������ 2���� ���Ƿ� �����Ͽ� �켱���� ����װ� ��� ������� �׽�Ʈ�Ѵ�

20160713
congcong�̶�� android ������ ����
Resources �������� 101.png ���� 236.png ���� �׷��� �ڷᰡ �� �ִ�
Scence �������� main ���� �� �ִ�
Source �������� ������ ���� �ҽ��� �� �ִ�

MainManager ������ ������ ��� API�� �� ��Ŀ������ ���� ���� �ȴ�
BufferManager ������ ��ü ��ũ�帮��Ʈ�� �����ϴµ� ���̴� ��尡 ���ǵȴ�
DefineManager ������ static ���� ����� �������� �����Ѵ�
IoManager ������ ������� ����Ѵ�
NetworkManager ������ ��Ʈ��ũ ����� ����Ѵ�
ProcessManager ������ ������ ó���� ��ǥ ����� �ַ� �Ѵ�
ViewManager ������ UI�� ����ϸ� ����ڿ��� ���� �������� �Ǵ� �κ��̴�

BufferManager ���� GraphicNode �� ���ǵǾ������� �̴� ��� �ϳ��� Texture2D �����Ͱ� ���� �ȴ�
FileManager ������ �׷��� ������ �ε��ϰ� �̸� ������������ �����ϴ� ��Ȱ�� �Ѵ�
ResourceManager ������ �׷��������� ��ŷ�ϰ� �߰�, ���� ����� ��� �ִ�
ViewManager ������ ȭ���� ����ϱ����� OnGUI�޼ҵ尡 ���ǵǾ� �ִ�