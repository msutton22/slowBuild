using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roofScript : MonoBehaviour
{
    public float speed;
    //public GameObject roof;
    private bool spacePressed = false;

    private float timeToRoof = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spacePressed == false)
        {
            this.GetComponent<Transform> ().Translate (new Vector3 (speed, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 1;
            spacePressed = true;
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision) //when you collide with enemy
    {
        if (collision.gameObject.tag.Equals("wall"))
        {
            speed = -speed;
        }
    }
}