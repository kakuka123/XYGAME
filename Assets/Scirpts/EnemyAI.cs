using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform targetObject; // 目标位置
    public SectorDetector sectorDetector; // 扇形检测器脚本的引用
    public Animator enemyAnimator; // 敌人的动画控制器

    public float moveSpeed = 5f; // 敌人的移动速度

    private bool isEscaping = false; // 是否正在逃跑
    private Rigidbody enemyRigidbody; // 敌人的刚体组件

    private void Awake()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
        enemyRigidbody.isKinematic = true; // 设置为非运动状态（Kinematic）
    }

    private void Update()
    {
        if (isEscaping)
        {
            Escape();
        }
    }

    private void Escape()
    {
        Vector3 escapeDirection = targetObject.position - transform.position;
        Vector3 moveDirection = escapeDirection.normalized * moveSpeed * Time.deltaTime;

        // 保持垂直方向不受影响
        moveDirection.y = 0f;

        transform.position += moveDirection;

        enemyAnimator.SetBool("IsEscape", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !sectorDetector.isInsideSector)
        {
            StartEscape();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopEscape();
        }
    }

    private void StartEscape()
    {
        if (!isEscaping)
        {
            isEscaping = true;
            Debug.Log("敌人逃跑");
        }
    }

    private void StopEscape()
    {
        if (isEscaping)
        {
            isEscaping = false;
            enemyAnimator.SetBool("IsEscape", false);
            Debug.Log("停止逃跑");
        }
    }
}
