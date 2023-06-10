using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementHandler : MonoBehaviour
{
    [Header("Follow target")]
    [SerializeField] private GameObject _cameraTarget;
    [SerializeField] private float _threshold = 0.1f;
    [SerializeField] private float _maxLookingTop = 80f;
    [SerializeField] private float _maxLookingDown = -30f;

    private Vector3 _rotationVector3;
    private float _cameraYaw;
    private float _cameraPitch;

    private void Start()
    {
        _cameraYaw = _cameraTarget.transform.eulerAngles.y;
    }

    private void LateUpdate()
    {
        CameraRotation();
    }
    
    private void CameraRotation()
    {
        Vector2 lookingInput = InputManager.Instance.Looking;

        if (lookingInput.sqrMagnitude > _threshold)
        {

            _cameraYaw += lookingInput.x;
            _cameraPitch += lookingInput.y;
        }

        _cameraYaw = ClampAngle(_cameraYaw, float.MinValue, float.MaxValue);
        _cameraPitch = ClampAngle(_cameraPitch, _maxLookingDown, _maxLookingTop);

        _cameraTarget.transform.rotation = Quaternion.Euler(_cameraPitch, _cameraYaw, 0f);

    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f) angle += 360f;
        else if (angle > 360f) angle -= 360f;

        angle = Mathf.Clamp(angle, min, max);
        return angle;
    }
}
