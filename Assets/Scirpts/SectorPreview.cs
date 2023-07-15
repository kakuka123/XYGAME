using UnityEditor;
using UnityEngine;

public class SectorPreview : MonoBehaviour
{
    public float radius = 1f;
    public float angle = 90f;
    public int segments = 36;
    public Transform targetBone; // 目标骨骼

    private void OnDrawGizmos()
    {
        // 获取目标骨骼的Y轴旋转角度
        float targetRotationY = targetBone != null ? targetBone.eulerAngles.y : 0f;

        // 设置扇形的旋转角度
        transform.eulerAngles = new Vector3(0f, targetRotationY + 36f, 0f);

        // 绘制扇形
        Gizmos.color = Color.red;

        // 计算扇形的起始角度和结束角度
        float startAngle = -angle / 2f;
        float endAngle = angle / 2f;

        // 计算每个扇形片段的角度增量
        float angleIncrement = (endAngle - startAngle) / segments;

        // 绘制扇形
        Vector3 center = transform.position;
        Vector3 forward = transform.forward;
        Vector3 startDir = Quaternion.Euler(0f, startAngle, 0f) * forward;

        for (int i = 0; i <= segments; i++)
        {
            // 计算当前扇形片段的角度
            float currentAngle = startAngle + (i * angleIncrement);

            // 计算当前点的位置
            Vector3 currentDir = Quaternion.Euler(0f, currentAngle, 0f) * startDir;
            Vector3 currentPosition = center + (currentDir * radius);

            // 绘制线段连接相邻点
            if (i > 0)
            {
                Vector3 previousDir =
                    Quaternion.Euler(0f, currentAngle - angleIncrement, 0f) * startDir;
                Vector3 previousPosition = center + (previousDir * radius);
                Gizmos.DrawLine(previousPosition, currentPosition);
            }

            // 绘制线段连接中心点和当前点
            Gizmos.DrawLine(center, currentPosition);
        }
    }
}
