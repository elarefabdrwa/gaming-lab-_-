using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;   //the player
    public float Cameraspeed;  //how fast the camera follows

    public float minX, maxX;   //left and right limits
    public float minY, maxY;   //bottom and top limits

    void FixedUpdate()
    {
        if (Target != null)
        {
            Vector2 newCamPosition = Vector2.Lerp(transform.position, Target.position, Time.deltaTime * Cameraspeed);

            float ClampX = Mathf.Clamp(newCamPosition.x, minX, maxX);
            float ClampY = Mathf.Clamp(newCamPosition.y, minY, maxY);

            transform.position = new Vector3(ClampX, ClampY, -10f);
        }
    }
}