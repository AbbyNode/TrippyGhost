using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scoreNumber = 0;
    public GameObject scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<Text>().text = "" + scoreNumber;
        DontDestroyOnLoad(scoreText);
    }
}
