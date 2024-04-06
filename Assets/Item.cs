using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private const int INIT_CREATE_NUM = 10;
    private const int STRAT_X_MIN = -1920 / 2;
    private const int STRAT_X_MAX = 1920 / 2;
    private const int STRAT_Y_MIN = 0;
    private const int STRAT_Y_MAX = 1080 / 2;
    private UnityEngine.GameObject _object;


    List<UnityEngine.GameObject> _objects = new List<UnityEngine.GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < INIT_CREATE_NUM; i++)
        {
            UnityEngine.GameObject object_star = UnityEngine.Resources.Load<UnityEngine.GameObject>("star");
            UnityEngine.GameObject instance = Instantiate(object_star);
            float pos_x = UnityEngine.Random.Range(STRAT_X_MIN, STRAT_X_MAX);
            float pos_y = UnityEngine.Random.Range(STRAT_Y_MIN, STRAT_Y_MAX);
            UnityEngine.Vector2 pos = new Vector2(pos_x, pos_y);
            instance.transform.localPosition = pos;
            _objects.Add(instance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0;i < _objects.Count; i++)
        {
            _objects[i].transform.Rotate(0f, 0.5f, 0.1f);
        }
    }

    internal UnityEngine.Vector2 getPos(int idx) {
        UnityEngine.Vector2 pos = _objects[idx].transform.localPosition;
        return pos;
    }

    internal bool isHitPlayer(UnityEngine.Vector2 playerpos)
    {
        return true;
    }
}
