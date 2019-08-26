using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{   
    [SerializeField] float minX = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // determine world units of height and width of camera
        float height = 2 * Camera.main.orthographicSize;
        float width = height * Camera.main.aspect;

        // find position of mouse in x coor as percentage of total width
        // so we will get a value between 0 and 1
        float mouseXPosInUnits = ((Input.mousePosition.x / Screen.width) * width);
        Vector3 paddlePos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        paddlePos.x = Mathf.Clamp(mouseXPosInUnits, minX, width - minX);
        transform.position = paddlePos;
    }
}
