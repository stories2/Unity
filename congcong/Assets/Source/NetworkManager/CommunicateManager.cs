using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.NetworkInformation;

public class CommunicateManager : MonoBehaviour
{

    NetNode front = null, rear = null;

    public void add(string url)
    {
        NetNode node = gameObject.AddComponent<NetNode>();
        if(node)
        {
            node.set_url(url);
            if(front)
            {
                rear.set_next_link(node);
            }
            else
            {
                front = node;
            }
            rear = node;
        }
    }

    public bool del()
    {
        if (is_empty())
            return false;
        NetNode node = front;
        front = node.get_next_link();
        Destroy(node);
        return true;
    }

    public bool is_empty()
    {
        return front == null;
    }

    public string communicate(string url)
    {
        WWW www = new WWW(url);

        Debug.Log(url + " : " + www.text);

        return www.text.ToString();
    }

    public string get_mac()
    {
        string mac_address = "";
        NetworkInterface[] net_interface = NetworkInterface.GetAllNetworkInterfaces();
        mac_address = net_interface[0].GetPhysicalAddress().ToString();
        return mac_address;
    }
}
