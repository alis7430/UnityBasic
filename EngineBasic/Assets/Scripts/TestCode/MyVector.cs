using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Unity vector copy
/// </summary>
struct MyVector
{
    public float x;
    public float y;
    public float z;

    public MyVector(float x, float y, float z) { this.x = x; this.y = y; this.z = z; }

    public float magnitude { get { return Mathf.Sqrt(x * x + y * y + z * z); } }
    public MyVector normalized { get { return new MyVector(x / magnitude, y / magnitude, z / magnitude); } }

    public static MyVector operator +(MyVector lhs, MyVector rhs)
    {
        return new MyVector(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
    }

    public static MyVector operator -(MyVector lhs, MyVector rhs)
    {
        return new MyVector(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
    }

    public static MyVector operator *(MyVector a, float d)
    {
        return new MyVector(a.x * d, a.y * d, a.z * d);
    }
}


//public class Player : MonoBehaviour
//{
//    [SerializeField] float Speed = 1f;

//    void Start()
//    {
//        MyVector to = new MyVector(10f, 0, 0);
//        MyVector from = new MyVector(5f, 0, 0);
//        MyVector dir = to - from;

//        dir = dir.normalized;

//        MyVector newPos = from + dir * Speed;
//    }

//    void Update()
//    {
//        if (Input.GetKey(KeyCode.W))
//        {
//            // transform.Translate(Vector3.forward * Time.deltaTime * Speed);
//            // transform.rotation = Quaternion.LookRotation(Vector3.forward);
//            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
//        }
//        if (Input.GetKey(KeyCode.A))
//        {
//            // transform.Translate(Vector3.left * Time.deltaTime * Speed);
//            // transform.rotation = Quaternion.LookRotation(Vector3.left);
//            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
//        }
//        if (Input.GetKey(KeyCode.D))
//        {
//            // transform.Translate(Vector3.right * Time.deltaTime * Speed);
//            // transform.rotation = Quaternion.LookRotation(Vector3.right);
//            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
//        }
//        if (Input.GetKey(KeyCode.S))
//        {
//            // transform.Translate(Vector3.back * Time.deltaTime * Speed);
//            // transform.rotation = Quaternion.LookRotation(Vector3.back);
//            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
//        }
//    }
//}