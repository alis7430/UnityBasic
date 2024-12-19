using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Define.CameraMode _mode = Define.CameraMode.QuaterView;
    [SerializeField] Vector3 _delta = new Vector3(0f, 6f, -5f);
    [SerializeField] GameObject _target = null;

    private void LateUpdate()
    {
        if (_mode == Define.CameraMode.QuaterView)
        {
            FollowTarget();
        }
    }

    public void SetQuaterView(Vector3 delta)
    {
        _mode = Define.CameraMode.QuaterView;
        _delta = delta;
    }

    private void FollowTarget()
    {
        if (_target != null)
        {
            RaycastHit hit;
            if (Physics.Raycast(_target.transform.position, _delta, out hit, _delta.magnitude, LayerMask.GetMask("Wall")))
            {
                float dist = (hit.point - _target.transform.position).magnitude * 0.8f;
                transform.position = _target.transform.position + _delta.normalized * dist;
            }
            else
            {
                transform.position = _target.transform.position + _delta;
                transform.LookAt(_target.transform);
            }
        }
    }
}
