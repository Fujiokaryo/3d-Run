using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftplayerCon : MonoBehaviour
{
    [SerializeField]
    public float speed;

    [SerializeField]
    private RightplayerCon rightplayerCon;

    public bool isStart = false;
    private float countDown = 3;
    private float PlayerHP = 1;
    private float gameOverTime;
    public bool GameOver = false;
    private Animator animator;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart == false)
        {
            countDown -= Time.deltaTime;         
            if (countDown < 0)
            {
                isStart = true;
                countDown = 0;
            }
        }

        if (GameOver == true || isStart == false)
        {
            if (GameOver == true)
            {
                gameOverTime += Time.deltaTime;
                PlayerHP = 0;
                if (gameOverTime > 3f)
                {
                    animator.SetBool("rest", true);

                }
            }
            return;
        }

        Accel();
        

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-1.6f, 0, 0);
            float limitX = Mathf.Clamp(transform.position.x, -2.1f, -0.5f);
            transform.position = new Vector3(limitX, transform.position.y, transform.position.z);
        }
        else if(Input.GetKeyUp(KeyCode.A))
        {
            transform.Translate(1.6f, 0, 0);
            float limitX = Mathf.Clamp(transform.position.x, -2.1f, -0.5f);
            transform.position = new Vector3(limitX, transform.position.y, transform.position.z);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void Accel()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * 300);
        animator.SetTrigger("jump");
        rightplayerCon.JumppingFlag = false;
        rightplayerCon.JumpIcon.enabled = false;
    }
}
