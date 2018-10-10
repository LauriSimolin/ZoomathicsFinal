using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour {

    public Transform[] spawnpoints;
    public Transform[] originalSpawn;
    public GameObject fruit;
    public List<GameObject> fruits = new List<GameObject>();
    

	// Use this for initialization
	void Start () {

        for (int i = 0; i < spawnpoints.Length; i++)
        {
            originalSpawn[i] = spawnpoints[i];
            
        }
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void Spawn(int numberOfFruits)
    {
        float shift = 0.4f;        // randomizing shift is changed here

        for(int i =0; i < numberOfFruits; i++)
        {
            //Instantiating fruits on randomized points and adding them into fruit-list
            fruits.Add(Instantiate(fruit, RandomizePosition(spawnpoints[i],shift).position, Quaternion.identity));
        }

        // Resetting spawning point of the fruits back to original
        for (int i = 0; i < numberOfFruits; i++)
        {
            spawnpoints[i] = ZeroSpawnPoint(spawnpoints[i], originalSpawn[i]);
        }

    }

    public void DestroyAllFruits()
    {
        for (int i=0; i < fruits.Count; i++)
        {
            Destroy(fruits[i]);
        }
    }

    // Randomizing spawning position of the fruit by moving it's position from original spawnpoint position
    Transform RandomizePosition(Transform point, float shift)
    {
        float xMove = Random.Range(-shift, shift);
        float yMove = Random.Range(-shift, shift);
        
        Vector3 direction = new Vector3(xMove, yMove);
        
        point.Translate(direction);

        return point;
    }

    // Reset spawnpoints back to original one
    Transform ZeroSpawnPoint(Transform point,Transform original)
    {

        point.SetPositionAndRotation(new Vector3(original.position.x, original.position.y), Quaternion.identity);
        return point;
    }
}
