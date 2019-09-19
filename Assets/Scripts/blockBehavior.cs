using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockBehavior : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Transform> ().Translate (new Vector3 (speed, 0));			
    }
    
    void OnCollisionEnter2D(Collision2D collision) //when you collide with enemy
    {
        if (collision.gameObject.tag.Equals("wall"))
        {
            speed = -speed;
        }
    }
}
