using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBehavior : MonoBehaviour
{
    private float speed = 60f;
    private bool spacePressed = false;
    private float timeToRoof = 1.5f;

    public GameObject floor1;

    public GameObject floor2;
   // public GameObject square;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (spacePressed != false)
        {
            timeToRoof -= Time.deltaTime;
            if (timeToRoof <= 0)
            {
                floor1.transform.position += Vector3.up * speed * Time.deltaTime;
                floor2.transform.position += Vector3.up * speed * Time.deltaTime;
                transform.position += Vector3.up * speed * Time.deltaTime;
                timeToRoof = 1.5f;
                spacePressed = false;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacePressed = true;
        }


    }
    
}
