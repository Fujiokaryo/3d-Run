using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Image HPimg;

    [SerializeField]
    public float speed;

    [SerializeField]
    private Image JumpIcon;

    [SerializeField]
    private Text countDownText;

    [SerializeField]
    private GameMaster gameMaster;

    public float jumpPower;

    private Animator animator;

    
    private int gameLevel;
    private float gameOverTime;
    private float countDown = 3;
    private float PlayerHP = 1;
    private Rigidbody rb;
    private bool JumppingFlag;
    private bool clearFlag;
    public bool isStart = false;
    public bool GameOver = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        JumppingFlag = true;
        animator.SetBool("rest", true);
    }

    // Update is called once per frame
    void Update()
    {

        CountDownStart();

        PlayerGameOver();

        Accel();

        if (Input.GetKeyDown(KeyCode.D))
        {
            Right(); //右移動
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            Left(); //左移動
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (JumppingFlag == true)
            {
                Jump();
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(GameOver == true)
        {
            return;
        }

        CollisionObjCheck(other);
    }

    /// <summary>
    /// 自走用メソッド
    /// </summary>
    public void Accel()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
    }

    /// <summary>
    /// レーン移動(右）
    /// </summary>
    void Right()
    {

        if (transform.position.x >= -2.5f && transform.position.x <= -2f)
        {
            transform.Translate(1.6f, 0, 0);
        }
        else if (transform.position.x >= -1f&& transform.position.x <= 0)
        {
            transform.Translate(1.6f, 0, 0);
        }
        else if (transform.position.x >= 0.5f && transform.position.x <= 1.5f )
        {
            transform.Translate(1.6f, 0, 0);
            float limitX = Mathf.Clamp(transform.position.x, -2.5f, 2.5f);
            transform.position = new Vector3(limitX, transform.position.y, transform.position.z);
        }

    }

    /// <summary>
    /// レーン移動（左）
    /// </summary>
    void Left()
    {
        if (transform.position.x >= 2f && transform.position.x <= 3)
        {
            transform.Translate(-1.6f, 0, 0);
        }
        else if (transform.position.x >= 0.5f && transform.position.x <= 1.5f)
        {
            transform.Translate(-1.6f, 0, 0);
        }
        else if (transform.position.x >= -1f && transform.position.x <= 0)
        {
            transform.Translate(-1.6f, 0, 0);
            float limitX = Mathf.Clamp(transform.position.x, -2.5f, 2.5f);
            transform.position = new Vector3(limitX, transform.position.y, transform.position.z);
        }
        
    }

    void Jump()
    {      
        rb.AddForce(Vector3.up * jumpPower);
        animator.SetTrigger("jump");
        JumppingFlag = false;
        JumpIcon.enabled = false;
    }

    void CountDownStart()
    {
        if (isStart == false)
        {
            countDown -= Time.deltaTime;
            countDownText.text = countDown.ToString("F2");
            if (countDown < 0)
            {
                isStart = true;
                animator.SetBool("run", true);
                gameMaster.GameStart();
                countDown = 0;
            }

        }
    }

    void PlayerGameOver()
    {
        if (GameOver == true || isStart == false)
        {
            if (GameOver == true)
            {
                gameOverTime += Time.deltaTime;
                PlayerHP = 0;

                if (gameOverTime > 2f)
                {
                    animator.SetBool("reflesh", true);
                    if (!clearFlag)
                    {
                        gameMaster.ScoreCheck();
                        gameMaster.DisplayScore();
                        clearFlag = true;
                    }

                }
            }
            return;
        }
    }

    void CollisionObjCheck(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {

            if (gameMaster.gameLevel <= 3)
            {
                PlayerHP -= 0.25f;
                HPimg.DOFillAmount(PlayerHP, 0.2f);
            }
            else if (gameMaster.gameLevel >= 4)
            {
                PlayerHP -= 0.4f;
                HPimg.DOFillAmount(PlayerHP, 0.2f);
            }

            if (PlayerHP <= 0)
            {
                GameOver = true;
            }

        }

        if (other.gameObject.tag == "HPItem")
        {
            PlayerHP += other.GetComponent<SetUpItem>().itemData.value;
            if (PlayerHP > 1)
            {
                PlayerHP = 1;
            }

            HPimg.DOFillAmount(PlayerHP, 0.3f);
        }

        if (other.gameObject.tag == "JumpItem")
        {
            JumppingFlag = true;
            JumpIcon.enabled = true;
        }
    }
}
