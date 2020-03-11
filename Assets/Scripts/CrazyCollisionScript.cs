/* Purpose: Hypes up the bird
 * Author: Egor, Abby, Natalie, Ian, Micheal, Saradvalli, Nathan
 * Date: 2020, Feb
 * Version: 0.1
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyCollisionScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera camera;
    public Color red = Color.red;
    public float speed;
    public AudioSource DoomSlayerMusic;
    public float rapidNourishment = 1.0f;

    void Start()
    {
        //gameObject.GetComponent<PlayerBird>().nourishment = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "DoomSlayer")
        {
            camera.backgroundColor = red;
            gameObject.GetComponent<PlayerBird>().speed = 10;
            gameObject.GetComponent<PlayerBird>().upSpeed = 5;
            gameObject.GetComponent<PlayerBird>().gravity = 2.5f;
            camera.GetComponent<MovingCamera>().speed = 10;
            DoomSlayerMusic.GetComponent<AudioSource>().Play();
            GameObject.Find("DoomStateController").GetComponent<DoomStateController>().IsDoom = true;

            if ((Input.touchCount > 0 || Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space)) && rapidNourishment > 0.0f)
            {
                rapidNourishment -= 0.7f * Time.deltaTime;
                gameObject.GetComponent<PlayerBird>().SetNourishment(rapidNourishment);
            }
        }
    }
}


    
