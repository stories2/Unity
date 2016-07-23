using UnityEngine;
using System.Collections;

public class MainManager : MonoBehaviour {

    FileManager file_manager;
    ViewManager view_manager;
    TouchManager touch_manager;
    ConvertManager convert_manager;
    StartMenu start_menu;
    GameMenu game_menu;
    ScoreMenu score_menu;
    RankMenu rank_menu;
    public Camera camera;
    CommunicateManager communication_manager;
    FriendMenu friend_menu;
    FacebookMenu facebook_menu;
    bool state;
    string error = "";

    bool r_flag;
	// Use this for initialization
	void Start () {

        init();
	}

    public void init()
    {
        this.file_manager = gameObject.AddComponent<FileManager>();
        this.view_manager = gameObject.AddComponent<ViewManager>();
        this.touch_manager = gameObject.AddComponent<TouchManager>();
        this.convert_manager = gameObject.AddComponent<ConvertManager>();
        communication_manager = gameObject.AddComponent<CommunicateManager>();
        //communication_manager.add("http://lamb.kangnam.ac.kr/congcong/index.php");
        //this.start_menu = gameObject.AddComponent<StartMenu>();

        //view_manager.get_draw_manager().add()
        r_flag = true;
        state = true;
    }
	
	// Update is called once per frame
	void Update () {
	
        try
        {

            if (r_flag)
            {
                r_flag = false;

                file_manager.init();
                if (file_manager.load_resource())
                {
                    Debug.Log("Load Ok");

                    touch_manager.init(touch_event_manager);
                    convert_manager.init();

                    string mac = communication_manager.get_mac();
                    communication_manager.add("arg0=new_bee&arg1=" + mac);
                    communication_manager.add("arg0=update_time&arg1=" + mac + "&arg2=ConnectTime");

                    create_menu(1);

                    state = true;
                }
                else
                {
                    Debug.Log("Load Error");

                    state = false;
                }
                /*Texture2D test = file_manager.get_resource(2);

                view_manager.get_draw_manager().add(0.0F, 0.0F, 0.0F, new Rect(100, 0, 100, 50), new Rect(0, 0, 0, 0), false, null, 2, 0, "hello world",
                    null, null, null, GUI.Toggle);
                view_manager.get_draw_manager().add(0.0F, 0.0F, 0.0F, new Rect(0, 0, 100, 50), new Rect(0, 0, 0, 0), false, null, 1, 0, "hello world",
                    null, GUI.Button, null, null);

                view_manager.get_draw_manager().add(0.0F, 0.0F, 0.0F, new Rect(200, 0, 32, 32), new Rect(1 / test.width, 1 / test.height, 1, 1), false, test, 3, 0, "", null,
                    null, Graphics.DrawTexture, null);*/
            }    
        }
        catch(UnityException err)
        {
            state = false;
        }    
	}

    void OnGUI()
    {
        if(Defined.screen_captured != null)
        {
            Graphics.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Defined.screen_captured);
        }
        if(state)
        {
            GUI.Label(new Rect(0, 0, 100, 20), "Pass / " + error);
        }
    }

    public void create_menu(int menu_id)
    {
        if(menu_id == 1)//start menu
        {
            try
            {
                if (start_menu)
                {
                    Destroy(start_menu);
                }
                start_menu = gameObject.AddComponent<StartMenu>();
                start_menu.set_change_menu(create_menu);
                start_menu.set_draw_manager(view_manager.get_draw_manager());
                start_menu.set_convert_manager(convert_manager);
                start_menu.set_communication_manager(communication_manager);
                start_menu.set_communication_func(communication_manager.wait_for_respone);
                start_menu.set_show(true);
            }
            catch(UnityException err)
            {
                error = err.ToString();
            }
        }
        if(menu_id == 2)//game menu
        {
            if(game_menu)
            {
                Destroy(game_menu);
            }
            game_menu = gameObject.AddComponent<GameMenu>();
            game_menu.set_change_menu(create_menu);
            game_menu.set_draw_manager(view_manager.get_draw_manager());
            game_menu.set_convert_manager(convert_manager);
            game_menu.set_file_manager(file_manager);
            game_menu.set_camera(camera);
            game_menu.set_take_cap_func(start_capture);
            view_manager.set_capture(game_menu.take_a_screen_shot);
            
            game_menu.set_show(true);
        }
        if (menu_id == 3)//score menu
        {
            if (score_menu)
            {
                Destroy(score_menu);
            }
            score_menu = gameObject.AddComponent<ScoreMenu>();
            score_menu.set_change_menu(create_menu);
            score_menu.set_draw_manager(view_manager.get_draw_manager());
            score_menu.set_convert_manager(convert_manager);
            score_menu.set_communicate_manager(communication_manager);
            score_menu.set_show(true);
        }
        if(menu_id == 4)//rank menu
        {
            if(rank_menu)
            {
                Destroy(rank_menu);
            }
            rank_menu = gameObject.AddComponent<RankMenu>();
            rank_menu.set_change_menu(create_menu);
            rank_menu.set_draw_manager(view_manager.get_draw_manager());
            rank_menu.set_convert_manager(convert_manager);
            rank_menu.set_communicate_manager(communication_manager);
            rank_menu.set_show(true);
        }
        if(menu_id == 5)//friend menu
        {
            if (friend_menu)
            {
                Destroy(friend_menu);
            }
            friend_menu = gameObject.AddComponent<FriendMenu>();
            friend_menu.set_change_menu(create_menu);
            friend_menu.set_draw_manager(view_manager.get_draw_manager());
            friend_menu.set_convert_manager(convert_manager);
            friend_menu.set_communication_manager(communication_manager);
            friend_menu.set_communication_func(communication_manager.wait_for_respone);
            friend_menu.set_show(true);
        }
        if(menu_id == 6)
        {
            if (facebook_menu)
            {
                Destroy(facebook_menu);
            }
            facebook_menu = gameObject.AddComponent<FacebookMenu>();
            facebook_menu.set_change_menu(create_menu);
            facebook_menu.set_draw_manager(view_manager.get_draw_manager());
            facebook_menu.set_convert_manager(convert_manager);
            facebook_menu.set_communication_manager(communication_manager);
            facebook_menu.set_communication_func(communication_manager.wait_for_respone);
            facebook_menu.set_show(true);
        }
    }

    public void start_capture()
    {
        view_manager.set_take_it();
    }

    public void touch_event_manager(Vector2 pos, int finger_id, TouchPhase action)
    {
        pos = convert_manager.reversal_small_y(convert_manager.convert_to_smaller_position(pos));
        Debug.Log("pos : " + pos.x + " , " + pos.y + " : " + finger_id + " action " + action);
    }

    void OnDestroy()
    {
        file_manager.release_resource();
    }
}
