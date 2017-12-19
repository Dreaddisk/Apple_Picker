using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour {

    [Header("Set Dynamically")]
    public Text scoreGT;                                             

    void Start() {

        // Find a reference to te ScoreCounter GameObject
        GameObject scoreGO = GameObject.Find("ScoreCounter");       // It searches through all the GameObjects in the scene for one
                                                                    // named "ScoreCounter"
        // Get the text Component of that GameObject
        scoreGT = scoreGO.GetComponent<Text>();                     // Searches for a Text component of the scoreGO GameObject, and this
                                                                    // is assigned to the public field scoreGT.
        // Set the starting number of points to 0
        scoreGT.text = "0";
    }
    void Update() {

        // Get the current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;

        // The Camera's z position sets how far to push the mouse into 3D 
        mousePos2D.z = -Camera.main.transform.position.z;

        // Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Move the x position of this Basket to the x position of the mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll) {             // any object that collides with this game object, 
                                                        // OnCollissionEnter will be called.

        // Find out what hit this basket
        GameObject collidedWith = coll.gameObject;      // This line assigns this colliding GameObject 
                                                        //to the local variable CollidedWith

        if (collidedWith.tag == "Apple") {              // Check to see whether colidedWith is an apple by looking for the 
                                                        // "Apple" tag that was assinged to all Apple GameObjects.

            Destroy(collidedWith);

            // Parse the text of the scoreGT into an int
            int score = int.Parse(scoreGT.text);            // Takes the text shoen in ScoreCounter and converts it to an integer.
            // Add points for catching the apple
            score += 100;
            // Convert the score back to a string and display it
            scoreGT.text = score.ToString();

            // Convert the score back to a string and display it
            scoreGT.text = score.ToString();
            // Track the high score
            if (score > HighScore.score) {

                HighScore.score = score;
            }
        }
    }
}
