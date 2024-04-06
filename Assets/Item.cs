using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    private const int INIT_CREATE_NUM = 10;
    private const int CREATE_X_MIN = -1920 / 3;
    private const int CREATE_X_MAX = 1920 / 3;
    private const int CREATE_Y_MIN = -200;
    private const int CREATE_Y_MAX = 1080 / 6;

    struct Star {
        public GameObject obj;
        public int type;
        public bool alive;
        public double speed;
    };

    List<Star> _objects = new List<Star>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < INIT_CREATE_NUM; i++)
        {
            int type = UnityEngine.Random.Range(0, 3);
            UnityEngine.GameObject object_star;
            object_star = UnityEngine.Resources.Load<UnityEngine.GameObject>("StarYellow");
            float pos_x = UnityEngine.Random.Range(CREATE_X_MIN, CREATE_X_MAX);
            float pos_y = UnityEngine.Random.Range(CREATE_Y_MIN, CREATE_Y_MAX);
            switch (type)
            {
                case 0:
                    object_star = UnityEngine.Resources.Load<UnityEngine.GameObject>("StarYellow"); 
                    break;
                case 1:
                    object_star = UnityEngine.Resources.Load<UnityEngine.GameObject>("StarRed");
                    pos_y = 1920 / 2 +100;
                    break;
                case 2:
                    object_star = UnityEngine.Resources.Load<UnityEngine.GameObject>("StarGreen");                    break;
            }
            UnityEngine.GameObject instance = Instantiate(object_star);
            UnityEngine.Vector2 pos = new Vector2(pos_x, pos_y);
            instance.transform.localPosition = pos;
            Star star = new Star();
            star.type = type;
            star.obj = instance;
            star.alive = true;
            float speed = UnityEngine.Random.Range(1, 10);

            if (UnityEngine.Random.Range(0, 10) % 2 == 0)
            {
                star.speed = speed/10;
            }
            else
            {
                star.speed =-speed/10; 
            }
            _objects.Add(star);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0;i < _objects.Count; i++)
        {
            _objects[i].obj.transform.Rotate(0f, 300 * Time.deltaTime, 60f * Time.deltaTime);
            Move(i);
        }

    }

    internal UnityEngine.Vector2 getPos(int idx) {
        UnityEngine.Vector2 pos = _objects[idx].obj.transform.localPosition;
        return pos;
    }

    internal int getItemType(UnityEngine.Vector2 playerpos)
    {
        int type = -1;
        for (int i = 0; i < _objects.Count; i++)
        {
            UnityEngine.Vector2 pos = _objects[i].obj.transform.localPosition;
            UnityEngine.Vector2 dis = pos - playerpos;
            float sqr_dis = dis.sqrMagnitude;
            if(5000 < sqr_dis)
            {
                continue;
            }
            float pos_x = UnityEngine.Random.Range(CREATE_X_MIN, CREATE_X_MAX);
            float pos_y = UnityEngine.Random.Range(CREATE_Y_MIN, CREATE_Y_MAX);
            type = _objects[i].type;
            switch (_objects[i].type)
            {
              
                case 1:
                    pos_y = 1920 / 2 + 100;
                    break;
            }
            _objects[i].obj.transform.localPosition = new Vector2(pos_x, pos_y);
            break;
        }
        return type ;
    }
    private void Move(int idx)
    {
        switch(_objects[idx].type){
             case 0:
                prosessYellow(idx);
                break;
            case 1:
                prosessRed(idx);
                break;
            case 2:
                break;
            }
    }
    private void prosessRed(int idx)
    {
        UnityEngine.Vector2 pos = _objects[idx].obj.transform.localPosition;
        pos.x += (float)_objects[idx].speed;
        pos.y -= 1.5f;
        if (pos.x > 1920 / 2 + 100)
        {
            pos.x = -(1920 / 2 + 100);
        }

        if (pos.x < -(1920 / 2 + 100))
        {
            pos.x = 1920 / 2 + 100;
        }
        if (pos.y < -(1920 / 2 + 100))
        {
            pos.y = 1920 / 2 + 100;

        }
        _objects[idx].obj.transform.localPosition = pos;
    }

    private void prosessYellow(int idx)
    {
        UnityEngine.Vector2 pos = _objects[idx].obj.transform.localPosition;
        pos.x += (float)_objects[idx].speed;
        if(pos.x > 1920 / 2 + 100)
        {
            pos.x = -(1920 / 2 + 100);
        }

        if (pos.x < -(1920 / 2 + 100))
        {
            pos.x = 1920 / 2 + 100;
        }
        _objects[idx].obj.transform.localPosition = pos;
    }
}
