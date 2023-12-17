using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CameraFollow : MonoBehaviour
{
    public List<Transform> Test = new List<Transform>();
    public Transform target;
    private Transform originalTarget;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public bool isCameraLocked = false;

    private void OnEnable()
    {
        EventManager.onGameTriggerEnter += SetTargetEnter;
        EventManager.onGameTriggerExit += SetTargetExit;
    }

    private void OnDisable()
    {
        EventManager.onGameTriggerEnter -= SetTargetEnter;
        EventManager.onGameTriggerExit -= SetTargetExit;
    }

    private void LateUpdate()
    {
        if (target == null /*|| isCameraLocked*/) return;

        UpdateCameraPosition();
    }

    private void UpdateCameraPosition()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        transform.LookAt(target.position);
    }

    private void SetTargetEnter(string name)
    {
        offset = new Vector3(0, 2, 1);
        smoothSpeed = 0.25f;
        GameObject newTarget = GameObject.Find(name);
        if (newTarget != null)
        {
            Debug.Log(newTarget.name);
            switch (newTarget.name)
            {
                case "MiniLevelGame-1":
                    originalTarget = target;
                    // target = newTarget.transform;
                    target = Test[0].transform;
                    break;
            }
            // isCameraLocked = true;
            UpdateCameraPosition();
        }
    }

    private void SetTargetExit(string name)
    {
        offset = new Vector3(0, 7.5f, 10);
         smoothSpeed = 0.125f;
        if (originalTarget != null)
        {
            target = originalTarget;
            // isCameraLocked = false;
            UpdateCameraPosition();
        }
    }
}
