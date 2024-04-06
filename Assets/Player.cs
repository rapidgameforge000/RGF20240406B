using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public const float ACCEL_X = 5000.00f;
    public const float MAX_SPEED_X = 500f;
    public const float SCALE = 250;
    public const float RADIUS = SCALE * 0.176f;
    public const float BOUND_SPEED = 1000f;
    public const float GRAVITY = 1f;

    private GameObject _obj = null;
    private Vector3 _vec = Vector3.zero;

    public Vector3 Position { get => _obj.transform.localPosition; set => _obj.transform.localPosition = value; }

    // Start is called before the first frame update
    void Start()
    {
        GameObject prefab = Resources.Load<GameObject>("Player");
        _obj = GameObject.Instantiate<GameObject>(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        _obj.transform.localScale = Vector3.one * SCALE;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _vec.x -= ACCEL_X * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _vec.x += ACCEL_X * Time.deltaTime;
        }
        _vec.x = Mathf.Clamp(_vec.x, -MAX_SPEED_X, MAX_SPEED_X);
        _vec.y -= GRAVITY;

        Position += _vec * Time.deltaTime;

        //DebugópÇÃèàóù
        if (Position.y < -1080 * 0.5f + RADIUS)
        {
            Bound();
        }
    }

    public void Bound()
    {
        _vec.y = BOUND_SPEED;
    }
}
