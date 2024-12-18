using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using CharacterChoice;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    //myGameManagerData�X�N���v�g�̃C���X�^���X
    private GameDataManager myGameManagerData;
    //�e�Q�[���I�u�W�F�N�g���i�[����ϐ�
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private GameObject GameStart;
    [SerializeField]
    private GameObject GameClear;
    [SerializeField]
    private GameObject GameOver;
    [SerializeField]
    private GameObject GamePause;
    [SerializeField]
    private GameObject ReStart;
    [SerializeField]
    private GameObject ReTryButton;
    [SerializeField]
    private GameObject BackToTitle;

    [SerializeField]
    private FlagManager myFlagManager;

    private Character chara;
    private PlayerInput playerInput;


    //�X�^�[�g���]�b�g
    void Start()
    {
        Time.timeScale = 1;
        //Inactive���]�b�g��1.0����ɓ�����
        Invoke("Inactive", 1.0f);
        //�Q�[���I�u�W�F�N�g�̃A�N�e�B�r�e�B��false�ɂ���
        GameClear.SetActive(false);
        GameOver.SetActive(false);
        GamePause.SetActive(false);
        //Character��gameOver�EgameClear��false�ɂ���
        myFlagManager.GameOver = false;
        myFlagManager.GameClear = false;
        //�Q�[���I�u�W�F�N�g�̃A�N�e�B�r�e�B��false�ɂ���
        panel.SetActive(false);
        //myGameManagerData���K������
        myGameManagerData = FindObjectOfType<MyGameManager>().GetMyGameManagerData();
        myFlagManager = FindObjectOfType<MyFlagManager>().GetFlagManagerDate();
        //chara=GameObject.FindWithTag("Player").GetComponent<Character>();
        playerInput=GetComponent<PlayerInput>();
    }

    // ���t���[�����Ƃɓ�����
    void Update()
    {
        if(chara == null)
        {
            chara = GameObject.FindWithTag("Player").GetComponent<Character>();
        }
        //Character��gameClear��true�̎�
        if (myFlagManager.GameClear)
        {
            //�e�I�u�W�F�N�g�̃A�N�e�B�r�e�B��true�ɂ���
            GameClear.SetActive(true);
            panel.SetActive(true);
            //ReTryButton���K������
            Button bt = ReTryButton.GetComponent<Button>();
            Button Bt = ReStart.GetComponent<Button>();
            //bt�𖳌�������
            bt.interactable = false;
            Bt.interactable = false;
        }
        //Character��gameOver��true�̎�
        else if (myFlagManager.GameOver)
        {
            Time.timeScale = 0;
            //myGameManagerData��SetNextSceneName���]�b�g��"CharacterChoice"�������ɂ��ē�����
            myGameManagerData.SetNextSceneName("CharacterChoice");
            //�e�I�u�W�F�N�g�̃A�N�e�B�r�e�B��true�ɂ���
            GameOver.SetActive(true);
            panel.SetActive(true);

        }
        //Character��gamePause��true�̎�
        else if (myFlagManager.GamePause)
        {
            Time.timeScale = 0;
            //�e�I�u�W�F�N�g�̃A�N�e�B�r�e�B��true�ɂ���
            GamePause.SetActive(true);
            panel.SetActive(true);
        }
    }
    //Inactive���]�b�g
    void Inactive()
    {
        Time.timeScale = 1;
        //GameStart���A�N�e�B�u�ɂ���
        GameStart.SetActive(false);
    }
    //LodeScene���]�b�g(��������)
    public void LodeScene(string scene)
    {
        Time.timeScale = 1;
        //�V�[����ǂݍ���
        SceneManager.LoadScene(scene);
        myFlagManager.GamePause = false;
        myFlagManager.GameOver = false;
        myFlagManager.GameClear = false;
    }

    //Restart���]�b�g
    public void Restart()
    {
        Time.timeScale = 1;
        //Character��gamePause��false�ɂ���
        myFlagManager.GamePause = false;
        //�e�I�u�W�F�N�g�̃A�N�e�B�r�e�B��fales�ɂ���
        GamePause.SetActive(false);
        panel.SetActive(false);
        //ReTryButton���K������
        Button retryButton = ReTryButton.GetComponent<Button>();
        //bt�𖳌�������
        retryButton.interactable = true;
    }

}
