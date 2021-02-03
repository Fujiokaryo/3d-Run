using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RightplayerCon : MonoBehaviour
{
    [SerializeField]
    private Image HPimg;

    [SerializeField]
    private Text countDownText;

    [SerializeField]
    private GameMaster gameMaster;

    

    public float speed;

    public bool isStart = false;
    private bool clearFlag;
    public bool JumppingFlag;
    public bool GameOver = false;
    public float PlayerHP = 1;
    public float countDown = 3;
    private float gameOverTime;
    private int gameLevel;
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
                animator.SetBool("run", true);
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


    }

    private void OnTriggerEnter(Collider other)
    {
        if(GameOver == true)
        {
            return;
        }

        if (other.gameObject.tag == "Wall")
        {
            gameLevel = gameMaster.gameLevel;

            if (gameLevel <= 3)
            {
                PlayerHP -= 0.25f;
                HPimg.DOFillAmount(PlayerHP, 0.2f);
            }
            else if (gameLevel >= 4)
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
            PlayerHP += 0.25f;
            if (PlayerHP > 1)
            {
                PlayerHP = 1;
            }

            HPimg.DOFillAmount(PlayerHP, 0.3f);
        }

        if(other.gameObject.tag == "fullHPItem")
        {
            PlayerHP = 1;
            HPimg.DOFillAmount(PlayerHP, 0.3f);
        }

    }

    private void Accel()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
    }
}
