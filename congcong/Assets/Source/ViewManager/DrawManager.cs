using UnityEngine;
using System.Collections;

public class DrawManager : MonoBehaviour {

    DrawNode rear = null, front = null;
	// Use this for initialization
	void Start () {

        init();
	}

    public DrawNode get_front()
    {
        return front;
    }

    public DrawNode get_rear()
    {
        return rear;
    }

    public void init()
    {/*
        rear = null;
        front = null;*/
    }

    public bool del()
    {
        if (is_empty())
            return false;
        DrawNode node = front;
        front = node.get_link();
        Destroy(node);
        return true;
    }

    public bool is_empty()
    {
        return front == null;
    }

    public void add(float return_val, float min, float max, Rect pos, Rect add_on_pos, bool return_event, Texture2D texture,
        int deep, int id, string banner, DrawNode.DrawFunc_label func_label, DrawNode.DrawFunc_box func_box, DrawNode.DrawFunc_texture func_texture,
        DrawNode.DrawFunc_toggle func_toggle)
    {
        DrawNode node = gameObject.AddComponent<DrawNode>();
        if(node)
        {
            //Debug.Log("new node");
            node.init();
            node.set_return_val(return_val);
            node.set_min(min);
            node.set_max(max);
            node.set_position(pos);
            node.set_add_on_position(add_on_pos);
            node.set_return_event(return_event);
            node.set_texture(texture);
            node.set_deep(deep);
            node.set_node_id(id);
            node.set_banner(banner);
            node.set_func(func_label);
            node.set_func(func_box);
            node.set_func(func_texture);
            node.set_func(func_toggle);

            if(front == null)
            {
                //Debug.Log("set start");
                front = node;
                rear = node;
            }
            else
            {
                //Debug.Log("search");
                search(node);
            }
        }
    }

    public void search(DrawNode node)
    {
        DrawNode before_node = null, after_node = front;
        bool linked = false;
        while(after_node)
        {
            if(node.get_deep() >= after_node.get_deep())
            {
                if(before_node)// 나보다 우선순위가 있는 노드 중간에 껴지게 될때
                {
                    if (after_node.get_link() != null)
                    {
                        before_node.set_link(node);
                        node.set_link(after_node);

                        linked = true;
                    }
                    else
                    {
                        rear = node;
                        linked = true;
                    }
                }
                else// 내가 가장 우선순위가 높아서 앞에 노드가 없을 때
                {
                    front = node;
                    linked = true;
                    if(after_node.get_link() != null)
                    {
                        node.set_link(after_node);
                    }
                    else
                    {
                        rear = node;
                    }
                }
            }
            after_node = after_node.get_link();
            if(before_node)
            {
                before_node = before_node.get_link();
            }
            else
            {
                before_node = front;
            }
        }
        if(linked == false)
        {
            rear.set_link(node);
            rear = node;
        }
    }
}
