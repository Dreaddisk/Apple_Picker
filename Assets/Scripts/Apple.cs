using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour {

    public static float bottomY = -20f;

    void Update() {

        if (transform.position.y < bottomY) {

            Destroy(this.gameObject);

            // Get a refernce to the ApplePicker component of Main Camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();     // grabs a reference to the main camera.
            // Call the public AppleDestroyed() method of apScript
            apScript.AppleDestroyed();                                          // c
        }
    }
}
