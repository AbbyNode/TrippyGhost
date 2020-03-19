/* Purpose: Player controller
 * Author: Egor, Abby, Natalie, Ian, Micheal, Saradvalli, Nathan
 * Date: 2020, Mar
 * Version: 0.1
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBird : MonoBehaviour
{
    public float speed;
    public float upSpeed;
    public float gravity;

    private Sprite sprite;
    public GameObject playerTouch;

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
        else if (other.gameObject.tag == "Food")
        {
            ScoreScript.scoreNumber += 50;
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
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;
            StartCoroutine(showCircle(mouseX, mouseY));
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

    public IEnumerator showCircle(float mouseX, float mouseY)
    {
        playerTouch.transform.position = new Vector3(mouseX, mouseY, 0f);
        Image img = playerTouch.GetComponent<Image>();
        img.color = new Color(img.color.r, img.color.g, img.color.b, 0f);
        playerTouch.SetActive(true);
        for (float x = 0; x <= 1; x += 0.001f)
        {
            img.color = new Color(img.color.r, img.color.g, img.color.b, x);
        }
        yield return new WaitForSeconds(0.5f);
        for (float x = 1; x >= 0; x -= 0.001f)
        {
            img.color = new Color(img.color.r, img.color.g, img.color.b, x);
        }
        playerTouch.SetActive(false);
    }
}
