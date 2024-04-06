using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector3 _vec = Vector3.zero;
    [SerializeField] private float _accelX = 10.00f;
    [SerializeField] private float _maxSpeedX = 1000.00f;

    private GameObject _obj = null;

    // Start is called before the first frame update
    void Start()
    {
        GameObject prefab = Resources.Load<GameObject>("Player");
        _obj = GameObject.Instantiate<GameObject>(prefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _vec.x -= _accelX * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _vec.x += _accelX * Time.deltaTime;
        }
        _vec.x = Mathf.Clamp(_vec.x, -_maxSpeedX, _maxSpeedX);
        _obj.transform.localPosition += _vec * Time.deltaTime;
    }
}
