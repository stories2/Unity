using UnityEngine;
using System.Collections;

public class ViewManager : MonoBehaviour {

    public delegate Texture2D screen_capture();

    DrawManager draw_manager = null;
    screen_capture capture;
    bool take_it = false;
	// Use this for initialization
	void Start () {

        take_it = false;
        init();
	}

    public void set_draw_manager(DrawManager draw_manager)
    {
        this.draw_manager = draw_manager;
    }

    public DrawManager get_draw_manager()
    {
        return draw_manager;
    }

    public void init()
    {
        draw_manager = gameObject.AddComponent<DrawManager>();
    }

    public void set_capture(screen_capture capture)
    {
        this.capture += capture;
    }

    public void set_take_it()
    {
        take_it = true;
    }

    void OnGUI()
    {
        DrawNode node = draw_manager.get_front();
        while(node)
        {
            if(node.get_func_box() != null)
            {
                /*DrawFunc test = new DrawFunc(GUI.Label);
        this.set_func(test);
        DrawFunc execute = get_func();
        execute(get_position(), get_banner());*/
                DrawNode.DrawFunc_box execute = node.get_func_box();
                node.set_return_event(execute(node.get_position(), node.get_banner()));

                //Debug.Log("box");
            }
            else if(node.get_func_label() != null)
            {
                DrawNode.DrawFunc_label execute = node.get_func_label();
                execute(node.get_position(), node.get_banner());

                //Debug.Log("label");
            }
            else if(node.get_func_texture() != null)
            {
                DrawNode.DrawFunc_texture execute = node.get_func_texture();
                execute(node.get_position(), node.get_texture(), node.get_add_on_position(), 0, 0, 0, 0);

                //Debug.Log("texture");
            }
            else if(node.get_func_toggle() != null)
            {
                DrawNode.DrawFunc_toggle execute = node.get_func_toggle();
                node.set_return_event(execute(node.get_position(), node.get_return_event(), node.get_banner()));

                //Debug.Log("toggle");
            }
            node = node.get_link();
        }
        if(take_it)
        {
            take_it = false;
            Defined.screen_captured = capture();
        }
    }
}
