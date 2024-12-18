using CharacterChoice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CharacterChoice
{
    public class SceneTransition : MonoBehaviour
    {
        //myGameManagerData�X�N���v�g�̃C���X�^���X
        private GameDataManager myGameManagerData;

        //�X�^�[�g���]�b�g
        private void Start()
        {
            //myGameManagerData���K������
            myGameManagerData = FindObjectOfType<MyGameManager>().GetMyGameManagerData();
        }

        //�e�탁�]�b�g
        public void GoToOtherScene(string stage)
        {
            //�@���̃V�[���f�[�^��MyGameManager�ɕۑ�
            myGameManagerData.SetNextSceneName(stage);
            //�@�L�����N�^�[�I���V�[����
            SceneManager.LoadScene("CharacterChoice");
        }
        public void BackToTitleScene()
        {
            //�@�L�����N�^�[�I���V�[����
            SceneManager.LoadScene("Title");
        }
        public void GameStart()
        {
            //�@MyGameManagerData�ɕۑ�����Ă��鎟�̃V�[���Ɉړ�����
            SceneManager.LoadScene(myGameManagerData.GetNextSceneName());
        }
    }
}
  