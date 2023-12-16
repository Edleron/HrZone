using UnityEngine;
using UnityEngine.AI;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public float distanceMin = 5f;
    public float distanceMax = 15f;
    public bool isTargetLeft = false;

    private NavMeshAgent targetAgent;
    private Vector3 lastPosition;

    private void Start()
    {
        targetAgent = target.GetComponent<NavMeshAgent>();
        lastPosition = target.position;
    }

    private void LateUpdate()
    {
        if (Vector3.Distance(lastPosition, target.position) > 0.01f) // Karakter hareket ettiğinde güncelle
        {
            Vector3 adjustedOffset = isTargetLeft ? new Vector3(-Mathf.Abs(offset.x), offset.y, offset.z) : offset;
            Vector3 desiredPosition = target.position + adjustedOffset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;

            Quaternion lookRotation = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, smoothSpeed * Time.deltaTime);

            lastPosition = target.position;
        }
    }
}
