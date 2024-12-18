using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 2.0f; // �}�E�X���x

    void Update()
    {
        // �}�E�X�̓��͂��擾
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // �J�����̉�]���v�Z�i�v���C���[�̌����Ɉˑ����Ȃ��j
        transform.Rotate(Vector3.up * mouseX * sensitivity);
        transform.Rotate(Vector3.left * mouseY * sensitivity);

        // �J�����̏㉺�̉�]�𐧌�
        float xRotation = transform.rotation.eulerAngles.x;
        transform.rotation = Quaternion.Euler(new Vector3(Mathf.Clamp(xRotation, -90f, 90f), transform.rotation.eulerAngles.y, 0f));
    }
}
