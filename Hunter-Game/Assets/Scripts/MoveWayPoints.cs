using System.Collections;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float speed = 0.8f;
    private float waitTime;
    public Transform[] moveSpots;
    public float startWaitTime = 2;
    private int i = 0;
    private Vector2 actualPos;


    void Start()
    {
        waitTime = startWaitTime;
        StartCoroutine(CheckEnemyMoving()); 
    }

 
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[i].transform.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                if (moveSpots[i] != moveSpots[moveSpots.Length - 1])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }

                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    IEnumerator CheckEnemyMoving()
    {
        while (true) 
        {
            actualPos = transform.position;

            yield return new WaitForSeconds(0.5f);

            
            if (animator != null)
            {
                if (transform.position.x > actualPos.x)
                {
                    spriteRenderer.flipX = true;
                    animator.SetBool("idl", false);
                }
                else if (transform.position.x < actualPos.x)
                {
                    spriteRenderer.flipX = false;
                    animator.SetBool("idl", false);
                }
                else if (transform.position.x == actualPos.x)
                {
                    animator.SetBool("idl", true);
                }
            }
        }
    }

}
