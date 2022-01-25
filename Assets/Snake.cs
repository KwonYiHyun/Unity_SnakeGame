using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public float speed;
    public Vector2 tail;
    public List<GameObject> tails = new List<GameObject>();
    public GameObject ta;
    Vector2 dir;
    
    void Start()
    {
        dir = Vector2.down;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("Apple"))
        {

        }
        else
        {
            Debug.Log("Die");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject t = Instantiate(ta);
            //t.GetComponent<BoxCollider2D>().enabled = false;
            t.GetComponent<Tail>().snake = tails[tails.Count - 1];
            t.transform.position = tails[tails.Count - 1].transform.position;
            tails.Add(t);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (dir == Vector2.up) return;
            StartCoroutine(goUp());
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (dir == Vector2.left) return;
            StartCoroutine(goLeft());
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (dir == Vector2.down) return;
            StartCoroutine(goDown());
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (dir == Vector2.right) return;
            StartCoroutine(goRight());
        }

        transform.position += new Vector3(dir.x, dir.y, 0) * Time.deltaTime * speed;

        if (Mathf.Abs(transform.position.x) % 1 <= 0.05f && Mathf.Abs(transform.position.y) % 1 <= 0.05f)
        {
            float x = transform.position.x;
            float y = transform.position.y;
            if (x < 0)
            {
                x = Mathf.Ceil(x);
            }
            else
            {
                x = Mathf.Floor(x);
            }
            if (y < 0)
            {
                y = Mathf.Ceil(y);
            }
            else
            {
                y = Mathf.Floor(y);
            }
            tail = new Vector2(x, y);
        }
    }

    IEnumerator goDown()
    {
        while (true)
        {
            if (Mathf.Abs(transform.position.x) % 1 <= 0.05f)
            {
                float c;
                if (transform.position.x < 0)
                {
                    c = Mathf.Ceil(transform.position.x);
                }
                else
                {
                    c = Mathf.Floor(transform.position.x);
                }
                transform.position = new Vector2(c, transform.position.y);
                dir = Vector2.down;
                break;
            }
            yield return null;
        }
    }

    IEnumerator goUp()
    {
        while (true)
        {
            if (Mathf.Abs(transform.position.x) % 1 <= 0.05f)
            {
                float c;
                if (transform.position.x < 0)
                {
                    c = Mathf.Ceil(transform.position.x);
                }
                else
                {
                    c = Mathf.Floor(transform.position.x);
                }
                transform.position = new Vector2(c, transform.position.y);
                dir = Vector2.up;
                break;
            }
            yield return null;
        }
    }

    IEnumerator goLeft()
    {
        while (true)
        {
            if (Mathf.Abs(transform.position.y) % 1 <= 0.05f)
            {
                float c;
                if (transform.position.y < 0)
                {
                    c = Mathf.Ceil(transform.position.y);
                }
                else
                {
                    c = Mathf.Floor(transform.position.y);
                }
                transform.position = new Vector2(transform.position.x, c);
                dir = Vector2.left;
                break;
            }
            yield return null;
        }
    }

    IEnumerator goRight()
    {
        while (true)
        {
            if (Mathf.Abs(transform.position.y) % 1 <= 0.05f)
            {
                float c;
                if (transform.position.y < 0)
                {
                    c = Mathf.Ceil(transform.position.y);
                }
                else
                {
                    c = Mathf.Floor(transform.position.y);
                }
                transform.position = new Vector2(transform.position.x, c);
                dir = Vector2.right;
                break;
            }
            yield return null;
        }
    }
}
