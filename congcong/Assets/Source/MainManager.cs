using UnityEngine;
using System.Collections;

public class MainManager : MonoBehaviour {

    FileManager file_manager;
    ViewManager view_manager;
    bool r_flag;
	// Use this for initialization
	void Start () {

        init();
	}

    public void init()
    {
        this.file_manager = gameObject.AddComponent<FileManager>();
        this.view_manager = gameObject.AddComponent<ViewManager>();

        //view_manager.get_draw_manager().add()
        r_flag = true;
    }
	
	// Update is called once per frame
	void Update () {
	
        if(r_flag)
        {
            r_flag = false;

            file_manager.init();
            /*if(file_manager.load_resource())
            {
                Debug.Log("Load Ok");
            }
            else
            {
                Debug.Log("Load Error");
            }*/


            view_manager.get_draw_manager().add(0.0F, 0.0F, 0.0F, new Rect(100, 0, 100, 50), new Rect(0, 0, 0, 0), false, null, 2, 0, "hello world",
                null, null, null, GUI.Toggle);
            view_manager.get_draw_manager().add(0.0F, 0.0F, 0.0F, new Rect(0, 0, 100, 50), new Rect(0, 0, 0, 0), false, null, 1, 0, "hello world",
                null, GUI.Button, null, null);
        }


	}

    void OnDestroy()
    {
        file_manager.release_resource();
    }
}
