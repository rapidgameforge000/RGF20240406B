using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private const int STRAT_X_MIN = -1920 / 2;
    private const int STRAT_X_MAX = 1920 / 2;
    private const int STRAT_Y_MIN = 0;
    private const int STRAT_Y_MAX = 1080 / 2;
    private UnityEngine.GameObject _object;
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.GameObject object_star = UnityEngine.Resources.Load<UnityEngine.GameObject>("star");
        UnityEngine.GameObject instance = Instantiate(object_star);
        _object = instance;
        float pos_x = UnityEngine.Random.Range(STRAT_X_MIN, STRAT_X_MAX);
        float pos_y = UnityEngine.Random.Range(STRAT_Y_MIN, STRAT_Y_MAX);
        UnityEngine.Vector2 pos = new Vector2(pos_x, pos_y);
        _object.transform.localPosition = pos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
