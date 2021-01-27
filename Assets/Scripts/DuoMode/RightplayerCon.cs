using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightplayerCon : MonoBehaviour
{
    [SerializeField]
    public Image JumpIcon;

    [SerializeField]
    private Text countDownText;

    [SerializeField]
    private GameMaster gameMaster;

    

    public float speed;

    public bool isStart = false;
    public bool JumppingFlag;
    public bool GameOver = false;
    private float countDown = 3;
    private float gameOverTime;
    private float PlayerHP = 1;
    private Animator animator;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        JumppingFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart == false)
        {
            countDown -= Time.deltaTime;
            countDownText.text = countDown.ToString("F2");
            if (countDown < 0)
            {
                isStart = true;
                gameMaster.GameStart();
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

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(1.6f, 0, 0);
            float limitX = Mathf.Clamp(transform.position.x, 1.1f, 2.7f);
            transform.position = new Vector3(limitX, transform.position.y, transform.position.z);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            transform.Translate(-1.6f, 0, 0);
            float limitX = Mathf.Clamp(transform.position.x, 1.1f, 2.7f);
            transform.position = new Vector3(limitX, transform.position.y, transform.position.z);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Accel()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * 300);
        animator.SetTrigger("jump");
        JumppingFlag = false;
        JumpIcon.enabled = false;
    }
}
