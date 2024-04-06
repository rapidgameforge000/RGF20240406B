using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    private UnityEngine.GameObject _object;
    // Start is called before the first frame update
    void Start()
    {

        UnityEngine.GameObject prefab = UnityEngine.Resources.Load<UnityEngine.GameObject>("Assets/Resources/Block.prefab");
        UnityEngine.GameObject instance = UnityEngine.Object.Instantiate(prefab, new Vector3(0,0,0), Quaternion.identity);
        _object = instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
