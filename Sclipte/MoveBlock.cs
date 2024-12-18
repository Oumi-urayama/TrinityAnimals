using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    [Header("�ړ��ɂ����鎞��"), SerializeField]
    public float duration = 2f; // �ړ��ɂ����鎞�ԁi�b�j

    [Header("�ړ����鋗��"), SerializeField]
    public float distance = 5f; // �ړ����鋗��

    float speed; // �ړ��̑����i���b�̈ړ������j

    [SerializeField]
    public bool moveX = true; // X���Ɉړ����邩�ǂ���
    [SerializeField]
    public bool moveY = true; // Y���Ɉړ����邩�ǂ���
    [SerializeField]
    public bool moveZ = true; // Z���Ɉړ����邩�ǂ���

    private Vector3 initialPosition;
    private float startTime;

    [SerializeField]
    private bool isPlayerOn = false;

    void Start()
    {
        initialPosition = transform.position;
        startTime = Time.time;
        speed = distance / duration;
    }

    void FixedUpdate()
    {
        float distanceCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distanceCovered / distance;

        Vector3 newPosition = initialPosition;

        if (moveX)
            newPosition.x += Mathf.PingPong(fractionOfJourney, 1f) * distance * 2f - distance;
        if (moveY)
            newPosition.y += Mathf.PingPong(fractionOfJourney, 1f) * distance * 2f - distance;
        if (moveZ)
            newPosition.z += Mathf.PingPong(fractionOfJourney, 1f) * distance * 2f - distance;

        transform.position = newPosition;
    }

    public void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isPlayerOn)
            {
                collision.transform.parent = this.gameObject.transform;
            }
        }
    }
    public void OnCollisionExit(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isPlayerOn)
            {
                collision.transform.parent = null;
            }
        }
    }

}
