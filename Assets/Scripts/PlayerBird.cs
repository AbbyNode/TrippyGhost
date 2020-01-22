using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBird : MonoBehaviour
{
    public float speed;
    public float upSpeed;
    public float gravity;

    private Sprite sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
        Vector2 spriteSize = sprite.rect.size;
        Vector3 screenSpawnPos = new Vector3(0 + spriteSize.x * 2, Screen.height * 0.7f, 10);
        Vector3 worldSpawnPos = Camera.main.ScreenToWorldPoint(screenSpawnPos);
        transform.position = worldSpawnPos;
    }

    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * speed;
        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            float cameraTop = Camera.main.transform.position.y + Camera.main.orthographicSize;
            if (transform.position.y < cameraTop - sprite.bounds.size.y)
            {
                transform.position += Vector3.up * Time.deltaTime * upSpeed;
            }
        }
        else
        {
            transform.position += Vector3.down * Time.deltaTime * gravity;
        }
    }
}
