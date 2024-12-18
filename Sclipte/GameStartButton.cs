using CharacterChoice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace SelectCharacter
{
    public class GameStartButton : MonoBehaviour
    {
        private SceneTransition sceneTransition;

        private void Start()
        {
            sceneTransition = FindObjectOfType<SceneTransition>();
        }

        public void OnGameStart()
        {
            //MyGameManagerData�ɕۑ�����Ă��鎟�̃V�[���Ɉړ�����
            sceneTransition.GameStart();
        }

    }
}