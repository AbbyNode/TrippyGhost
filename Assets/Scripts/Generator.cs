using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Generator from the javascript code
public class Generator : MonoBehaviour
{
    public GameObject treePrefab;
    public GameObject applePrefab;
    public GameObject lemonPrefab;
    public GameObject bananaPrefab;

    private float seed = 41;

    private int GetRndInteger(int min, int max)
    {
        seed = (seed * 9301.0f + 49297) % 233280.0f;
        float rnd = seed / 233280.0f;
        return (int)(min + rnd * (max - min) + 0.5f);
    }

    void Start()
    {
        float scale = 60.0f;

        int x = 0;
        int y = 0;

        for (int i = 100; i < 10000; i += x)
        {
            x = GetRndInteger(300, 1000);
            Instantiate(treePrefab, new Vector3(i / scale, -2.75f, 10), Quaternion.identity);
        }

        for (int j = 500; j < 10000; j += x)
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
    }

    void Update()
    {
        
    }
}
