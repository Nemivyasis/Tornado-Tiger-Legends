using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTableScript : MonoBehaviour {

    //stores the food that is on the table
    private Transform food;

    //tells if there is food or not
    private bool hasFood;

    
    //where we store the sprite
    public Transform foodSprite;

	// Use this for initialization
	void Start () {

        //start with no food
        hasFood = false;
		
	}
	
	// Update is called once per frame
	void Update () {

        //if there is no food, spawn the food;
        if (hasFood == false)
        {
            //creates the sprite
            food = Instantiate(foodSprite) as Transform;

            //sets the position
            food.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 1);
            
            //sets has food to true because food was made
            hasFood = true;


            
        }

	}

    public Transform RemoveFood()
    {
        Transform tempFood = food;

        //delete the food
        Destroy(food, 0);

        //set has food to false
        hasFood = false;

        return tempFood;
    }
}
