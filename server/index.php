<?php
	error_reporting(E_ALL);
	ini_set("display_errors",1);
	define("Error",-1);
	
	function terminal()
	{
		$data = array();
		$data = parser();
		if(count($data) == 0)
		{
			echo 'Bye';
		}
		else
		{
			global $Error;
			$fail = $Error;
			$function = $data[0];
			unset($data[0]);
			$fail = $function($data); 
			tell_result($fail);
		}
		
	}
	
	function db_init()
	{
		$host = "127.0.0.1";
		$id = "root";
		$pw = "toortoor%^%";
		$db_name = "congcong";
		
		$db = mysqli_connect($host, $id, $pw, $db_name);
		mysqli_query($db, "set session character_set_connection = utf8;");
		mysqli_query($db, "set session character_set_result = utf8;");
		mysqli_query($db, "set session character_set_client = utf8;");

		return $db;
	}

	function show_error($connection)
	{
		$error_str = mysqli_error($connection);
		if($error_str != "")
		{
			echo $error_str.'<br>';
			return 1;
		}
		return 0;	
	}

	function tell_result($is_ok)
	{
		if($is_ok == 0)
			echo 'ok';
		else if($is_ok > 0)
			echo $is_ok;
	}

	function get_friend_top($data)// 0 : func , 1 : macAddress
	{
		global $Error;
		$count = 0;
		$fail = $Error;
		$db = db_init();
		$myID = get_player_id($data[1]);
		$ranks = mysqli_query($db, "select * from rank order by Score DESC;");
		while(!empty($rankRow = mysqli_fetch_array($ranks, MYSQLI_NUM)))
		{
			$isMyFriend = mysqli_query($db, "select * from friend where PlayerId = ".$myID.";");
			while(!empty($friendRow = mysqli_fetch_array($isMyFriend, MYSQLI_NUM)))
			{
				if($count >= 11)
				{
					break;
				}
				if($friendRow[1] == $rankRow[0])
				{
					$count += 1;
					printf("%s %s\n", $rankRow[0], $rankRow[1]);
				}
			}
			if($count >= 11)
			{
				break;
			}
		}
		$fail = show_error($db);
		mysqli_close($db);
		return $fail;
	}

	function get_top($data)// 0 : func
	{
		global $Error;
		$count = 0;
		$fail = $Error;
		$db = db_init();
		$result = mysqli_query($db, "select * from rank order by Score DESC;");
		while(!empty($row = mysqli_fetch_array($result, MYSQLI_NUM)))
		{
			$count = $count + 1;
			if($count >= 11)
			{
				break;
			}
			printf("%s %s\n", $row[0], $row[1]);
		}
		mysqli_free_result($result);
		$fail = show_error($db);
		mysqli_close($db);
		return $fail;
	}

	function echo_player_id($data)// 0 : func, 1 : mac address
	{
		global $Error;
		$fail = $Error;
		$db = db_init();
		$result = mysqli_query($db, "select PlayerId from user where MacAddress = '".$data[1]."';");
		$fail = show_error($db);
		$row = mysqli_fetch_row($result);
		mysqli_close($db);
		if(!empty($row))
			return $row[0];
		else
			return $fail;
	}

	//code function , plz dont call from client 
	function get_player_id($player_mac_address)
	{
		global $Error;
		$fail = $Error;
		$db = db_init();
		$result = mysqli_query($db, "select PlayerId from user where MacAddress = '".$player_mac_address."';");
		$fail = show_error($db);
		$row = mysqli_fetch_row($result);
		mysqli_close($db);
		return $row[0];
	}
	
	function set_facebook_id($data)// o : func, 1 : mac address, 2 : facebook id
	{
		global $Error;
		$fail = $Error;
		$db = db_init();
		mysqli_query($db, "update user set FaceBookId = '".$data[2]."' where MacAddress = '".$data[1]."';");
		$fail = show_error($db);
		mysqli_close($db);
		return $fail;
	}
	
	function update_time($data)// 0 : func, 1 : mac address, 2 : what time?
	{
		global $Error;
		$fail = $Error;
		$db = db_init();
		$sql =  "update user set ".$data[2]." = now() where MacAddress = '".$data[1]."';";
		mysqli_query($db, $sql);
		$fail = show_error($db);
		mysqli_close($db);
		return $fail;
	}
	
	function del_friend($data)// 0 : func, 1 : my player id , 2 : friend player id
	{
		global $Error;
		$fail = $Error;
		$db = db_init();
		mysqli_query($db, "update friend set Broke = 1 where PlayerId = ".$data[1]." and FriendId = ".$data[2]." ;");
		mysqli_query($db, "update friend set UpdateTime = now() where PlayerId = ".$data[1]." and FriendId = ".$data[2]." ;");

		$fail = show_error($db);
		mysqli_close($db);
		return $fail;
	}
		
	function add_friend($data)// 0 : func, 1 : my player id , 2 : friend player id
	{
		global $Error;
		$fail = $Error;
		$db = db_init();	
		mysqli_query($db, "insert into friend (PlayerId, FriendId) values (".$data[1].", ".$data[2]."), (".$data[2].", ".$data[1].");");
		$fail = show_error($db);
		mysqli_close($db);
		return $fail;
	}

	function update_score($data)// 0 : func , 1 : mac address , 2 : score
	{
		global $Error;
		$fail = $Error;
		$db = db_init();
		$player_id = get_player_id($data[1]);
		$sql =  "update rank set Score =".$data[2]." where PlayerId =".$player_id.";";
		mysqli_query($db, $sql);
		$fail = show_error($db);
		mysqli_close($db);
		return $fail;
	}
	
	function new_bee($data)// 0 : func, 1 : mac address
	{
		global $Error;
		$fail = $Error;
		$db = db_init();
		mysqli_query($db, "insert into user (MacAddress) value('".$data[1]."');");	
		mysqli_query($db, "insert into rank (PlayerId) value(".get_player_id($data[1]).");");
		$fail = show_error($db);
		mysqli_close($db);
		return $fail;
	}	

	function hello($data)
	{
		print_r($data);
	}

	function parser()
	{
		$data = array();
		$i = 0;
		while(!empty($_GET['arg'.$i]))
		{
			array_push($data,$_GET['arg'.$i]);
			$i = $i + 1;
		}
		return $data;
	}
	terminal();
?>
