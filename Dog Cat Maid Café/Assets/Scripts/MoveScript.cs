using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {

    //so this is so we can change the speed and what not from the editor
    public int speed;

    private Rigidbody2D rigidBody;

    private float xAxis;
    private float yAxis;
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //so I actually have 0 idea what I am doing
        //this gets input, I think
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");

        //I think we need to prevent leaving
        //so the z is important basically for the layering, so we should keep that presumably
        float dist = transform.position.z - Camera.main.transform.position.z;

        //this gets the top bound
        //the y component of the vector 3 is 0 and we are calling for the y \/ here
        float top = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y + transform.lossyScale.y / 2; //the lossy scale takes the scale into account when calculating the borders
        //this gets the bottom                                                                                //if not there, the sprite would be half of the screen at the edges
        //the y component of the vector 3 is 1, indicating something
        float bottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y - transform.lossyScale.y / 2;

        //this is for x
        //left
        //its like for the top but asking for x instead of y
        float left = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x + transform.lossyScale.x / 2;
        //right
        //like bottom but with the 1 in the x and calling for the x instead of y
        float right = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x - transform.lossyScale.x/2; 


        //this is where we set the position if it is out of bounds
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, left, right), //x // so what the clamp does is it takes the first value and makes sure it is between the second, the minimum, and the third, the maximum.
            Mathf.Clamp(transform.position.y, top, bottom), //y                              // if it is not, it sets it to the minimum or maximum, depending on which it is out of bounds of
            transform.position.z //z - this makes sure z is the same
            );
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(xAxis * speed, yAxis * speed);
    }
}
