using UnityEngine;

public class Player : MonoBehaviour
{
    public const float ACCEL_X = 5000.00f;
    public const float MAX_SPEED_X = 500f;
    public const float SCALE = 250;
    public const float RADIUS = SCALE * 0.176f;
    public const float BOUND_SPEED = 1300f;
    public const float GRAVITY = 1300f;

    private const int TRAIL_INTERVAL = 20;
    private const int TRAIL_NUM = 10;
    private const int HISTORY_NUM = TRAIL_INTERVAL * TRAIL_NUM;

    private const float COLOR_R = 0.1f;
    private const float COLOR_G = 1.0f;
    private const float COLOR_B = 1.0f;

    private struct TrailObjData
    {
        public GameObject GObj;
        public SpriteRenderer Renderer;
    }

    private GameObject _obj = null;
    private Vector3 _vec = Vector3.zero;
    private TrailObjData[] _trailobjlist = new TrailObjData[TRAIL_NUM];
    private Vector3[] _history = new Vector3[HISTORY_NUM];

    public Vector3 Position { get => _obj.transform.localPosition; private set => _obj.transform.localPosition = value; }

    // Start is called before the first frame update
    void Start()
    {
        GameObject prefab = Resources.Load<GameObject>("Player");

        Vector3 pos = Vector3.zero;
        Quaternion rot = Quaternion.identity;

        for (int i = 0; i < _trailobjlist.Length; i++)
        {
            int idx = _trailobjlist.Length - i - 1;//¶¬‡
            _trailobjlist[idx].GObj = GameObject.Instantiate<GameObject>(prefab, pos, rot);
            _trailobjlist[idx].Renderer = _trailobjlist[idx].GObj.GetComponent<SpriteRenderer>();
            _trailobjlist[idx].Renderer.color = new Color(COLOR_R, COLOR_G, COLOR_B, Mathf.Lerp(0.5f, 0.0f, (float)idx / (TRAIL_NUM + 1)));
        }
        for (int i = 0; i < _history.Length; i++)
        {
            _history[i] = pos;
        }

        _obj = GameObject.Instantiate<GameObject>(prefab, pos, rot);
        _obj.transform.localScale = Vector3.one * SCALE;

        var renderer = _obj.GetComponent<SpriteRenderer>();
        renderer.color = new Color(COLOR_R, COLOR_G, COLOR_B, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateVec();
        UpdatePos();
        UpdateTrail();
    }

    private void UpdateVec()
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
        _vec.y -= GRAVITY * Time.deltaTime;
    }

    private void UpdatePos()
    {
        Position += _vec * Time.deltaTime;
    }

    private void UpdateTrail()
    {
        for (int i = 0; i < _history.Length - 1; i++)
        {
            _history[_history.Length - i - 1] = _history[_history.Length - i - 2];
        }
        _history[0] = Position;

        for (int i = 0; i < _trailobjlist.Length; i++)
        {
            _trailobjlist[i].GObj.transform.localPosition = _history[i * TRAIL_INTERVAL];
        }
    }

    public void BoundX()
    {
        _vec.x *= -1;
    }

    public void BoundY()
    {
        _vec.y = BOUND_SPEED;
    }

    public bool IsDead()
    {
        return Position.y < -1080 * 0.5f - RADIUS;
    }
}
