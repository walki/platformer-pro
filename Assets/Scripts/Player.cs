using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private CharacterController controller;
    private UIManager uiManager;


    [SerializeField]
    private float speed = 5.0f;

    [SerializeField]
    private float gravity = 1.0f;

    [SerializeField]
    private float jumpHeight = 25.0f;

    
    private float yVelocity = 0f;
    private bool canDoubleJump = false;
    private int playerCoins = 0;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        
        float xInput = Input.GetAxis("Horizontal");
        Vector3 xDir = Vector3.right * xInput;
        Vector3 xVel = xDir * speed;

        
        if (controller.isGrounded )
        {
            if (Input.GetKeyDown(KeyCode.Space))
            { 
                yVelocity = jumpHeight;
                canDoubleJump = true;
            }
            else
            {
                yVelocity = -gravity;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump)
            {
                yVelocity += jumpHeight;
                canDoubleJump = false;
            }
            yVelocity -= gravity;

        }

        Vector3 velocity = xVel;
        velocity.y = yVelocity;
        
        controller.Move(velocity * Time.deltaTime);
    }

    public void AddCoin()
    {
        playerCoins++;
        uiManager.UpdateCoinScore(playerCoins);
    }
}
