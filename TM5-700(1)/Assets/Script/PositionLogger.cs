using UnityEngine;

public class PositionLogger : MonoBehaviour
{
    public Transform deepestChild;

    void Start()
    {
        if (deepestChild != null)
        {
            // 每 3 秒重複調用 LogPosition 方法一次
            InvokeRepeating("LogPosition", 0f, 3f);
        }
        else
        {
            Debug.LogError("Deepest child Transform is not assigned.");
        }
    }

    void LogPosition()
    {
        // 獲取最後一個 GameObject 相對於 base 的座標
        Vector3 relativePosition = transform.InverseTransformPoint(deepestChild.position);
        // 打印到控制台
        Debug.Log($"Relative Position to 'base' at {Time.time} seconds: X={relativePosition.x}, Y={relativePosition.y}, Z={relativePosition.z}");
    }

    void OnDestroy()
    {
        // 確保當腳本被銷毀時取消重複調用
        CancelInvoke("LogPosition");
    }
}
