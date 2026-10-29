using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaInteraction : MonoBehaviour
{
     private float initialDistance;
    private Vector3 initialScale;

    private float rotationSpeed = 0.2f;

    void Update()
    {
        // 🔄 One-finger rotation
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float rotY = touch.deltaPosition.x * rotationSpeed;
                transform.Rotate(0, -rotY, 0); // old Y-axis rotation

            }
        }

        // 🔍 Two-finger zoom (pinch)
        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            // get current & previous distance between fingers
            float currentDistance = Vector2.Distance(touch0.position, touch1.position);
            float previousDistance = Vector2.Distance(touch0.position - touch0.deltaPosition,
                                                      touch1.position - touch1.deltaPosition);

            float difference = currentDistance - previousDistance;

            // zoom based on difference
            float scaleFactor = difference * 0.05f;
            transform.localScale += Vector3.one * scaleFactor;

            // Clamp scale to avoid tiny or huge burgers
            float minScale =0.0035f;
            float maxScale =0.0075f;
            float clampedX = Mathf.Clamp(transform.localScale.x, minScale, maxScale);
            transform.localScale = new Vector3(clampedX, clampedX, clampedX);
        }
    }
}
