using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {

    public delegate void ChangeMenu(int menu_id);

    bool show = false, r_flag = true;
    DrawManager draw_manager;
    ConvertManager convert_manager;
    ItemNode draw_front = null, draw_rear = null;
    ChangeMenu change_menu;
    FileManager file_manager;
    int frame = 0,jump_frame = Defined.jump_frame_max + 1;
    DrawNode main_character;

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
            frame += 1;
            jump_frame += 1;
            if (r_flag == true)
            {
                r_flag = false;
                frame = 0;

                add(0.0F, 0.0F, 0.0F, new Rect(convert_manager.convert_to_bigger_position(new Vector2(0.05F, 0.05F)),
                    convert_manager.convert_to_bigger_position(new Vector2(0.1F, 0.1F))), new Rect(), false, null, 20, 0, "M", GUI.Label,
                    null, null, null);

                Texture2D me = file_manager.get_resource(1);
                float x, y, width, height;

                float scale = convert_manager.get_scale(me, new Vector2(0.05F, 0.0F), me.width / 4);//(float)convert_manager.convert_to_bigger_position(new Vector2(0.2F, 0.0F)).x / ((float)me.width / 4.0F);
                
                width = me.width / 4 * scale;
                height = me.height / 4 * scale;
                x = 0.5F;
                y = 0.5F;
                float draw_x, draw_y;
                Vector2 draw_pos = convert_manager.convert_to_smaller_position(new Vector2(width, height));
                draw_x = x - draw_pos.x / 2;
                draw_y = y - draw_pos.y / 2;

                add(0.0F, 0.0F, 0.0F, new Rect(convert_manager.convert_to_bigger_position(new Vector2(draw_x, draw_y)),
                    new Vector2(width, height)), new Rect(1 / me.width, (float)(me.height - me.height / 4 * 3 )/me.height, (float)1 / 4, (float)1 / 4), false, me, 19, 0, "", null, null, Graphics.DrawTexture, null);

                main_character = draw_manager.get_draw_node(draw_front.get_link().get_data());
            }
            ItemNode node = draw_front;
            DrawNode draw_node = null;
            int node_id;
            //process
            if(frame % 20 == 0)
            {

                Rect addon_rect = main_character.get_add_on_position();
                Debug.Log("before " + addon_rect);
                addon_rect.x += 0.25F;
                if(addon_rect.x >= 1)
                {
                    addon_rect.x = 0F;
                }
                main_character.set_add_on_position(addon_rect);
                Debug.Log("after "+addon_rect);
            }


            Rect pos = main_character.get_position();
            Vector2 x_y, width_height;
            x_y = new Vector2(pos.x, pos.y);
            width_height = new Vector2(pos.width, pos.height);
            x_y = convert_manager.convert_to_smaller_position(x_y);
            x_y.y = x_y.y + convert_manager.get_speed(jump_frame);
            x_y = convert_manager.convert_to_bigger_position(x_y);
            main_character.set_position(new Rect(x_y, width_height));

            //i/o
            while (node)
            {
                draw_node = draw_manager.get_draw_node(node.get_data());
                if (draw_node.get_return_event() == true)
                {
                    node_id = node.get_data();
                    Debug.Log("node #" + node_id + " event ok");
                }
                node = node.get_link();
            }
            int i;
            for (i = 0; i < 2; i += 1)
            {
                if (Input.GetMouseButtonDown(i))
                {
                    jump_frame = 0;
                    //event_func(Input.mousePosition, i, TouchPhase.Began);
                }
                if (Input.GetMouseButtonUp(i))
                {
                    //event_func(Input.mousePosition, i, TouchPhase.Ended);
                }
            }
        }
        else
        {
            if (r_flag == false)
            {
                //r_flag = true;

                int node_id;
                while ((node_id = del()) != 0)
                {
                    draw_manager.search_del(node_id);
                }
                //change_menu(2);
                Destroy(this);
            }
        }
    }


    public void set_change_menu(ChangeMenu change_menu)
    {
        this.change_menu = change_menu;
    }

    public void set_file_manager(FileManager file_manager)
    {
        this.file_manager = file_manager;
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
