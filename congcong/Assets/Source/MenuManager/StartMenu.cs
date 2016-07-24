using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

    public delegate void ChangeMenu(int menu_id);
    public delegate NetNode communicate(NetNode target, long time_limit);

    bool show = false, r_flag = true;
    DrawManager draw_manager;
    ConvertManager convert_manager;
    ItemNode draw_front = null, draw_rear = null;
    ChangeMenu change_menu;
    CommunicateManager communication_manager;
    communicate communicate_func;
    string mac, error = "", event_log = "";
    int node_num;

	// Use this for initialization
	void Start () {
	
        r_flag = true;
	}
	
	// Update is called once per frame
	void Update () {
	
        if(show)
        {
            try
            {

                if (r_flag == true)
                {
                    r_flag = false;

                    //Debug.Log("w : " + Screen.width + " h " + Screen.height);

                    add(0.0F, 0.0F, 0.0F, new Rect(convert_manager.convert_to_bigger_position(new Vector2(0.2F, 0.4F)),
                        convert_manager.convert_to_bigger_position(new Vector2(0.6F, 0.2F))), new Rect(), false, null,
                        10, 0, "Start Game", null, GUI.Button, null, null);

                    add(0.0F, 0.0F, 0.0F, new Rect(convert_manager.convert_to_bigger_position(new Vector2(0.0F, 0.8F)),
                        convert_manager.convert_to_bigger_position(new Vector2(0.5F, 0.2F))), new Rect(), false, null,
                        9, 0, "Rank", null, GUI.Button, null, null);

                    add(0.0F, 0.0F, 0.0F, new Rect(convert_manager.convert_to_bigger_position(new Vector2(0.5F, 0.8F)),
                        convert_manager.convert_to_bigger_position(new Vector2(0.5F, 0.2F))), new Rect(), false, null,
                        8, 0, "Friend", null, GUI.Button, null, null);


                    mac = communication_manager.get_mac();
                    //communicate_func(net_node, Defined.delay_time_limit);
                    //communication_manager.del();


                    // communicate_func(net_node, Defined.delay_time_limit);
                    //communication_manager.del();
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
                    communication_manager.add("arg0=update_time&arg1=" + mac + "&arg2=EOGTime");
                    Application.Quit();
                }
                node_num = 0;
                while (node)
                {
                    node_num += 1;
                    draw_node = draw_manager.get_draw_node(node.get_data());
                    if (draw_node.get_return_event() == true)
                    {
                        node_id = node.get_data();
                        event_log = "node #" + node_id + " event ok";
                        Debug.Log(event_log);
                        
                        communication_manager.all_del();
                        if (node_num == 1)
                        {
                            //r_flag = false;
                            show = false;
                            all_del();
                            change_menu(2);
                            Destroy(this);
                            break;
                        }
                        else if (node_num == 2)
                        {
                            show = false;
                            all_del();
                            change_menu(4);
                            Destroy(this);
                            break;
                        }
                        else if (node_num == 3)
                        {
                            show = false;
                            all_del();
                            change_menu(5);
                            Destroy(this);
                            break;
                        }
                    }
                    node = node.get_link();
                }
            }
            catch(UnityException err)
            {
                error = err.ToString();
            }
        }
        else
        {
            if(r_flag == false)
            {
                //r_flag = true;

            }
        }
	}
    /*
    void OnGUI()
    {
        //GUI.Label(new Rect(200, 0, 100, 20), "Menu");
        GUI.Label(new Rect(200, 0, 300, 20), "start menu "+error+" 노드 "+node_num + " event "+event_log);
        if(draw_front)
        {
            GUI.Label(new Rect(200, 20, 300, 20), "DrawFront not null");

            DrawNode draw_node = null;
            ItemNode node = draw_front;
            int height = 400;
            while (node)
            {
                
                draw_node = draw_manager.get_draw_node(node.get_data());
                if (draw_node)
                {
                    GUI.Label(new Rect(0, height,480 , 20), "DrawNode #"+node.get_data() + " draw_node event : "+draw_node.get_return_event());
                    
                }
                height += 20;
                node = node.get_link();
            }
        }
    }*/

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
        while((node_id = del()) != 0)
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
        if(node)
        {
            int node_id = draw_manager.add(return_val, min, max, pos, add_on_pos, return_event, texture, deep, id, banner, func_label, func_box, func_texture, func_toggle);
            node.set_data(node_id);
            if(draw_front)
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
