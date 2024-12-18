using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CharacterChoice
{
    [CreateAssetMenu(fileName = "GameDataManager", menuName = "GameDataManager")]
    public class GameDataManager : ScriptableObject
    {
        //�@���̃V�[����
        [SerializeField]
        private string nextSceneName;
        //�@�g�p����L�����N�^�[�v���n�u
        [SerializeField]
        private GameObject character;
        //�@�f�[�^�̏�����
        
        private void OnEnable()
        {

            //�@�^�C�g���V�[���̎��������Z�b�g
            if (SceneManager.GetActiveScene().name == "CharacterChoice")
            {
                nextSceneName = "";
                character = null;
            }
            SceneManager.sceneLoaded += OnSceneLoaded;

        }

        public void SetNextSceneName(string nextSceneName)
        {
            this.nextSceneName = nextSceneName;
        }

        public string GetNextSceneName()
        {
            return nextSceneName;
        }

        public void SetCharacter(GameObject character)
        {
            this.character = character;
        }

        public GameObject GetCharacter()
        {
            return character;
        }
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            // �V�[�������[�h���ꂽ�Ƃ��̏���
            if (scene.name == "Title")
            {
               OnEnable();
            }
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}