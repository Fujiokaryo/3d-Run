using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LeftplayerCon : MonoBehaviour
{
    [SerializeField]
    public float speed;

    [SerializeField]
    private RightplayerCon rightplayerCon;

    [SerializeField]
    private GameMaster gameMaster;

    [SerializeField]
    private Image HPimg;


    private int gameLevel;
    private float countDown = 3;
    private float gameOverTime;
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
   
        if(rightplayerCon.isStart == true)
        {
            animator.SetBool("param_idletorunning", true);
            transform.position = new Vector3(transform.position.x, transform.position.y, GameObject.Find("unitychan").GetComponent<Transform>().position.z);
        }

        if (rightplayerCon.GameOver == true || rightplayerCon.isStart == false)
        {
            if (rightplayerCon.GameOver == true)
            {
                gameOverTime += Time.deltaTime;
                rightplayerCon.PlayerHP = 0;
                if (gameOverTime > 2f)
                {
                    animator.SetBool("hit", true);

                    if(gameOverTime > 3.2f)
                    {
                        animator.SetBool("param_idletorunning", false);
                        animator.SetBool("walk", true);
                    }
                    
                }
            }
            return;
        }

        Accel();
        

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-1.6f, 0, 0);
            float limitX = Mathf.Clamp(transform.position.x, -2.5f, -0.9f);
            transform.position = new Vector3(limitX, transform.position.y, transform.position.z);
        }
        else if(Input.GetKeyUp(KeyCode.A))
        {
            transform.Translate(1.6f, 0, 0);
            float limitX = Mathf.Clamp(transform.position.x, -2.5f, -0.9f);
            transform.position = new Vector3(limitX, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if(rightplayerCon.GameOver == true)
        {
            return;
        }

        if (other.gameObject.tag == "Wall")
        {
            gameLevel = gameMaster.gameLevel;

            if (gameLevel <= 3)
            {
                rightplayerCon.PlayerHP -= 0.25f;
                HPimg.DOFillAmount(rightplayerCon.PlayerHP, 0.2f);
            }
            else if (gameLevel >= 4)
            {
                rightplayerCon.PlayerHP -= 0.4f;
                HPimg.DOFillAmount(rightplayerCon.PlayerHP, 0.2f);
            }

        }

        if (other.gameObject.tag == "HPItem")
        {
            rightplayerCon.PlayerHP += other.GetComponent<SetUpItem>().itemData.value;
            if (rightplayerCon.PlayerHP > 1)
            {
                rightplayerCon.PlayerHP = 1;
            }

            HPimg.DOFillAmount(rightplayerCon.PlayerHP, 0.3f);
        }

        if (other.gameObject.tag == "fullHPItem")
        {
            rightplayerCon.PlayerHP = other.GetComponent<SetUpItem>().itemData.value;
            HPimg.DOFillAmount(rightplayerCon.PlayerHP, 0.3f);
        }

    }

    public void Accel()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
    }

   
}
