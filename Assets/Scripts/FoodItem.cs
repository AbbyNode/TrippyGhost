﻿/* Purpose: Collectable items
 * Author: Egor, Abby, Natalie, Ian, Micheal, Saradvalli, Nathan
 * Date: 2020, Mar
 * Version: 0.1
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    // nourishment is between 0.0f and 1.0f
    public float nourishmentPoints;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerBird>().AddNourishment(nourishmentPoints);
            Destroy(gameObject);
        }
    }

    void Start()
    {
    }

    void Update()
    {
    }
}
