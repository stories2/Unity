using UnityEngine;
using System.Collections;

public class TouchManager : MonoBehaviour {

    public delegate void touch_event(Vector2 pos, int finger_id, TouchPhase action);

    touch_event event_func;

	// Use this for initialization
	void Start () {
	
	}

    public void init(touch_event event_func)
    {
        this.event_func += event_func;
    }
	
	// Update is called once per frame
	void Update () {

        int i;
        for (i = 0; i < 2;i+=1)
        {
            if(Application.platform == RuntimePlatform.WindowsPlayer)
            {
                if (Input.GetMouseButtonDown(i))
                {
                    event_func(Input.mousePosition, i, TouchPhase.Began);
                }
                if (Input.GetMouseButtonUp(i))
                {
                    event_func(Input.mousePosition, i, TouchPhase.Ended);
                }
            }
            else if(Application.platform == RuntimePlatform.Android)
            {
                if(Input.touchCount > 0)
                {
                    if(Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        event_func(Input.GetTouch(0).position, i, TouchPhase.Began);
                    }
                    if(Input.GetTouch(0).phase == TouchPhase.Ended)
                    {
                        event_func(Input.GetTouch(0).position, i, TouchPhase.Ended);
                    }
                }
            }
        }
	}
}
