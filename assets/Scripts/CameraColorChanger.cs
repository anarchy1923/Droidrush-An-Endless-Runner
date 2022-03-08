using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColorChanger : MonoBehaviour
{

    public Color[] colors;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ColorChanger");
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator ColorChanger()
    {
        while (true)
        {
            int randColor = Random.Range(0, 5);

            Camera.main.backgroundColor = colors[randColor];

            yield return new WaitForSeconds(10f);
        }
    }
}
