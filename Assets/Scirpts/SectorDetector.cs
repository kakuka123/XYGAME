using UnityEngine;

public class SectorDetector : MonoBehaviour
{
    public SectorPreview sectorPreview; // 扇形预览脚本的引用

    public bool isInsideSector = false; // 角色是否在扇形区域内

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isInsideSector)
        {
            isInsideSector = true;
            Debug.Log("进入扇形区域");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isInsideSector)
        {
            isInsideSector = false;
            Debug.Log("离开扇形区域");
        }
    }

    private void OnDrawGizmos()
    {
        if (sectorPreview != null)
        {
            Gizmos.color = isInsideSector ? Color.green : Color.red;
            Gizmos.DrawWireSphere(transform.position, sectorPreview.radius);
        }
    }
}
