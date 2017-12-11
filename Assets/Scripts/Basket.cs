using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour {

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
        }
    }
}
