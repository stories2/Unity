using UnityEngine;
using System.Collections;

public class ScoreMenu : MonoBehaviour {

    public delegate void ChangeMenu(int menu_id);

    bool show = false, r_flag = true;
    DrawManager draw_manager;
    ConvertManager convert_manager;
    ItemNode draw_front = null, draw_rear = null;
    ChangeMenu change_menu;
    CommunicateManager communicate_manager;

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

                add(0.0F, 0.0F, 0.0F, new Rect(convert_manager.convert_to_bigger_position(new Vector2(0.2F, 0.4F)),
                    convert_manager.convert_to_bigger_position(new Vector2(0.6F, 0.2F))), new Rect(), false, null,
                    10, 0, "Score ", GUI.Label, null, null, null);

                add(0.0F, 0.0F, 0.0F, new Rect(convert_manager.convert_to_bigger_position(new Vector2(0.0F, 0.8F)),
                    convert_manager.convert_to_bigger_position(new Vector2(0.5F, 0.2F))), new Rect(), false, null,
                    9, 0,  "Share", null, GUI.Button, null, null);

                add(0.0F, 0.0F, 0.0F, new Rect(convert_manager.convert_to_bigger_position(new Vector2(0.5F, 0.8F)),
                    convert_manager.convert_to_bigger_position(new Vector2(0.5F, 0.2F))), new Rect(), false, null,
                    8, 0, "Re Game", null, GUI.Button, null, null);

                string mac = communicate_manager.get_mac();

                communicate_manager.add("arg0=update_time&arg1=" + mac + "&arg2=LastPlayTime");

                /*    DrawNode node = draw_manager.get_draw_node(1);
                    Debug.Log("pos "+node.get_position());*/
            }
            ItemNode node = draw_front;
            DrawNode draw_node = null;
            int node_id;
            //process
            /*while (node)
            {
                draw_node = draw_manager.get_draw_node(node.get_data());

                node = node.get_link();
            }*/

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
                    if (node_num == 1)
                    {
                        //r_flag = false;
                        //show = false;
                    }
                    else if(node_num == 2)
                    {
                        change_menu(6);
                    }
                    else if(node_num == 3)
                    {
                        change_menu(2);
                    }
                    all_del();
                    Destroy(this);
                }
                node = node.get_link();
            }
        }
        else
        {
            /*if (r_flag == false)
            {
                //r_flag = true;

                int node_id;
                while ((node_id = del()) != 0)
                {
                    draw_manager.search_del(node_id);
                }
                change_menu(2);
                Destroy(this);
            }*/
        }
    }

    public void set_communicate_manager(CommunicateManager communicate_manager)
    {
        this.communicate_manager = communicate_manager;
    }

    public void all_del()
    {
        int node_id = 0;
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
