using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Drag : MonoBehaviour
{
    bool isAlt;
    Vector2 clickPoint;
    float dragSpeed = 30.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt)) isAlt = true;
        if (Input.GetKeyUp(KeyCode.LeftAlt)) isAlt = false;

        if (Input.GetMouseButtonDown(0)) clickPoint = Input.mousePosition; //마우스 위치 기억

        if (Input.GetMouseButton(0))
        {
            if (isAlt)
            {
                Vector3 position
                    = Camera.main.ScreenToViewportPoint((Vector2)Input.mousePosition - clickPoint);

              /*  position.z = position.y;
                position.y = .0f;*/

                Vector3 move = position * (Time.deltaTime * dragSpeed);

               // float y = transform.position.y;

                transform.Translate(move);
               /* transform.transform.position
                    = new Vector3(transform.position.x, y, transform.position.z);*/
            }
        }
    }
}