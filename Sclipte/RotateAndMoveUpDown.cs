using UnityEngine;

public class RotateAndMoveUpDown : MonoBehaviour
{
    [SerializeField]
    private GameObject chara3D;
    [SerializeField]
    private float scale = 1.5f;
    [SerializeField]
    private int buttonNumber;
    [SerializeField]
    private Vector3 initialPosition = new Vector3(0f, 0f, 0f);
    public float rotationSpeed = 30f;   // ��]���x�i�x/�b�j
    public float moveSpeed = 1f;        // �㉺�^�����x
    public float moveDistance = 1f;     // �㉺�^���̐U��

    private void Start()
    {
        // �����ʒu�Ɉړ�
        transform.position = initialPosition;
    }
    private void Update()
    {
        // �I�u�W�F�N�g�̎��]
        RotateObject();

        // �I�u�W�F�N�g�̏㉺�^��
        MoveObjectUpDown();
    }

    private void RotateObject()
    {
        // �I�u�W�F�N�g����]������
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void MoveObjectUpDown()
    {
        // �I�u�W�F�N�g���㉺�ɓ�����
        float newYPosition = Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        transform.position = new Vector3(transform.position.x, newYPosition+initialPosition.y, transform.position.z);
    }
    public void SwitchButtonBackground(int buttonNumber)
    {
        Vector3 initialScale = chara3D.transform.localScale;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i == buttonNumber - 1)
            {
                transform.GetChild(i).Find("Background").gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(i).Find("Background").gameObject.SetActive(false);
            }
        }
    }
}