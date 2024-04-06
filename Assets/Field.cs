using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Field : MonoBehaviour
{
    private UnityEngine.GameObject _object;

    private const int BLOCKNUM = 20;
    UnityEngine.GameObject BlockPrefab;
    private UnityEngine.GameObject[] BlockArray;
    // Start is called before the first frame update
    void Start()
    {

        // リソース読み込み
        BlockPrefab = UnityEngine.Resources.Load<UnityEngine.GameObject>("Block");

        // UnityEngine.GameObject instance = UnityEngine.Object.Instantiate(BlockPrefab, new Vector3(500,-500,0), Quaternion.identity);
        //_object = instance;

        // 配列準備
        BlockArray = new UnityEngine.GameObject[BLOCKNUM];

        int BlockSetUpY = -500;
        int BlockSetUpStartX = -500;
        int BlockSizeX = 60;
        for (int i = 0; i < BLOCKNUM; i++)
        {
            UnityEngine.GameObject instance = UnityEngine.Object.Instantiate(BlockPrefab, new Vector3(BlockSetUpStartX + BlockSizeX * i, BlockSetUpY, 0), Quaternion.identity);
            BlockArray[i] = instance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
