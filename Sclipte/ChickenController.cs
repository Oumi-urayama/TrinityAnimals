using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;

/// <summary>
/// �v���C���[�̑���X�N���v�g�̎q�N���X
/// �j���g���p
/// </summary>
public class ChickenController : Character
{
    //�X�L���̃W�����v�N�[���^�C��
    [SerializeField]
    private float skillNextJump;


    //ControllPlayer�̃I�[�o�[���C�h
    public override void ControllPlayer()
    {
        //�e�N���X��ControllPlayer�����Ƃ�
        base.ControllPlayer();
        ////skillCoolTime�����炷
        
        //["Skill"]���͂�����A����skillCoolTime�������Ԃ��o�߂��Ă��鎞
        if (playerInput.actions["Skill"].triggered && Time.time > skillCoolTime)
        {
            myFlagManager.OnSkill = true;
            //playerVelocity��y����jumpForce����ꂽ�x�N�g�����i�[����
            playerVelocity = new Vector3(0f, jumpForce, 0f);
            //�W�����v������
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //�W�����v�A�j���[�V�����𓮂���
            anim.SetTrigger("jump");
            //canJumpn�ɂ��̎��̎��Ԃ�skillNextJump�𑫂����l������
            canJump = Time.time + skillNextJump;
            //skillCoolTime��coolTime�̒l��������
            skillCoolTime = coolTime;
        }

    }
}
