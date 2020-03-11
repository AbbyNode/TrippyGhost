/* Purpose: Camera follows bird 
 * Author: Egor, Abby, Natalie, Ian, Micheal, Saradvalli, Nathan
 * Date: 2020, Mar
 * Version: 0.1
 */
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
