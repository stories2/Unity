using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.NetworkInformation;
using System;

public class CommunicateManager : MonoBehaviour
{
    AndroidJavaObject mWiFiManager;
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
    string ReturnMacAddress()
    {
        string macAddr = "";
        if (mWiFiManager == null)
        {
            using (AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity"))
            {
                mWiFiManager = activity.Call<AndroidJavaObject>("getSystemService", "wifi");
            }
        }
        macAddr = mWiFiManager.Call<AndroidJavaObject>("getConnectionInfo").Call<string>("getMacAddress");
        return macAddr;
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

    public void all_del()
    {
        NetNode node;
        while(front)
        {
            node = front;
            front = front.get_next_link();
            Destroy(node);
        }
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
        if(Application.platform == RuntimePlatform.WindowsEditor)
        {
            NetworkInterface[] net_interface = NetworkInterface.GetAllNetworkInterfaces();
            mac_address = net_interface[0].GetPhysicalAddress().ToString();
        }
        else if(Application.platform == RuntimePlatform.Android)
        {
            mac_address = ReturnMacAddress();
            string temp = "";
            int i, length = mac_address.Length;
            for(i = 0;i < length; i += 1)
            {
                if(mac_address[i] != ':')
                    temp = temp + mac_address[i];
            }
            mac_address = temp;
        }
        return mac_address;
    }
}
