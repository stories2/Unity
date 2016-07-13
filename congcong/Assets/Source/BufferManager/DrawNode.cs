using UnityEngine;
using System.Collections;

public class DrawNode : MonoBehaviour {

    public delegate void DrawFunc_label(Rect pos, string str);
    public delegate bool DrawFunc_box(Rect pos, string str);
    public delegate bool DrawFunc_toggle(Rect pos, bool toggle, string str);
    public delegate void DrawFunc_texture(Rect pos, Texture2D texture, Rect add_on_pos, float top_left, float top_right, float bot_left, float bot_right);

    DrawNode next_link;
    float return_val, min, max;
    Rect position, add_on_position;
    public bool return_event;
    Texture2D texture;
    int deep, node_id;
    DrawFunc_label func_label;
    DrawFunc_box func_box;
    DrawFunc_toggle func_toggle;
    DrawFunc_texture func_texture;
    string banner;

	// Use this for initialization
	void Start () {

        //init();
	}

    public void init()
    {
        next_link = null;
        position = new Rect();
        add_on_position = new Rect();
        return_val = 0.0F;
        min = 0.0F;
        max = 0.0F;
        return_event = false;
        texture = null;
        banner = "";
        func_box = null;
        func_label = null;
        func_toggle = null;
        func_toggle = null;

        /*DrawFunc test = new DrawFunc(GUI.Label);
        this.set_func(test);
        DrawFunc execute = get_func();
        execute(get_position(), get_banner());*/
    }

    public void set_func(DrawFunc_texture func_texture)
    {
        this.func_texture += func_texture;
    }

    public DrawFunc_texture get_func_texture()
    {
        return func_texture;
    }

    public DrawFunc_toggle get_func_toggle()
    {
        return func_toggle;
    }

    public void set_func(DrawFunc_toggle func_toggle)
    {
        this.func_toggle += func_toggle;
    }

    public void set_func(DrawFunc_box func_box)
    {
        this.func_box += func_box;
    }

    public DrawFunc_box get_func_box()
    {
        return func_box;
    }

    public string get_banner()
    {
        return banner;
    }

    public void set_banner(string banner)
    {
        this.banner = banner;
    }

    public DrawFunc_label get_func_label()
    {
        return func_label;
    }

    public void set_func(DrawFunc_label func_label)
    {
        this.func_label += func_label;
    }

    public void set_node_id(int node_id)
    {
        this.node_id = node_id;
    }
    public int get_node_id()
    {
        return node_id;
    }
    public void set_deep(int deep)
    {
        this.deep = deep;
    }
    public int get_deep()
    {
        return deep;
    }

    public bool get_return_event()
    {
        return return_event;
    }

    public void set_return_event(bool return_event)
    {
        if(return_event)
            Debug.Log("clicked");
        this.return_event = return_event;
    }

    public float get_return_val()
    {
        return return_val;
    }

    public void set_return_val(float return_val)
    {
        this.return_val = return_val;
    }

    public float get_max()
    {
        return max;
    }
    
    public void set_max(float max)
    {
        this.max = max;
    }

    public float get_min()
    {
        return min;
    }

    public void set_min(float min)
    {
        this.min = min;
    }

    public Texture2D get_texture()
    {
        return texture;
    }

    public void set_texture(Texture2D texture)
    {
        this.texture = texture;
    }

    public Rect get_add_on_position()
    {
        return add_on_position;
    }

    public void set_add_on_position(Rect add_on_position)
    {
        this.add_on_position = add_on_position;
    }

    public Rect get_position()
    {
        return position;
    }

    public void set_position(Rect position)
    {
        this.position = position;
    }

    public void set_link(DrawNode next_link)
    {
        this.next_link = next_link;
    }

    public DrawNode get_link()
    {
        return next_link;
    }
}
