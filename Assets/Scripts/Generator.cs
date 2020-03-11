using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Generator from the javascript code
public class Generator : MonoBehaviour
{
    public GameObject treePrefab;
    public GameObject applePrefab;
    public GameObject initialLemonPrefab;
    public GameObject lemonPrefab;
    public GameObject bananaPrefab;
    public GameObject finishLinePrefab;

    private float seed = 41;

    public int GetRndInteger(int min, int max)
    {
        seed = (seed * 9301.0f + 49297) % 233280.0f;
        float rnd = seed / 233280.0f;
        return (int)(min + rnd * (max - min) + 0.5f);
    }

    void Start()
    {
        float scale = 60.0f;
        float length = 3000;

        int x = 0;
        int y = 0;

        int i;

        Instantiate(initialLemonPrefab, new Vector3((200) / scale, 4.5f - y / scale, 10), Quaternion.identity);
        for (i = 100; i < length; i += x)
        {
            x = GetRndInteger(300, 1000);
            Instantiate(treePrefab, new Vector3(i / scale, -2.75f, 10), Quaternion.identity);
        }

        int j;
        for (j = 500; j < length; j += x)
        {
            x = GetRndInteger(100, 500);
            y = GetRndInteger(10, 310);
            if (GetRndInteger(1, 3) == 1)
            {
                Instantiate(applePrefab, new Vector3((j + x) / scale, 4.5f - y / scale, 10), Quaternion.identity);
            }
            else if (GetRndInteger(1, 3) == 2)
            {
                Instantiate(lemonPrefab, new Vector3((j + x) / scale, 4.5f - y / scale, 10), Quaternion.identity);
            }
            else if (GetRndInteger(1, 3) == 3)
            {
                Instantiate(bananaPrefab, new Vector3((j + x) / scale, 4.5f - y / scale, 10), Quaternion.identity);
            }
        }

        float finishX = Mathf.Max(i / scale, j / scale);
        Instantiate(finishLinePrefab, new Vector3(finishX, 0, 10), Quaternion.identity);
        //GameScene.maxX = Math.max(i, j);
        //GameScene.finishX = GameScene.maxX + 100;
        //new FinishLine(GameScene.stage, GameScene.finishX, 0);
    }

    void Update()
    {
        
    }
}
