using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float moveSpeed;

    private bool isMoving;

    private Vector2 input;

    private SpriteRenderer player;

    private void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");


            /*
            if (input.x > 0)
            {
                //input.y = 0;
                //transform.rotation = Quaternion.Euler(Vector3.forward * 180);
                player.flipX = true;
                
            }
            if ( input.x < 0)
            {
                // input.y = 0;
                //transform.rotation = Quaternion.Euler(Vector3.forward * -180);
                player.flipX = false;
            }

     
            if (input.y > 0)
            {
                //input.y = 0;
                transform.rotation = Quaternion.Euler(Vector3.forward * 180);

            }
            if (input.y < 0)
            {
                // input.y = 0;
                transform.rotation = Quaternion.Euler(Vector3.forward * 0);
            }

            /*
            if (input.y != 0)
            {
                input.x = 0;
            }
            */

            if (input != Vector2.zero)
            {
                var targetPos = transform.position;

                targetPos.x += input.x;
                targetPos.y += input.y;

                StartCoroutine(Move(targetPos));
            }

        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }


}
