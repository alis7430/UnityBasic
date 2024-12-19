using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private readonly float LayCastDist = 100f;
    private readonly float RotationDelta = 0.2f;

    [SerializeField]
    private float _speed = 1f;

    private bool _moveToDest = false;
    private Vector3 _destPos = Vector3.zero;

    private void Start()
    {
        Managers.input.KeyAction -= OnKeyboard;
        Managers.input.KeyAction += OnKeyboard;
        Managers.input.MouseAction -= OnMouseClicked;
        Managers.input.MouseAction += OnMouseClicked;
    }

    private void Update()
    {
        if (!_moveToDest) return;

        Vector3 dir = _destPos - transform.position;

        if (dir.magnitude < 0.0001f)
        {
            _moveToDest = false;
        }
        else
        {
            float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);
            transform.position += dir.normalized * moveDist;
            transform.LookAt(_destPos);
        }
    }

    private void OnKeyboard()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), RotationDelta);
            transform.position += Vector3.forward * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), RotationDelta);
            transform.position += Vector3.left * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), RotationDelta);
            transform.position += Vector3.right * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), RotationDelta);
            transform.position += Vector3.back * Time.deltaTime * _speed;
        }
    }

    private void OnMouseClicked(Define.MouseEvent evt)
    {
        if (evt != Define.MouseEvent.Click) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * LayCastDist, Color.red, 1f);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, LayCastDist, LayerMask.GetMask("Wall")))
        {
            _destPos = hit.point;
            _moveToDest = true;
        }
    }
}
