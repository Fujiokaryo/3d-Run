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
    private GameMaster gameMaster;

    private int gameLevel;

    private float PlayerHP = 1;
    private Rigidbody rb;
    private bool JumppingFlag;
    private bool GameOver = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameOver == true)
        {
            return;
        }

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
        if(other.gameObject.tag == "Wall")
        {
            gameLevel = gameMaster.GetComponent<GameMaster>().gameLevel;
            if (gameLevel <= 3)
            {
                PlayerHP -= 0.25f;
                HPimg.DOFillAmount(PlayerHP, 0.2f);
            }
            else if(gameLevel >= 4)
            {
                PlayerHP -= 0.4f;
                HPimg.DOFillAmount(PlayerHP, 0.2f);
            }

            if (PlayerHP == 0)
            {
                GameOver = true;
            }

        }

        if(other.gameObject.tag == "HPItem")
        {
            PlayerHP += 0.25f;
            HPimg.DOFillAmount(PlayerHP, 0.3f);
        }

        if(other.gameObject.tag == "JumpItem")
        {
            JumppingFlag = true;
            JumpIcon.enabled = true;
        }
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

        if (transform.position.x == -5)
        {
            transform.Translate(3.5f, 0, 0);
        }
        else if (transform.position.x == -1.5)
        {
            transform.Translate(3f, 0, 0);
        }
        else if (transform.position.x == 1.5)
        {
            transform.Translate(3.5f, 0, 0);
        }

    }

    /// <summary>
    /// レーン移動（左）
    /// </summary>
    void Left()
    {
        if (transform.position.x == 5)
        {
            transform.Translate(-3.5f, 0, 0);
        }
        else if (transform.position.x == 1.5)
        {
            transform.Translate(-3f, 0, 0);
        }
        else if (transform.position.x == -1.5)
        {
            transform.Translate(-3.5f, 0, 0);
        }
        
    }

    void Jump()
    {      
        rb.AddForce(Vector3.up * 370);
        JumppingFlag = false;
        JumpIcon.enabled = false;
    }

}
