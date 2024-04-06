using UnityEngine;

public class Cloud : MonoBehaviour
{
    private const float FIELD_RANGE = 1920.0f / 2 + 100;
    private const float SPEED_X = 500.0f;
    private const float CYCLE_Y = 6.0f;
    private const float DISTANCE_Y = 30.0f;

    private float x = -FIELD_RANGE;
    private float y = 0.0f;
     void Start()
    {
        
    }

    void Update()
    {
        x += SPEED_X * Time.deltaTime;

        if (FIELD_RANGE < x) {
            x = -FIELD_RANGE;
            y = Random.Range(200, 400);
        }
        this.transform.localPosition = new Vector3(x, y + Mathf.Sin(Time.time * CYCLE_Y) * DISTANCE_Y, this.transform.localPosition.z);
    }
}
