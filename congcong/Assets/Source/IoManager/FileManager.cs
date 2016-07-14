using UnityEngine;
using System.Collections;

public class FileManager : MonoBehaviour {

    ResourceManager resource_manager;
	// Use this for initialization
	void Start () {

        Debug.Log("File Manager Start");
	}

    public void init()
    {
        resource_manager = gameObject.AddComponent<ResourceManager>();
        resource_manager.init();
    }

    public bool load_resource()
    {
        if (resource_manager == null)
            return false;

        Texture2D data;
        int i;

        for (i = Defined.character_name_start_point; i <= Defined.character_name_end_point; i += 1)
        {
            data = (Texture2D)Resources.Load("" + i) as Texture2D;
            resource_manager.add(data);
        }
        return true;
    }

    public Texture2D get_resource(int id)
    {
        return resource_manager.get_resource(id);
    }

    public void release_resource()
    {
        resource_manager.all_del();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
