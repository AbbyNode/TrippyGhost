using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoomSpriteSwitcher : MonoBehaviour
{
    public Sprite normalSprite;
    public Sprite doomSprite;
    private bool prevDoom;

    void Start()
    {
        prevDoom = GameObject.Find("DoomStateController").GetComponent<DoomStateController>().IsDoom;
    }

    void Update()
    {
        bool doom = GameObject.Find("DoomStateController").GetComponent<DoomStateController>().IsDoom;
        if (doom != prevDoom)
        {
            if (doom)
            {
                GetComponent<SpriteRenderer>().sprite = doomSprite;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = normalSprite;
            }
            doom = prevDoom;
        }
    }
}
