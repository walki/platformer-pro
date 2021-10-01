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
    private float gravity = -40.0f;

    [SerializeField]
    private float jumpHeight = 4.0f;

    [SerializeField]
    private float currVertSpeed = 0f;
    
    private bool canDoubleJump = true;
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

        float vert = 0f;

        if (Input.GetKeyDown(KeyCode.Space) && (controller.isGrounded || canDoubleJump))
        {
            vert = Mathf.Sqrt(2.0f * Mathf.Abs(gravity) * jumpHeight);
            if (!controller.isGrounded)
            {
                canDoubleJump = false;
            }
        }
        else if (!controller.isGrounded)
        {
            vert = currVertSpeed + (gravity * Time.deltaTime);
        }
        else
        {
            vert = -1.0f;
            canDoubleJump = true;
        }
        

        Vector3 velocity = xVel;
        velocity.y = vert;

        currVertSpeed = vert;

        controller.Move(velocity * Time.deltaTime);
    }

    public void AddCoin()
    {
        playerCoins++;
        uiManager.UpdateCoinScore(playerCoins);
    }
}
