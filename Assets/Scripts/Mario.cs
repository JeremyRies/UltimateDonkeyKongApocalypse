using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour {

    public float speed;
    Rigidbody2D body;
    Vector2 movement;

	// Use this for initialization
	void Start () {
        body = gameObject.GetComponent<Rigidbody2D>();
        Move(Vector2.right);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void Move(Vector2 movement)
    {
        body.velocity = movement * speed;
    }

    public void Rotate(Vector2 movement)
    {
        //transform.eulerAngles.y = transform.eulerAngles.y * -1;
    }

    public void RandomMove()
    {
        int rand = Random.Range(0,2);

        switch(rand)
        {
            case 0:
                Move(Vector2.right);
                break;

            case 1:
                Move(Vector2.left);
                break;

            default:
                Move(Vector2.zero);
                break;
        }
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            Move(Vector2.up);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            RandomMove();

        }
    }
}
