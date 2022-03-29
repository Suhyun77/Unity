using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }


    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))  // spacebar 누를 경우 아래 코드 출력
        {
            // float force = 5f;
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime); // 3D 게임이므로 Vector3 (x, y, z) 입력 / x 1유닛, y 1유닛, z 1유닛씩 이동해서 특정 각도로 이동 
        }
    }


    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))  // A 입력받을 경우 
        {
            ApplyRotation(rotationThrust);  // Z값 넘김
        }

        // else if : 위 조건이 만족되지 않을시 이 특정 조건이 실행됨 
        else if (Input.GetKey(KeyCode.D))  // D 입력받을 경우  
        {
            ApplyRotation(-rotationThrust); // -Z값 넘김
        }
     }

     void ApplyRotation(float rotationThisFrame)
     {
         rb.freezeRotation = true; // freezing rotation so we can manually rotate
         transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime); // 수동 제어 : 강제로 특정 방향으로 회전하라고 지시
         rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
     }
}