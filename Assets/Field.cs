using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Field : MonoBehaviour
{
    private UnityEngine.GameObject _object;

    private const int BLOCKNUM = 30;
    private const int STARTNUM = 12;
    UnityEngine.GameObject BlockPrefab;
    private UnityEngine.GameObject[] BlockArray;

    private const int BlockSize = 60;
    private const int BlockSetUpY = -500;
    private const int BlockHeightRange = 200;
    private const int BlockSetUpStartX = -900;
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

        int StartIdx = (BLOCKNUM - STARTNUM) / 2;
        int EndIdx = StartIdx + STARTNUM;
        for (int i = 0; i < BLOCKNUM; i++)
        {
            UnityEngine.GameObject instance = UnityEngine.Object.Instantiate(BlockPrefab, new Vector3(BlockSetUpStartX + BlockSetUpDiffX * i, BlockSetUpY + (BlockHeightRange / 2), 0), Quaternion.identity);
            BlockArray[i] = instance;
            if (i < StartIdx || i >= EndIdx)
            {
                BlockArray[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool IsHitBlock(Vector3 InLocation)
    {
        for (int i = 0; i < BLOCKNUM; i++)
        {
            if (!BlockArray[i].activeSelf) { continue; }

            Vector3 FromBlock = InLocation - BlockArray[i].transform.position;
            const double BlockSizeHalf = BlockSize * 0.5f;
            if (Math.Abs(FromBlock.x) < BlockSizeHalf && FromBlock.y < BlockSize)
            {
                // 当たった時の処理
                BlockArray[i].SetActive(false);

                int RandIdx = UnityEngine.Random.Range(0, BLOCKNUM);
                for (int j = 0; j < BLOCKNUM; j++)
                {
                    int TargetIdx = (j + RandIdx) % BLOCKNUM;
                    if (TargetIdx == i)
                    {
                        continue;
                    }

                    if (!BlockArray[TargetIdx].activeSelf)
                    {
                        BlockArray[TargetIdx].SetActive(true);
                        float NewBlockHeight = UnityEngine.Random.Range(BlockSetUpY, BlockSetUpY + BlockHeightRange);
                        BlockArray[TargetIdx].transform.SetPositionAndRotation(new Vector3(BlockArray[TargetIdx].transform.position.x, NewBlockHeight, 0), Quaternion.identity);
                        break;
                    }
                }

                return true;
            }
        }

        return false;
    }

   // Vector3 GetBlockLocation(int BlockIndex)
   // {
   //     return new Vector3(BlockSetUpStartX + BlockSetUpDiffX * BlockIndex, );
   // }
}
