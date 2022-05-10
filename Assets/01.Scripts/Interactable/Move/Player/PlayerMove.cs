using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMove : GeneralMove
{
    private Animator          animator;
    //private PuzzlePlayerInput input; // �Է�


    public int playerHp = 9;
    private PlayerInput input;
    private void Start()
    {
        animator = GetComponent<Animator>();
        input    = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        //animator.SetBool("Run", isMoving);
        if (input.moveInput && !GameManager.Instance.isSmartPhoneUse)
        {
            Vector3 dir = Vector3.zero;
            if (input.left)
            {
                dir = Vector2.left;
            }
            else if (input.right)
            {
                dir = Vector2.right;

            }
            else if (input.up)
            {
                dir = Vector2.up;

            }
            else if (input.down)
            {
                dir = Vector2.down;
            }
            Moving(dir);
            isMoving = true;
        }

    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 11)  //��ǥ���� ����������
        {

        }
        else if(col.gameObject.layer == 12)//����
        {
            --playerHp;
            if(playerHp <=0)
            {
                // ���
            }
        }
        
    }

    
}
