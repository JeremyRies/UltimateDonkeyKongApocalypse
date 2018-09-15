using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mario : MonoBehaviour {

    public float speed;
    public float boundarys;
    Animator MarioAnimator;
    Rigidbody2D body;
    

	// Use this for initialization
	void Start () {
        body = gameObject.GetComponent<Rigidbody2D>();
        MarioAnimator = GetComponent<Animator>();
        Spawn();
    }
	
	// Update is called once per frame
	void Update () {
        Boundary();
    }

    public void Boundary()
    {
        if( transform.position.x > boundarys)
        {
            Move(Vector2.left);
        }

        if (transform.position.x < -boundarys)
        {
            Move(Vector2.right);
        }
    }

    public IEnumerator Die()
    {
        int state = 0;
        GetComponent<BoxCollider2D>().enabled = false;

        while(state ==0)
        {
            speed = 1;
            Move(Vector2.up);
            yield return new WaitForSeconds(0.5f);
            state = 1;
        }

        while (state == 1)
        {
            speed = 7;
            Move(Vector2.down);
            yield return new WaitForSeconds(2);
            state = 2;
        }

        Destroy(gameObject);
    }

        public void Spawn()
    {
        if (transform.position.x > 0)
        {
            Move(Vector2.left);
        }

        if (transform.position.x < 0)
        {
            Move(Vector2.right);
        }

    }

        public void Move(Vector2 movement)
    {
        Debug.Log(movement);
        body.velocity = movement * speed;
        Rotate(movement);
        
        
    }

    public void Rotate(Vector2 movement)
    {


        if (movement == Vector2.left)
        { transform.rotation = Quaternion.Euler(0, 0, 0);
            
        }

        if (movement == Vector2.right)
        { transform.rotation = Quaternion.Euler(0, 180, 0);
            
        }


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
            MarioAnimator.SetInteger("climb", 1);
            Move(Vector2.up);
        }

        if (collision.gameObject.tag == "Barrel")
        {
            GameObject.Find("Score").GetComponent<ScoreManager>().AddPoint();
            MarioAnimator.SetBool("dead", true);
            StartCoroutine(Die());
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            MarioAnimator.SetInteger("climb", 0);
            RandomMove();

        }
    }
}
