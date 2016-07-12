using UnityEngine;
using System.Collections;

public class MainManager : MonoBehaviour {

    FileManager file_manager;
    bool r_flag;
	// Use this for initialization
	void Start () {

        init();
	}

    public void init()
    {
        this.file_manager = gameObject.AddComponent<FileManager>();

        r_flag = true;
    }
	
	// Update is called once per frame
	void Update () {
	
        if(r_flag)
        {
            r_flag = false;

            file_manager.init();
            if(file_manager.load_resource())
            {
                Debug.Log("Load Ok");
            }
            else
            {
                Debug.Log("Load Error");
            }
        }
	}

    void OnDestroy()
    {
        file_manager.release_resource();
    }
}
