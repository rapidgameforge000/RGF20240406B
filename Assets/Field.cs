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

    private const int BlockSize = 60;
    private const int BlockSetUpY = -500;
    private const int BlockSetUpStartX = -500;
    private const int BlockSetUpDiffX = BlockSize;

    // Start is called before the first frame update
    void Start()
    {

        // リソース読み込み
        BlockPrefab = UnityEngine.Resources.Load<UnityEngine.GameObject>("Block");

        // UnityEngine.GameObject instance = UnityEngine.Object.Instantiate(BlockPrefab, new Vector3(500,-500,0), Quaternion.identity);
        //_object = instance;

        // 配列準備
        BlockArray = new UnityEngine.GameObject[BLOCKNUM];

        for (int i = 0; i < BLOCKNUM; i++)
        {
            UnityEngine.GameObject instance = UnityEngine.Object.Instantiate(BlockPrefab, new Vector3(BlockSetUpStartX + BlockSetUpDiffX * i, BlockSetUpY, 0), Quaternion.identity);
            BlockArray[i] = instance;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool IsHitBlock(Vector3 InLocation)
    {
        // いったん跳ね返す
        if (InLocation.y < BlockSetUpY + (BlockSize * 0.5))
        {
            return true;
        }

        //for (int i = 0; i < BLOCKNUM; i++)
        //{
        //    Vector3 FromBlock = InLocation - BlockArray[i].transform.position;
        //    if (Math.Abs  FromBlock.x < )
        //}

        return false;
    }

   // Vector3 GetBlockLocation(int BlockIndex)
   // {
   //     return new Vector3(BlockSetUpStartX + BlockSetUpDiffX * BlockIndex, );
   // }
}
