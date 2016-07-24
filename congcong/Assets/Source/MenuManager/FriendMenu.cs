using UnityEngine;
using System.Collections;

public class FriendMenu : MonoBehaviour {

    public delegate void ChangeMenu(int menu_id);
    public delegate NetNode communicate(NetNode target, long time_limit);

    bool show = false, r_flag = true, deleteFriend = false, addFriend = false, showPopUp = false;
    DrawManager draw_manager;
    ConvertManager convert_manager;
    ItemNode draw_front = null, draw_rear = null;
    ChangeMenu change_menu;
    CommunicateManager communication_manager;
    communicate communicate_func;
    string mac, friendID = "";
    NetNode focuse_me;

    // Use this for initialization
    void Start()
    {

        r_flag = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (show)
        {
            if (r_flag == true)
            {
                r_flag = false;

                //Debug.Log("w : " + Screen.width + " h " + Screen.height);

                add(0.0F, 0.0F, 0.0F, new Rect(convert_manager.convert_to_bigger_position(new Vector2(0.1F, 0.1F)),
                    convert_manager.convert_to_bigger_position(new Vector2(0.6F, 0.05F))), new Rect(), false, null,
                    10, 0, "Friend", GUI.Label, null, null, null);

                add(0.0F, 0.0F, 0.0F, new Rect(convert_manager.convert_to_bigger_position(new Vector2(0.0F, 0.8F)),
                    convert_manager.convert_to_bigger_position(new Vector2(0.5F, 0.2F))), new Rect(), false, null,
                    9, 0, "Add", null, GUI.Button, null, null);

                add(0.0F, 0.0F, 0.0F, new Rect(convert_manager.convert_to_bigger_position(new Vector2(0.5F, 0.8F)),
                    convert_manager.convert_to_bigger_position(new Vector2(0.5F, 0.2F))), new Rect(), false, null,
                    8, 0, "Del", null, GUI.Button, null, null);


                mac = communication_manager.get_mac();
                //communicate_func(net_node, Defined.delay_time_limit);
                //communication_manager.del();

                //net_node = communication_manager.add("arg0=update_time&arg1=" + mac + "&arg2=ConnectTime");
                // communicate_func(net_node, Defined.delay_time_limit);
                //communication_manager.del();
                /*    DrawNode node = draw_manager.get_draw_node(1);
                    Debug.Log("pos "+node.get_position());*/

                focuse_me = communication_manager.add("arg0=get_friend&arg1=" + mac);

            }
            ItemNode node = draw_front;
            DrawNode draw_node = null;
            int node_id;
            //process
            if(focuse_me.get_result() != "")
            {
                ParseAndPaste(focuse_me.get_result());
                focuse_me.set_result("");
            }

            //i/o
            int node_num = 0;
            deleteFriend = false;
            while (node)
            {
                node_num += 1;
                draw_node = draw_manager.get_draw_node(node.get_data());
                if(draw_node.get_return_event() && deleteFriend)
                {
                    communication_manager.add("arg0=del_friend&arg1=" + mac + "&arg2=" + ParseUserID(draw_node.get_banner()));
                }
                if (draw_node.get_return_event() == true)
                {
                    node_id = node.get_data();
                    Debug.Log("node #" + node_num + " event ok");
                    if (node_num == 2)//Add Button
                    {/*
                        //r_flag = false;
                        show = false;
                        all_del();
                        change_menu(2);
                        Destroy(this);
                        break;*/
                        showPopUp = true;
                        draw_node.set_return_event(false);
                    }
                    else if (node_num == 3)//Del Button
                    {/*
                        show = false;
                        all_del();
                        change_menu(4);
                        Destroy(this);
                        break;*/
                        deleteFriend = true;
                    }
                }
                node = node.get_link();
            }
            if(deleteFriend)
            {
                all_del();
                change_menu(5);
                Destroy(this);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(showPopUp)
                {
                    showPopUp = false;
                }
                else
                {
                    all_del();
                    change_menu(1);
                    Destroy(this);
                }
            }
        }
        else
        {
            if (r_flag == false)
            {
                //r_flag = true;

            }
        }
    }

    void OnGUI()
    {
        if(showPopUp)
        {
            GUI.Window(0, new Rect(convert_manager.convert_to_bigger_position(new Vector2(0.2F, 0.2F)),
                convert_manager.convert_to_bigger_position(new Vector2(0.6F, 0.4F))), PopUp, "Type Friend ID");
        }
    }

