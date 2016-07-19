using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;

public class FacebookMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {

        FB.Init(SetInit, OnHideUnity);
	}

    public void FBlogin()
    {
        List<string> permissions = new List<string>();
        //permissions.Add("public_profile");
        permissions.Add("public_profile");
        permissions.Add("email");
        permissions.Add("user_friends");

        FB.LogInWithReadPermissions(permissions, AuthCallBack);
    }

    public void AuthCallBack(IResult result)
    {
        if(result.Error != null)
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
        if(!isGameShown)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if(GUI.Button(new Rect(0, 0, 100, 20), "login"))
        {
            FBlogin();
        }
    }
}
