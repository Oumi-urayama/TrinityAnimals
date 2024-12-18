using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="flagManager")]
public class FlagManager : ScriptableObject
{
    //�Q�[���I�[�o�[�t���O
    [SerializeField]
    private bool gameOver = false;
    //�Q�[���N���A�t���O
    [SerializeField]
    private bool gameClear = false;
    //�Q�[���|�[�Y�t���O
    [SerializeField]
    private bool gamePause = false;
    //�X�j�[�N�t���O(�l�R�̃X�L���Ɏg�p)
    [SerializeField]
    private bool sneek = false;

    [SerializeField]
    private bool onSkill = false;

    public bool GameOver { get => gameOver; set => gameOver = value; }
    public bool GameClear { get => gameClear; set => gameClear = value; }
    public bool GamePause { get => gamePause; set => gamePause = value; }
    public bool Sneek { get => sneek; set => sneek = value; }
    public bool OnSkill { get => onSkill; set => onSkill = value; }
}
