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
    void Start()
    {
        
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
        }
    }


    
}
