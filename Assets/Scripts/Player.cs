using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    float xMin, xMax, yMin, yMax;
    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    
    private void SetUpMoveBoundaries()
    {
        //get the Main Camera from Unity
        Camera gameCamera = Camera.main;

        //set the boundaries on the x-axis
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding ;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding ;

        //set the boundaries on the y-axis
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding - 5 ;
    }

    void Move()
    {
               
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        //newXPos   = current x-position   + difference in x
        var newXPos = transform.position.x + deltaX;
        //apply boundaries on x-axis
        newXPos = Mathf.Clamp(newXPos, xMin, xMax);

        //the above in y axis:
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newYPos = transform.position.y + deltaY;
        newYPos = Mathf.Clamp(newYPos, yMin, yMax);

        //move the Player ship to the newXPos
        this.transform.position = new Vector2(newXPos, newYPos);
        
                
    }
}
