using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    public float speed;
    public Vector2 tail;
    public GameObject snake;
    float x = 0, y = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (snake.gameObject.tag.Equals("Head"))
        {
            transform.position = Vector2.MoveTowards(transform.position, snake.GetComponent<Snake>().tail, Time.deltaTime * speed);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, snake.GetComponent<Tail>().tail, Time.deltaTime * speed);
        }
        
        if (Mathf.Abs(transform.position.x) % 1 <= 0.2f)
        {
            x = transform.position.x;
            if (x > 0)
            {
                x = Mathf.Floor(x);
            }
            else
            {
                x = Mathf.Ceil(x);
            }
        }

        if(Mathf.Abs(transform.position.x) % 1 >= 0.8f)
        {
            x = transform.position.x;
            if (x > 0)
            {
                x = Mathf.Ceil(x);
            }
            else
            {
                x = Mathf.Floor(x);
            }
        }

        if (Mathf.Abs(transform.position.y) % 1 <= 0.2f)
        {
            y = transform.position.y;
            if (y > 0)
            {
                y = Mathf.Floor(y);
            }
            else
            {
                y = Mathf.Ceil(y);
            }
        }

        if(Mathf.Abs(transform.position.y) % 1 >= 0.8f)
        {
            y = transform.position.y;
            if (y > 0)
            {
                y = Mathf.Ceil(y);
            }
            else
            {
                y = Mathf.Floor(y);
            }
        }

        tail = new Vector2(x, y);
    }

}
