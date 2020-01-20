using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBird : MonoBehaviour
{
    public float speed;
    public float upSpeed;
    public float gravity;

    void Start()
    {
        Vector2 spriteSize = GetComponent<SpriteRenderer>().sprite.rect.size;
        Vector3 screenSpawnPos = new Vector3(0 + spriteSize.x * 2, Screen.height * 0.7f, 10);
        Vector3 worldSpawnPos = Camera.main.ScreenToWorldPoint(screenSpawnPos);
        transform.position = worldSpawnPos;
    }

    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * speed;
        transform.position += Vector3.down * Time.deltaTime * gravity;
        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            transform.position += Vector3.up * Time.deltaTime * upSpeed;
        }
    }
}
