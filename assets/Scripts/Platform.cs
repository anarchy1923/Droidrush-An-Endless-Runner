using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public GameObject diamond;

    // Start is called before the first frame update
    void Start()
    {
        int randDiamond = Random.Range(0, 5);  // 20 % chance of spawning the diamond
        Vector3 diamondPos = transform.position;
        diamondPos.y += 1f;

        if(randDiamond < 1)
        {
            //spawn the diamond
            GameObject diamondInstance = Instantiate(diamond, diamondPos, diamond.transform.rotation);    // instantiated as a child 
            diamondInstance.transform.SetParent(gameObject.transform);
        }
        //1 2 3 4 don't spawn

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Fall();
            Invoke("Fall", 0.2f); //invokes after a small delay instead of immediately
        }
    }

    void Fall()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject, 1f);
    }
}
