using CharacterChoice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterChoice
{
    public class MyGameManager : MonoBehaviour
    {
        //�@���E�Ɉ������MyGameManager
        private static MyGameManager myGameManager;

        //�@�Q�[���S�̂ŊǗ�����f�[�^
        [SerializeField]
        private GameDataManager gameDateManager = null;

        public GameDataManager GetMyGameManagerData()
        {
            return gameDateManager;
        }
    }
}
