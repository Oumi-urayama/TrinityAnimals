using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
/// <summary>
/// �v���C���[�̑���X�N���v�g�̎q�N���X
/// �C�k�p
/// </summary>

public class DogController : Character
{
    //�v���C���[�̃x�N�g�����Z�b�g�p�̒l
    [SerializeField]
    private float playerVelocityReset = 0f;
    //���Z�b�g�p�̕ϐ�
    [SerializeField]
    private float resetTime = 1f;
    //�X�L�����̃W�����v��
    [SerializeField]
    float skilljumpforce = 10f;
    //�X�L�����̐��i��
    [SerializeField]
    float skillForwardForce = 50f;
    Vector3 skillplayerVelocity;

    //���t���[�����Ƃ�
    private void FixedUpdate()
    {
        //skillCoolTime�����炷
        skillCoolTime--;
        //playerVelocityReset�𑝂₷
        playerVelocityReset++;
    }

    //ControllPlayer�̃I�[�o�[���C�h
    public override void ControllPlayer()
    {
        //�e�N���X��ControllPlayer�����Ƃ�
        base.ControllPlayer();
        //["Skill"]���͂�����A����skillCoolTime�������Ԃ��o�߂��Ă��鎞
        if (playerInput.actions["Skill"].triggered && skillCoolTime <= 0f)
        {
            myFlagManager.OnSkill = true;
            //playerVelocityReset��0�ɂ���
            playerVelocityReset = 0f;
            //�����
            playerVelocity = new Vector3(0f, skilljumpforce, 0f);
            //�O����
            Vector3 forwardForce = transform.forward * skillForwardForce;
            //canJumpn�ɂ��̎��̎��Ԃ�timeBeforeNextJump�𑫂����l������
            canJump = Time.time + timeBeforeNextJump;
            //�W�����v�A�j���[�V�����𓮂���
            anim.SetTrigger("jump");
            //playerVelocity�ɐV�����l������
            playerVelocity = new Vector3(playerVelocity.x + forwardForce.x, playerVelocity.y + forwardForce.y, playerVelocity.z + forwardForce.z);
            //skillCoolTime��coolTime�������
            skillCoolTime = coolTime;
        }
        //playerVelocityReset��resetTime�ɂȂ����Ƃ�
        if (playerVelocityReset >= resetTime)
        {
            myFlagManager.OnSkill = false;
            //playerVelocity��0�ɂ���
            playerVelocity.x = 0f;
            playerVelocity.z = 0f;
            playerVelocityReset = 0;
        }
    }
}
