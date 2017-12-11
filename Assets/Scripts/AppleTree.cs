using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {

    [Header("Set in Inspector")]
    // prefab for instantiating apples
    public GameObject applePrefab;

    // Speed at which the AppleTree moves
    public float speed = 1f;

    // Distance where AppleTree truns around
    public float leftAndRightEdge = 10f;

    // Chance that AppleTree will change directions
    public float chanceToChangeDirections = 0.1f;

    // Rate at which Apples will be instantiated
    public float SecondsBetweenAppleDrops = 1f;

    void Start() {

        // Dropping apples every second
        Invoke("DropApple", 2f);    // calls a name function in a certain number of seconds.
    }

    void DropApple() {  // instantiate an apple at the AppleTree's location.

        GameObject apple = Instantiate<GameObject>(applePrefab);    // Creates an instance of applePrefab and assigns
                                                                    // it to the GameObject variable apple.

        apple.transform.position = transform.position;              // The position of this new apple GameObject
                                                                    // is set ot the position of the AppleTree.

        Invoke("DropApple", SecondsBetweenAppleDrops);              // This time Invoke will call the DropApple() function
                                                                    // in secondsBetweenAppleDrops.
    }

    void Update() {
        // Basic Movement
        Vector3 pos = transform.position;       // This line defines teh vEctor 3 position to be the current position of the apple tree
        pos.x += speed * Time.deltaTime;        // Makes the movement of the Apple Tree time based.
        transform.position = pos;               // Assigns this modified pos back to transform.position
        // Changin Direction
        if (pos.x < -leftAndRightEdge)
        {

            speed = Mathf.Abs(speed);   //  Move right
        }
        else if (pos.x > leftAndRightEdge)
        {

            speed = -Mathf.Abs(speed);  // Move left
        }
        else if (Random.value < chanceToChangeDirections) {

            speed *= -1; // change direction
        }

    }

    private void FixedUpdate() {

        // Changing Direction Randomlu is now time-based vecause of FixedUpdate()
        if (Random.value < chanceToChangeDirections) {
            speed *= -1;    // Change direction
        }
    }
}   // class
