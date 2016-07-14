using UnityEngine;
using System.Collections;

public class ConvertManager : MonoBehaviour {

    float screen_height, screen_width;

	// Use this for initialization
	void Start () {
	
	}

    public void init()
    {
        screen_height = Screen.height;
        screen_width = Screen.width;
    }

    public Vector2 reversal_small_y(Vector2 position)
    {
        position.y = 1.0F - position.y;
        return position;
    }

    public Vector2 reversal_big_y(Vector2 position)
    {
        position.y = screen_height - position.y;
        return position;
    }

    public float get_speed(int frame)// 0<= frame <= jump_frame_max
    {
        if (frame < 0 || frame > Defined.jump_frame_max)
            return 0.001F;
        return (-0.0005F / 576) * frame * frame + 0.0005F;
    }

    public Vector2 get_texture_mid_point(Texture2D target, float scale, float target_part_size)
    {
        return new Vector2((target.width / target_part_size) * scale, (target.height / target_part_size) * scale);
    }

    public float get_scale(Texture2D target, Vector2 size, float target_part_size)
    {
        return (float)convert_to_bigger_position(size).x / target_part_size; 
    }

    public Vector2 convert_to_smaller_position(Vector2 position)// 매개변수의 값이 변환되는데 그 값이 0~1범위로 출력, 절대 좌표 -> 상대 좌표
    {
        Vector2 convert_vector = new Vector2();
        convert_vector.x = (float)position.x / screen_width;
        convert_vector.y = (float)position.y / screen_height;

        return convert_vector;
    }

    public Vector2 convert_to_bigger_position(Vector2 position)// 매개변수의 값은 0~1 까지의 숫자로 이루어짐, 상대 좌표 -> 절대 좌표
    {
        Vector2 convert_vector = new Vector2();
        convert_vector.x = position.x * screen_width;
        convert_vector.y = position.y * screen_height;
        return convert_vector;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