    void PopUp(int windowID)
    {
        bool confirm;
        friendID = GUI.TextField(new Rect(convert_manager.convert_to_bigger_position(new Vector2(0.05F,0.05F)),
            convert_manager.convert_to_bigger_position(new Vector2(0.5F, 0.1F))), friendID);

        confirm = GUI.Button(new Rect(convert_manager.convert_to_bigger_position(new Vector2(0.05F, 0.2F)),
            convert_manager.convert_to_bigger_position(new Vector2(0.5F, 0.1F))), "Confirm");

        if (confirm && CheckID(friendID))
        {
            communication_manager.add("arg0=add_friend&arg1=" + mac + "&arg2=" + friendID);
            showPopUp = false;
            all_del();
            change_menu(5);
            Destroy(this);
        }
    }

    bool CheckID(string id)
    {
        int i, length = id.Length;
        if (length == 0)
            return false;
        for(i = 0; i < length ; i += 1)
        {
            if('0' > id[i] && id[i] > '9')
            {
                return false;
            }
        }
        return true;
    }

    public string ParseUserID(string data)
    {
        bool readStart = false;
        int i, length = data.Length;
        string result = "";
        for(i = 0; i < length; i += 1)
        {
            if(readStart)
            {
                if ('0' <= data[i] && data[i] <= '9')
                {
                    result = result + data[i];
                }
                else
                {
                    break;
                }
            }
            
            if(data[i] == '#')
            {
                readStart = true;
            }
        }
        return result;
    }

    public void ParseAndPaste(string result)
    {
        int i, length = result.Length, deep = 7;
        string friend_info = "";
        float y = 0.15F, height = 0.05F;
        bool paste = false, end = false ;
        for(i = 0; i < length; i += 1)
        {
            if(paste)
            {
                add(0.0F, 0.0F, 0.0F, new Rect(convert_manager.convert_to_bigger_position(new Vector2(0.1F, y)),
                    convert_manager.convert_to_bigger_position(new Vector2(0.5F, height))), new Rect(), false, null,
                    deep, 0, "#" + friend_info, null, null, null, GUI.Toggle);

                y = y + height;
                friend_info = "";
                deep = deep - 1;
                paste = false;
                if(end)
                {
                    break;
                }
            }
            else
            {
                if(('a' <= result[i] && result[i] <= 'z') || result[i] == '\n')
                {
                    if ('a' <= result[i] && result[i] <= 'z')
                    {
                        end = true;
                    }
                    paste = true;
                }
                else
                {
                    friend_info = friend_info + result[i];
                }
            }
        }
    }

    public void set_communication_func(communicate communicate_target)
    {
        this.communicate_func = communicate_target;
    }

    public void set_communication_manager(CommunicateManager communication_manager)
    {
        this.communication_manager = communication_manager;
    }

    public void all_del()
    {
        int node_id;
        while ((node_id = del()) != 0)
        {
            draw_manager.search_del(node_id);
        }
    }

    public void set_change_menu(ChangeMenu change_menu)
    {
        this.change_menu = change_menu;
    }

    public int del()
    {
        int data;
        if (is_empty())
            return 0;
        ItemNode node = draw_front;
        data = node.get_data();
        draw_front = node.get_link();
        Destroy(node);
        return data;
    }

    public bool is_empty()
    {
        return draw_front == null;
    }

    public void add(float return_val, float min, float max, Rect pos, Rect add_on_pos, bool return_event, Texture2D texture,
        int deep, int id, string banner, DrawNode.DrawFunc_label func_label, DrawNode.DrawFunc_box func_box, DrawNode.DrawFunc_texture func_texture,
        DrawNode.DrawFunc_toggle func_toggle)
    {
        ItemNode node = gameObject.AddComponent<ItemNode>();
        if (node)
        {
            int node_id = draw_manager.add(return_val, min, max, pos, add_on_pos, return_event, texture, deep, id, banner, func_label, func_box, func_texture, func_toggle);
            node.set_data(node_id);
            if (draw_front)
            {
                draw_rear.set_link(node);
            }
            else
            {
                draw_front = node;
            }
            draw_rear = node;
        }

    }

    public void set_convert_manager(ConvertManager convert_manager)
    {
        this.convert_manager = convert_manager;
    }

    public void set_show(bool show)
    {
        this.show = show;
    }

    public void set_draw_manager(DrawManager draw_manager)
    {
        this.draw_manager = draw_manager;
    }
}
