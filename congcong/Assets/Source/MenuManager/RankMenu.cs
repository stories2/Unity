using UnityEngine;
using System.Collections;

public class RankMenu : MonoBehaviour {


    public delegate void ChangeMenu(int menu_id);

    bool show = false, r_flag = true;
    DrawManager draw_manager;
    ConvertManager convert_manager;
    ItemNode draw_front = null, draw_rear = null;
    ChangeMenu change_menu;
    CommunicateManager communicate_manager;
    NetNode focuse_me;
    string order = "arg0=get_top";

    // Use this for initialization
    void Start()
    {
        order = "arg0=get_top";
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

                add(0.0F, 0.0F, 0.0F, new Rect(convert_manager.convert_to_bigger_position(new Vector2(0.1F, 0.1F)),
                    convert_manager.convert_to_bigger_position(new Vector2(0.6F, 0.05F))), new Rect(), false, null,
                    10, 0, "TOP 10", GUI.Label, null, null, null);

                add(0.0F, 0.0F, 0.0F, new Rect(convert_manager.convert_to_bigger_position(new Vector2(0.0F, 0.8F)),
                    convert_manager.convert_to_bigger_position(new Vector2(0.5F, 0.2F))), new Rect(), false, null,
                    9, 0, "ALL", null, GUI.Button, null, null);

                add(0.0F, 0.0F, 0.0F, new Rect(convert_manager.convert_to_bigger_position(new Vector2(0.5F, 0.8F)),
                    convert_manager.convert_to_bigger_position(new Vector2(0.5F, 0.2F))), new Rect(), false, null,
                    8, 0, "Friend", null, GUI.Button, null, null);

                focuse_me = communicate_manager.add(order);
            }
            ItemNode node = draw_front;
            DrawNode draw_node = null;
            int node_id;
            //process
            if(focuse_me.get_result() != "")
            {
                parse_score_data(focuse_me.get_result());
                focuse_me.set_result("");
            }
            //i/o

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                all_del();
                change_menu(1);
                Destroy(this);
            }
            int node_num = 0;
            while (node)
            {
                node_num += 1;
                draw_node = draw_manager.get_draw_node(node.get_data());
                if (draw_node.get_return_event() == true)
                {
                    node_id = node.get_data();
                    Debug.Log("node #" + node_id + " event ok");
                    if (node_num == 2)
                    {
                        all_del();
                        communicate_manager.all_del();
                        change_menu(4);
                        Destroy(this);
                    }
                    else if (node_num == 3)
                    {
                        all_del();
                        communicate_manager.all_del();
                        r_flag = true;
                        string mac = communicate_manager.get_mac();
                        order = "arg0=get_friend_top&arg1=" + mac;
                    }
                }
                node = node.get_link();
            }
        }
    }

    public void parse_score_data(string data)
    {
        int i, length = data.Length, uiDeep = 7;
        float labelY = 0.15F, height = 0.05F;
        string playerID = "", score = "";
        bool write_playerID = true;
        for(i = 0; i < length; i += 1)
        {
            if('0' <= data[i] && data[i] <= '9')
            {
                if(write_playerID)
                {
                    playerID = playerID + data[i];
                }
                else
                {
                    score = score + data[i];
                }
            }
            else
            {
                if(data[i] == ' ')
                {
                    write_playerID = false;
                }
                else if(data[i] == '\n')
                {
                    add(0.0F, 0.0F, 0.0F, new Rect(convert_manager.convert_to_bigger_position(new Vector2(0.1F, labelY)),
                    convert_manager.convert_to_bigger_position(new Vector2(0.3F, height))), new Rect(), false, null,
                    uiDeep, 0, "#" + playerID, GUI.Box, null, null, null);

                    uiDeep = uiDeep - 1;

                    add(0.0F, 0.0F, 0.0F, new Rect(convert_manager.convert_to_bigger_position(new Vector2(0.4F, labelY)),
                    convert_manager.convert_to_bigger_position(new Vector2(0.3F, height))), new Rect(), false, null,
                    uiDeep, 0, score, GUI.Box, null, null, null);

                    uiDeep = uiDeep - 1;

                    labelY = labelY + height;
                    write_playerID = true;
                    playerID = "";
                    score = "";
                }
                else
                {
                    break;
                }
            }
        }
    }

    public void set_communicate_manager(CommunicateManager communicate_manager)
    {
        this.communicate_manager = communicate_manager;
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
