using UnityEngine;

public class AxisController : MonoBehaviour
{
    public GameObject[] axisObjects = new GameObject[6];
    public Vector3[] rotationAxes = new Vector3[6];

    [Range(-180, 180)]
    public float[] sliderValues = new float[6];  // 添加 Range 屬性來使其在 Inspector 中顯示為滑塊

    void OnValidate()
    {
        // 確保 sliderValues 位於有效範圍內
        for (int i = 0; i < sliderValues.Length; i++)
        {
            sliderValues[i] = Mathf.Clamp(sliderValues[i], -180, 180);
        }
    }

    void Update()
    {
        // 更新每個軸的旋轉
        for (int i = 0; i < axisObjects.Length; i++)
        {
            if (axisObjects[i] != null)
            {
                axisObjects[i].transform.localRotation = Quaternion.Euler(rotationAxes[i] * sliderValues[i]);
            }
        }
    }
}
