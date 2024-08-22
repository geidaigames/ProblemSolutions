using UnityEngine;
using UnityEngine.SceneManagement;  // シーン管理のための名前空間を追加

public class back : MonoBehaviour
{
    void Update()
    {
        // 右クリックが押された場合
        if (Input.GetMouseButtonDown(1))
        {
            // 現在のシーンを再読み込みします
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
