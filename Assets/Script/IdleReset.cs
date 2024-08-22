using UnityEngine;
using UnityEngine.SceneManagement;

public class IdleReset : MonoBehaviour
{
    public float idleTimeLimit = 120f; // 2分のリミット
    private float idleTimer = 0f;

    void Start()
    {
        // 初期化
        ResetTimer();
    }

    void Update()
    {
        // タイマーの更新
        idleTimer += Time.deltaTime;

        // 入力があればタイマーをリセット
        if (Input.anyKey || Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            ResetTimer();
        }

        // タイマーがリミットを超えた場合、シーンをリロード
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
        // 現在のシーンをリロード
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
