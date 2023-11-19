using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float moveSpeed;

    private bool isMoving;

    private Vector2 input;

    private SpriteRenderer player;

    public LayerMask currentWall;

    private void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");



            if (input != Vector2.zero)
            {
                var targetPos = transform.position;

                targetPos.x += input.x;
                targetPos.y += input.y;

                // If we can walk towards this space (aka no unauthorized space)
                // then move
                if (isWalk(targetPos) == true) {
                    StartCoroutine(Move(targetPos));
                }
            }

        }
    }

    private bool isWalk(Vector3 targetPos)
    {
        // If we are overlapping a solid object's layer, then we cannot walk there
        if(Physics2D.OverlapCircle(targetPos, 0.2f, currentWall) != null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime * 4);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }


}
