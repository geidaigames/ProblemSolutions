using UnityEngine;
using UnityEngine.SceneManagement;  // �V�[���Ǘ��̂��߂̖��O��Ԃ�ǉ�

public class back : MonoBehaviour
{
    void Update()
    {
        // �E�N���b�N�������ꂽ�ꍇ
        if (Input.GetMouseButtonDown(1))
        {
            // ���݂̃V�[�����ēǂݍ��݂��܂�
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
