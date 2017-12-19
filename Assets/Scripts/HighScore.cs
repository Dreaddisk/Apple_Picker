using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScore : MonoBehaviour {

    static public int score = 1000;
    void Awake() {
        // If the PlayerPrefs HighScore already exists, read it
        if (PlayerPrefs.HasKey("HighScpre"))
        {                                                           // PlayerPrefs is a dictionary of values that
                                                                    // are referenced through keys.

            score = PlayerPrefs.GetInt("HighScore");
        }

        // Assign the high score to HighScore
        PlayerPrefs.SetInt("HighScore", score);                     // If a highscore int already exist, this will rewrite the value 
                                                                    // back to PlayerPrefs

    }
    void Update() {

        Text gt = this.GetComponent<Text>();        
        gt.text = "High Score: " + score;
        // Update the PlayerPrefs Highscore if necessary
        if (score > PlayerPrefs.GetInt("HighScore")) {              // With the added lines, Update() now checks every fram to see
                                                                    // whether the current HighScore.score is higher than the one stored 
                                                                    // in PlayerPrefs.
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

  
}
