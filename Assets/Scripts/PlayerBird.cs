using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBird : MonoBehaviour
{
    public float speed;
    public float upSpeed;
    public float gravity;

    private Sprite sprite;

    public float nourishment = 1.0f;
    public NourishmentBar nourishmentBar;

    public void SetNourishment(float nourishmentPoints)
    {
        nourishment = Mathf.Clamp(nourishmentPoints, 0.0f, 1.0f);
        nourishmentBar.SetNourishment(nourishment);
    }

    public void AddNourishment(float nourishmentPoints)
    {
        SetNourishment(nourishment + nourishmentPoints);
    }

    public float GetNourishment()
    {
        return nourishment;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Tree")
        {
            SceneManager.LoadScene("LoseScene");
        }
        else if (other.gameObject.tag == "FinishLine")
        {
            SceneManager.LoadScene("WinScene");
        }
    }

    public void Start()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
        Vector2 spriteSize = sprite.rect.size;
        Vector3 screenSpawnPos = new Vector3(0 + spriteSize.x * 2, Screen.height * 0.7f, 10);
        Vector3 worldSpawnPos = Camera.main.ScreenToWorldPoint(screenSpawnPos);
        transform.position = worldSpawnPos;
        nourishmentBar = GameObject.Find("nourishmentBar").GetComponent<NourishmentBar>();
        nourishmentBar.SetNourishment(nourishment);
    }

    public void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * speed;
        if ((Input.touchCount > 0 || Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space)) && nourishment > 0.0f)
        {
            float cameraTop = Camera.main.transform.position.y + Camera.main.orthographicSize;
            if (transform.position.y < cameraTop - sprite.bounds.size.y)
            {
                transform.position += Vector3.up * Time.deltaTime * upSpeed;
            }
            nourishment -= 0.15f * Time.deltaTime;
            SetNourishment(nourishment);
        }
        else
        {
            transform.position += Vector3.down * Time.deltaTime * gravity;
        }
    }
}
