using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuigiPipe : MonoBehaviour {

    public int duration;

	// Use this for initialization
	void Start () {
        StartCoroutine(Die());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RandomMove()
    {
        int rand = Random.Range(0, 5);

        switch (rand)
        {
            case 0:
                Move(Vector2.right);

                break;

            case 1:
                Move(Vector2.left);

                break;

            case 2:
                Move(Vector2.left);

                break;

            case 3:
                Move(Vector2.left);

                break;

            case 4:
                Move(Vector2.left);

                break;

            default:
                Move(Vector2.zero);
                break;
        }
    }

    public IEnumerator Die()
    {
        int state = 0;

        while (state == 0)
        {
            yield return new WaitForSeconds(4);
            state = 1;
        }



        while (state == 1)
        {
            
            yield return new WaitForSeconds(4);
            state = 2;
        }

        while (state == 2)
        {

            yield return new WaitForSeconds(4);
            state = 3;
        }

        Destroy(gameObject);
    }
}
