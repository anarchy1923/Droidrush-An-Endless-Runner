using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;


    public Transform lastPlatform; 
    Vector3 lastPosition;                       //in order to store 3 values in the position, we need vector 3 variable. 
    Vector3 newPos;

    bool stop;   //by default false


    // Start is called before the first frame update
    void Start()
    {
        lastPosition = lastPlatform.position;   //we are getting the position of the last platform and storing it in the variable to store the position of the last platform. 
        StartCoroutine(SpawnPlatforms()); 
        
    }

    // Update is called once per frame
    void Update()
    {

     




        //if (Input.GetKey(KeyCode.Space))
        //{
        //    SpawnPlatforms();
        //}
        
    }

    IEnumerator SpawnPlatforms()
    {


        while (!stop)
        {
            GeneratePosition();

            Instantiate(platform, newPos, Quaternion.identity);    // we are not creating any manual rotation. 

            lastPosition = newPos;

            yield return new WaitForSeconds(0.1f); //waits for 0.1 second

        }



        
    }


    //void SpawnPlatforms()
    //{
    //    GeneratePosition();
    //    Instantiate(platform, newPos, Quaternion.identity);    // we are not creating any manual rotation. 
    //    lastPosition = newPos;

    //}

    void GeneratePosition()
    {
        newPos = lastPosition;                //newPosition variable has the same position as the last position variable. 

        int rand = Random.Range(0, 2);        //creation of randomizer

        if (rand > 0)
        {

            newPos.x += 2f;
        }
        else
        {
            newPos.z += 2f;
        }
    }
}
