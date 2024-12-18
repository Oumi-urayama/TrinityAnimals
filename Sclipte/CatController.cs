using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

/// <summary>
/// �v���C���[�̑���X�N���v�g�̎q�N���X
/// �l�R�p
/// </summary>
public class CatController : Character
{
    //�X�L���̌��ʎ���
    [SerializeField]
    private float skillTime = 0;
    //�X�L�����̈ړ����x
    [SerializeField]
    private float skillMoveSpeed;
    //�X�L�����̃W�����v��
    [SerializeField]
    private float skillJumpForce;
    //�ʏ펞�̈ړ����x
    [SerializeField]
    private float nomalMoveSpeed;
    //�ʏ펞�̃W�����v��
    [SerializeField]
    private float nomalJumpForce;

    //ControllPlayer�̃I�[�o�[���C�h
    public override void ControllPlayer()
    {
        //�e�N���X��ControllPlayer�����Ƃ�
        base.ControllPlayer();
        //skillCoolTime�����炷
        skillCoolTime--;

        //["Skill"]���͂�����A����skillCoolTime�������Ԃ��o�߂��Ă��鎞
        if (playerInput.actions["CatSkill"].triggered && Time.time > canJump)
        {
            myFlagManager.OnSkill = true;
            //skillTimen�ɒl��������
            const float skillTimeLiset = 1000f;//�萔
            skillTime = skillTimeLiset;
            //skillCoolTime�ɒl��������
            const float skillCoolTimeLiset = 10000f;//�萔
            skillCoolTime = skillCoolTimeLiset;
        }
        //skillTime��0���傫���Ƃ�
        if (skillTime > 0)
        {
            //skillTime�����炷
            skillTime--;
            //�e�N���X��sneek��true�ɂ���
            myFlagManager.Sneek = true;
            //movementSpeed��jumpForce��ύX����
            movementSpeed = skillMoveSpeed;
            jumpForce = skillJumpForce;
        }
        //skillTime��0�ȉ��̎�
        else if (skillTime <= 0)
        {
            myFlagManager.OnSkill = false;
            //�e�N���X��sneek��false�ɂ���
            myFlagManager.Sneek = false;
            //movementSpeed��jumpForce��ύX����
            movementSpeed = nomalMoveSpeed;
            jumpForce = nomalJumpForce;
        }
    }
}
