using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Facebook.Unity;
using System.Collections;
using System.Collections.Generic;
using System;


public class FacebookMenu : MonoBehaviour {

    public delegate void ChangeMenu(int menu_id);
    public delegate NetNode communicate(NetNode target, long time_limit);

    bool show = false, r_flag = true;
    DrawManager draw_manager;
    ConvertManager convert_manager;
    ItemNode draw_front = null, draw_rear = null;
    ChangeMenu change_menu;
    CommunicateManager communication_manager;
    communicate communicate_func;
    Texture2D userPicture;
    string lastName, firstName;

    public string AppLinkURL { get; set; }

    // Use this for initialization
    void Start()
    {

        r_flag = true;
        FB.Init(SetInit, OnHideUnity);
    }

    // Update is called once per frame
    void Update()
    {
        //i/o

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            change_menu(1);
            Destroy(this);
        }
        /*
        if (show)
        {
            if (r_flag == true)
            {
                r_flag = false;

                //Debug.Log("w : " + Screen.width + " h " + Screen.height);

                add(0.0F, 0.0F, 0.0F, new Rect(convert_manager.convert_to_bigger_position(new Vector2(0.2F, 0.4F)),
                    convert_manager.convert_to_bigger_position(new Vector2(0.6F, 0.2F))), new Rect(), false, null,
                    10, 0, "FB Login", null, GUI.Button, null, null);
            }
            ItemNode node = draw_front;
            DrawNode draw_node = null;
            int node_id;
            //process

            //i/o
            int node_num = 0;
            while (node)
            {
                node_num += 1;
                draw_node = draw_manager.get_draw_node(node.get_data());
                if (draw_node.get_return_event() == true)
                {
                    node_id = node.get_data();
                    Debug.Log("node #" + node_id + " event ok");
                    if (node_num == 1)
                    {
                        FBlogin();
                    }
                }
                node = node.get_link();
            }
        }*/
    }

    void OnGUI()
    {
        if(FB.IsLoggedIn)
        {
            if(r_flag)
            {
                FB.API("/me?fields=first_name", HttpMethod.GET, GetUserFirstName);
                FB.API("/me?fields=last_name", HttpMethod.GET, GetUserLastName);
                FB.API("/me/picture?type=square&height=128&width=128", HttpMethod.GET, GetUserPicture);
                FB.GetAppLink(GetAppLink);
                r_flag = false;
            }

            if(userPicture)
            {
                Graphics.DrawTexture(new Rect(convert_manager.convert_to_bigger_position(new Vector2(0.05F, 0.1F)),
                    convert_manager.convert_to_bigger_position(new Vector2(0.2F, 0.2F))), userPicture);
                GUI.Label(new Rect(convert_manager.convert_to_bigger_position(new Vector2(0.05F, 0.3F)),
                    convert_manager.convert_to_bigger_position(new Vector2(0.05F, 0.05F))), firstName);
                GUI.Label(new Rect(convert_manager.convert_to_bigger_position(new Vector2(0.1F, 0.3F)),
                    convert_manager.convert_to_bigger_position(new Vector2(0.1F, 0.05F))), lastName);

                bool shareButtonPressed = GUI.Button(new Rect(convert_manager.convert_to_bigger_position(new Vector2(0.1F, 0.35F)),
                    convert_manager.convert_to_bigger_position(new Vector2(0.8F, 0.1F))), "Share");

                bool inviteButtonPressed = GUI.Button(new Rect(convert_manager.convert_to_bigger_position(new Vector2(0.1F, 0.45F)),
                    convert_manager.convert_to_bigger_position(new Vector2(0.8F, 0.1F))), "Invite");

                bool shareUsersButtonPressed = GUI.Button(new Rect(convert_manager.convert_to_bigger_position(new Vector2(0.1F, 0.55F)),
                    convert_manager.convert_to_bigger_position(new Vector2(0.8F, 0.1F))), "ShareUser");

                if(shareButtonPressed)
                {
                    ShareToFaceBook();
                }

                if(inviteButtonPressed)
                {
                    InviteFriend();
                }

                if(shareUsersButtonPressed)
                {
                    ShareWithUsers();
                }
            }
        }
        else
        {
            if (GUI.Button(new Rect(convert_manager.convert_to_bigger_position(new Vector2(0.2F, 0.4F)),
                convert_manager.convert_to_bigger_position(new Vector2(0.6F, 0.2F))), "login"))
            {
                FBlogin();
            }
        }
    }

    public void GetAppLink(IAppLinkResult result)
    {
        if(!string.IsNullOrEmpty (result.Url))
        {
            AppLinkURL = "" + result.Url + "";
            Debug.Log(AppLinkURL);  
        }
        else
        {
            AppLinkURL = "http://google.com";
        }
    }

    public void ShareWithUsers()
    {
        FB.AppRequest(
            "ASDFASDF",
            null,
            new List<object>() { "app_users" },
            null,
            null,
            null,
            null,
            ShareWithUsersCallBack);
    }

    public void ShareWithUsersCallBack(IAppRequestResult result)
    {
        if (result.Cancelled)
        {
            Debug.Log("ShareUsers Cancel");
        }
        else if (!string.IsNullOrEmpty(result.Error))
        {
            Debug.Log(result.Error);
        }
        else if (!string.IsNullOrEmpty(result.RawResult))
        {
            Debug.Log("ok");
        }
    }

    public void ShareToFaceBook()
    {
        FB.FeedShare(
            string.Empty,
            new Uri(AppLinkURL),
            "콩콩",
            "우리 모두 뛰어봐요",
            "너는 이미 다운받고 있다",
            new Uri("http://lamb.kangnam.ac.kr/congcong/nyan.gif"),
            string.Empty,
            ShareCallBack
            );
    }

    public void ShareCallBack(IResult result)
    {
        if(result.Cancelled)
        {
            Debug.Log("Share Cancel");
        }
        else if(!string.IsNullOrEmpty(result.Error))
        {
            Debug.Log(result.Error);
        }
        else if(!string.IsNullOrEmpty(result.RawResult))
        {
            Debug.Log("ok");
        }
    }

    public void InviteFriend()
    {
        FB.Mobile.AppInvite(
            new Uri(AppLinkURL),
            new Uri("http://lamb.kangnam.ac.kr/congcong/nyan.gif"),
            InviteCallBack);
    }

    public void InviteCallBack(IResult result)
    {
        if (result.Cancelled)
        {
            Debug.Log("Invite Cancel");
        }
        else if (!string.IsNullOrEmpty(result.Error))
        {
            Debug.Log(result.Error);
        }
        else if (!string.IsNullOrEmpty(result.RawResult))
        {
            Debug.Log("ok");
        }
    }

    public void GetUserPicture(IGraphResult result)
    {
        if(result.Texture)
        {
            userPicture = result.Texture;
        }
        else
        {
            Debug.Log(result.Texture);
        }
    }

    public void GetUserLastName(IResult result)
    {
        if (result.Error == null)
        {
            lastName = result.ResultDictionary["last_name"].ToString();
            Debug.Log(lastName);
        }
        else
        {
            Debug.Log(result.Error);
        }
    }

    public void GetUserFirstName(IResult result)
    {
        if(result.Error == null)
        {
            firstName = result.ResultDictionary["first_name"].ToString();
            Debug.Log(firstName);
        }
        else
        {
            Debug.Log(result.Error);
        }
    }

    public void FBlogin()
    {
        List<string> permissions = new List<string>();
        permissions.Add("public_profile");

        FB.LogInWithReadPermissions(permissions, AuthCallBack);
    }

    public void AuthCallBack(IResult result)
    {
        if (result.Error != null)
        {
            Debug.Log(result.Error);
        }
        else
        {
            CheckLogin();
        }
    }

    public void SetInit()
    {
        Debug.Log("FB init ok");

        CheckLogin();
    }

    public void CheckLogin()
    {
        if (FB.IsLoggedIn)
        {
            Debug.Log("FB logged in");
        }
        else
        {
            Debug.Log("FB not logged in");
        }
    }

    public void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    public void set_communication_func(communicate communicate_target)
    {
        this.communicate_func = communicate_target;
    }

    public void set_communication_manager(CommunicateManager communication_manager)
    {
        this.communication_manager = communication_manager;
    }

    public void all_del()
    {
        int node_id;
        while ((node_id = del()) != 0)
        {
            draw_manager.search_del(node_id);
        }
    }

    public void set_change_menu(ChangeMenu change_menu)
    {
        this.change_menu = change_menu;
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
