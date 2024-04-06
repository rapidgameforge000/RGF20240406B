using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private UnityEngine.GameObject _object;
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.GameObject object_star = UnityEngine.Resources.Load<UnityEngine.GameObject>("star");
        UnityEngine.GameObject instance = Instantiate(object_star);
        _object = instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
