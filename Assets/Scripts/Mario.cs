using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mario : MonoBehaviour {

    public float speed;
    public float boundarys;
    public float jumpchance;
    bool jumping;
    bool climbing;
    bool dead = false;
    Animator MarioAnimator;
    Vector2 movement;
    Rigidbody2D body;
    

	// Use this for initialization
	void Start () {
        body = gameObject.GetComponent<Rigidbody2D>();
        MarioAnimator = GetComponent<Animator>();
        Spawn();
        StartCoroutine(JumpCheck());
    }
	
	// Update is called once per frame
	void Update () {
        Boundary();
    }

    public IEnumerator JumpCheck()
    {
        while (true)
        {
            int rand = Random.Range(0, 100);

            if (rand <= jumpchance && jumping == false && climbing == false && dead == false)
            {
                StartCoroutine(Jump(0.5f,3));
            }

          yield return new WaitForSeconds(1);
            
        }
    }

    public IEnumerator Jump(float height, float jumpspeed)
    {
        jumping = true;
        float jumppower = 1;
        GetComponent<BoxCollider2D>().enabled = false;

        while (jumppower > 0)
        {
            body.velocity = new Vector2(movement.x,jumppower) * jumpspeed;

            yield return new WaitForSeconds(height/100);
            jumppower = jumppower - 0.1f;

        }

        jumppower = -1;

        while (jumppower < 0)
        {
            body.velocity = new Vector2(movement.x, jumppower) * jumpspeed;

            yield return new WaitForSeconds(height/100);
            jumppower = jumppower + 0.1f;

        }
        jumping = false;
        Move(movement);
        GetComponent<BoxCollider2D>().enabled = true;

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
        dead = true;
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
        this.movement = movement;
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
            climbing = true;
            Move(Vector2.up);
        }

        if (collision.gameObject.tag == "Barrel")
        {
            GameObject.Find("Score").GetComponent<ScoreManager>().AddPoint();
            MarioAnimator.SetBool("dead", true);
            StartCoroutine(Die());
        }
        
        if (collision.gameObject.tag == "Pauli")
        {
            GameObject.Find("Score").GetComponent<ScoreManager>().EndGame();
        }
    }
    
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            MarioAnimator.SetInteger("climb", 0);
            climbing = false;
            RandomMove();

        }
    }
}
