using UnityEngine;
using UnityEngine.SceneManagement;

public class IdleReset : MonoBehaviour
{
    public float idleTimeLimit = 120f; // 2���̃��~�b�g
    private float idleTimer = 0f;

    void Start()
    {
        // ������
        ResetTimer();
    }

    void Update()
    {
        // �^�C�}�[�̍X�V
        idleTimer += Time.deltaTime;

        // ���͂�����΃^�C�}�[�����Z�b�g
        if (Input.anyKey || Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            ResetTimer();
        }

        // �^�C�}�[�����~�b�g�𒴂����ꍇ�A�V�[���������[�h
        if (idleTimer >= idleTimeLimit)
        {
            ReloadScene();
        }
    }

    void ResetTimer()
    {
        idleTimer = 0f;
    }

    void ReloadScene()
    {
        // ���݂̃V�[���������[�h
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
