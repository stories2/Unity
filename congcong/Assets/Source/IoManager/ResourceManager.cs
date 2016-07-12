using UnityEngine;
using System.Collections;

public class ResourceManager : MonoBehaviour {

    GraphicNode front, rear;
	// Use this for initialization
	void Start () {

        Debug.Log("ResourceManager Start");
        init();
	}

    public void init()
    {
        rear = null;
        front = null;
    }

    public Texture2D del()
    {
        Texture2D data;
        if (is_empty())
            return null;
        GraphicNode node = front;
        front = node.get_link();
        data = node.get_texture();
        Destroy(node);
        return data;
    }

    public bool is_empty()
    {
        return front == null;
    }

    public void add(Texture2D data)
    {
        GraphicNode node = gameObject.AddComponent<GraphicNode>();
        if(node)
        {
            node.set_texture(data);
            if(front == null)
            {
                front = node;
            }
            else
            {
                rear.set_link(node);
            }
            rear = node;
        }
    }

    public void all_del()
    {
        while (del() != null) ;
    }
}
