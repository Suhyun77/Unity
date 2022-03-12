using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    MeshRenderer renderer;
    Rigidbody rigidbody;
    [SerializeField] float timeToWait = 5f;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>(); // 참조 캐싱
        //캐싱 : 자주 사용되는 데이터나 정보를 필요할 때 쉽게 접근할 수 있도록 메모리에 저장하는 기술
        rigidbody = GetComponent<Rigidbody>();

        renderer.enabled = false; // 떨어지는 오브젝트의 Mesh Renderer 해제 (보이지 않도록 함)
        rigidbody.useGravity = false; // 중력 사용 해제    
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeToWait)
        {
            renderer.enabled = true; // 떨어지는 오브젝트의 Mesh Renderer ON (보이도록 함)
            rigidbody.useGravity = true; // 중력 사용 
        }
    }
}
