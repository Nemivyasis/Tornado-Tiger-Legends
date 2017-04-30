using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    private Transform inventoryFood;

    private bool hasFood;

	// Use this for initialization
	void Start () {
        //so what do we do here? 
        hasFood = false;
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //make sure it is a food table
        //almost certainly a better way to do this
        if(collision.collider.name == "FoodTable")
        {
            FoodTableScript script = collision.collider.GetComponent<FoodTableScript>();

            if(inventoryFood == null)
            {
                inventoryFood = script.RemoveFood();

                //actually make this properly calculated
                inventoryFood.position = new Vector3(-9.6f, 4.8f, -1);

                hasFood = true;
            }
        }

        else if(collision.collider.name == "CustomerTable")
        {
            //remove the food
            if(hasFood)
            {
                Destroy(inventoryFood, 0);

                hasFood = false;
            }

        }
    }
}
