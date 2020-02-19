using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{
    public float speed;

    void Start()
    {
        speed = GameObject.Find("playerBird").GetComponent<PlayerBird>().speed;
    }

    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * speed;
    }
}
