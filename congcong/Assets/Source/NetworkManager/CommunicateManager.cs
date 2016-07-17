using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.NetworkInformation;
using System;

public class CommunicateManager : MonoBehaviour
{

    NetNode front = null, rear = null;

    void Update()
    {
        if(front != null)
        {
            NetNode node = front;
            while(node)
            {
                if(node.get_updated() == false)
                {

                    StartCoroutine(communicate(node));
                    node.set_updated(true);

                }
                node = node.get_next_link();
            }
        }
    }

    public NetNode wait_for_respone(NetNode target, long time_limit)// 1sec == 1000 millisec
    {
        long millisec, start_millisec = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        millisec = start_millisec;
        while(target.get_updated() == false)
        {
            millisec = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

            if(millisec - start_millisec > time_limit)
            {
                break;
            }
        }
        Debug.Log("communication time : " + (millisec - start_millisec) + " / " + time_limit);
        return target;
    }

    public NetNode add(string url)
    {
        NetNode node = gameObject.AddComponent<NetNode>();
        if(node)
        {
            node.set_url("http://lamb.kangnam.ac.kr/congcong/index.php?" + url);
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
        return node;
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

    public IEnumerator communicate(NetNode node)
    {
        long millisec, start_millisec = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        WWW www = new WWW(node.get_url());

        yield return www;
        Debug.Log(node.get_url() + " : " + www.text);

        node.set_result(www.text.ToString());
        millisec = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        Debug.Log("network time : " + (millisec - start_millisec));
    }

    public string get_mac()
    {
        string mac_address = "";
        NetworkInterface[] net_interface = NetworkInterface.GetAllNetworkInterfaces();
        mac_address = net_interface[0].GetPhysicalAddress().ToString();
        return mac_address;
    }
}
