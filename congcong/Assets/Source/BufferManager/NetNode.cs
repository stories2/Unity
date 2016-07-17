using UnityEngine;
using System.Collections;

public class NetNode : MonoBehaviour {

    string url = "", result = "";
    NetNode next_link;
    bool updated = false;

    public bool get_updated()
    {
        return updated;
    }

    public void set_updated(bool updated)
    {
        this.updated = updated;
    }

    public string get_result()
    {
        return result;
    }

    public void set_result(string result)
    {
        this.result = result;
    }

    public string get_url()
    {
        return url;
    }

    public void set_url(string url)
    {
        this.url = url;
    }

    public NetNode get_next_link()
    {
        return next_link;
    }

    public void set_next_link(NetNode next_link)
    {
        this.next_link = next_link;
    }
}
