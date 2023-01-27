using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public GameObject BallR, BallL; 
    public Transform parent_pos;
    public Vector2 direction;
    public float speed = 30;
    float a = 1;
    IEnumerator delayStart()
    {
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    void Start()
    {
        speed = 30;
        StartCoroutine(delayStart());
        // GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        a = 1;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, a);

        if (col.gameObject.name == "RacketLeft")
        {
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
            Vector2 dir = new Vector2(1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        else if (col.gameObject.name == "RacketRight")
        {
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
            Vector2 dir = new Vector2(-1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        speed += 5;
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.TryGetComponent(out Walls wall))
        {
            wall.score += 1;
            if (wall.name == "WallLeft") Instantiate(BallL, parent_pos.position, Quaternion.identity);
            else if (wall.name == "WallRight") Instantiate(BallR, parent_pos.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void FixedUpdate()  
    {
       a -= 0.8f * Time.deltaTime * (speed * 0.01f) ;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, a);
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
