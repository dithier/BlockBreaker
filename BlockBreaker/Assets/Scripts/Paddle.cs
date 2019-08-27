using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{   
    [SerializeField] float minX = 1f;
    // determine world units of height and width of camera
    float height;
    float width;

    // cached references
    GameStatus theGameSession;
    Ball theBall;

    // Start is called before the first frame update
    void Start()
    {
        height = 2 * Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
        theGameSession = FindObjectOfType<GameStatus>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        // find position of mouse in x coor as percentage of total width
        // so we will get a value between 0 and 1
        Vector3 paddlePos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, width - minX);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
            
        }
        else
        {
            return ((Input.mousePosition.x / Screen.width) * width);
        }
    }
}
