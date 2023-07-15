using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public SectorDetector sectorDetector; // 扇形区域检测器脚本的引用
    public Transform escapeTarget; // 逃跑目标点的引用
    public float escapeSpeed = 5f; // 逃跑速度

    private bool isPlayerInsideSector = false; // 角色是否在扇形区域内
    private Rigidbody rb; // 敌人的刚体组件

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isPlayerInsideSector)
        {
            Escape();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInsideSector = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInsideSector = false;
        }
    }

    private void Escape()
    {
        // 计算敌人到逃跑目标点的方向
        Vector3 direction = (escapeTarget.position - transform.position).normalized;

        // 施加力使敌人移动到逃跑目标点
        rb.velocity = direction * escapeSpeed;
    }
}
