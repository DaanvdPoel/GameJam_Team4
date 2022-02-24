using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private float xMax = 500;

    [SerializeField]
    private float yMax = 500;

    [SerializeField]
    private float xMin = -500;

    [SerializeField]
    private float yMin = -500;
    
    public enum walkdirection { left, right, still }
    public walkdirection direction;

    public Vector2 offset;
    public Transform player;

    private Vector3 followPlayer;

    public float walkingLerpSpeed = 2;
    private float standingLerpSpeed = 1.5f;


    private void Start()
    {
        offset.x = 4;
        offset.y = 2;
    }

    void FixedUpdate()
    {
        followPlayer = new Vector3(Mathf.Clamp(player.position.x, xMin, xMax), 
            Mathf.Clamp(player.position.y + offset.y, yMin, yMax), transform.position.z);

        
            if (player.transform.position.x < transform.position.x - 1.5f)
            {
                direction = walkdirection.left;
            }
            else if (player.position.x > transform.position.x + 1.5f)
            {
                direction = walkdirection.right;
            }
            else if(!player.GetComponent<PlayerMovement>().moving)
            {
                direction = walkdirection.still;
            }
        

        if (player.GetComponent<PlayerMovement>().state == PlayerMovement.fallingState.standing)
            offset.y = 2;
        else if (player.GetComponent<PlayerMovement>().state == PlayerMovement.fallingState.falling)
            offset.y = -2;
        else if (player.GetComponent<PlayerMovement>().state == PlayerMovement.fallingState.notFalling)
            offset.y = 1;

        Walking();
    }

    private void Walking()
    {
        if(direction == walkdirection.left)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(followPlayer.x - offset.x,
                    followPlayer.y, transform.position.z), walkingLerpSpeed * Time.fixedDeltaTime);
        }
        else if(direction == walkdirection.right)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(followPlayer.x + offset.x,
                    followPlayer.y, transform.position.z), walkingLerpSpeed * Time.fixedDeltaTime);
        }
        else if(direction == walkdirection.still)
        {
            transform.position = Vector3.Lerp(transform.position, followPlayer, standingLerpSpeed * Time.fixedDeltaTime);
        }
    }
}

