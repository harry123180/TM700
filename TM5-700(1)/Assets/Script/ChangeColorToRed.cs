using UnityEngine;

public class ChangeColorToRed : MonoBehaviour
{
    void Start()
    {
        // 設定顏色為紅色
        Color redColor = Color.blue;

        // 尋找並變更所有軸的顏色
        ChangeChildrenColor(transform, redColor);
    }

    // 遞迴函數來變更所有子物件的顏色
    void ChangeChildrenColor(Transform parent, Color color)
    {
        foreach (Transform child in parent)
        {
            // 嘗試獲取 Renderer 組件
            Renderer renderer = child.GetComponent<Renderer>();
            if (renderer != null)
            {
                // 如果有 Renderer 組件，設定它的顏色
                renderer.material.color = color;
            }

            // 遞迴調用自身來處理所有子物件
            ChangeChildrenColor(child, color);
        }
    }
}
