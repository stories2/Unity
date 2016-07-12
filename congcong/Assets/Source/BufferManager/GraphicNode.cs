using UnityEngine;
using System.Collections;

public class GraphicNode : MonoBehaviour {

    Texture2D data;
    GraphicNode next_link;
	// Use this for initialization
	void Start () {

        data = null;
        next_link = null;
	}

    public void set_link(GraphicNode next_link)
    {
        this.next_link = next_link;
    }

    public GraphicNode get_link()
    {
        return next_link;
    }

    public void set_texture(Texture2D data)
    {
        this.data = data;
    }

    public Texture2D get_texture()
    {
        return data;
    }
}
