using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FoodTableScript : MonoBehaviour {

    //stores the food that is on the table
    private Transform food;

    //tells if there is food or not
    private bool hasFood;

    //timer related stuff
    private Thread timerThread;
    public float spawnRateSeconds;
    private bool canSpawn;
    private object locker;
    
    //where we store the sprite
    public Transform foodSprite;

	// Use this for initialization
	void Start () {

        //start with no food
        hasFood = false;

        canSpawn = true;

        locker = new object();
		
	}
	
	// Update is called once per frame
	void Update () {

        //if there is no food, spawn the food;
        if (hasFood == false)
        {
            lock (locker)
            {
                if (canSpawn)
                {
                    //creates the sprite
                    food = Instantiate(foodSprite) as Transform;

                    //sets the position
                    food.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 1);

                    //sets has food to true because food was made
                    hasFood = true;
                    canSpawn = false;
                }
            }

            
        }

	}

    public Transform RemoveFood()
    {
        Transform tempFood = food;

        //delete the food
        Destroy(food, 0);

        //set has food to false
        hasFood = false;

        //create the timer
        timerThread = new Thread(SpawnTimer);
        timerThread.Name = this.name + " spawn timer";
        timerThread.Start();

        return tempFood;
    }

    private void SpawnTimer()
    {
        Thread.Sleep((int) (spawnRateSeconds * 1000));

        lock (locker)
        {
            canSpawn = true;
        }
    }
}
