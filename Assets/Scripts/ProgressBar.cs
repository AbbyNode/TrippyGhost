using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public GameObject greenBar;

    private Sprite sprite;

    // progress is between 0.0f and 1.0f
    public void SetProgress(float progress)
    {
        float diff = greenBar.transform.localScale.x - progress;
        greenBar.transform.localScale = new Vector3(progress,
                                                    greenBar.transform.localScale.y,
                                                    greenBar.transform.localScale.z);
        greenBar.transform.position = new Vector3(greenBar.transform.position.x - diff,
                                                  greenBar.transform.position.y,
                                                  greenBar.transform.position.z);
    }

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
        Vector2 spriteSize = sprite.bounds.size;

        float height = 2f * Camera.main.orthographicSize;
        float width = height * Camera.main.aspect;
    }

    void Update()
    {

    }
}
