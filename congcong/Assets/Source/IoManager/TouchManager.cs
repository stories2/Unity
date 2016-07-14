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
            if (Input.GetMouseButtonDown(i))
            {
                event_func(Input.mousePosition, i, TouchPhase.Began);
            }
            if (Input.GetMouseButtonUp(i))
            {
                event_func(Input.mousePosition, i, TouchPhase.Ended);
            }
        }
	}
}
