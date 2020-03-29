/* Purpose: Shows main menu
 * Author: Egor, Abby, Natalie, Ian, Micheal, Saradvalli, Nathan
 * Date: 2020, Mar
 * Version: 0.1
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuScene");
        ScoreScript.scoreNumber = 0;
    }
}
