using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingCamara : MonoBehaviour
{
    public float scrollSpeed = 1.6f; 
    public float stopPositionY = 73f; 

    private bool isScrolling = true;

    void Update()
    {
        if (isScrolling)
        {
            transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
            if (transform.position.y >= stopPositionY)
            {
                isScrolling = false;
            }
        }
    }
}
