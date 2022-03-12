using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
   private void OnCollisionEnter(Collision other) 
   {  
        if(other.gameObject.tag == "Player")
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            gameObject.tag = "Hit";
            //앞에 아무것도 명시하지 않았으므로 이 스크립트가 부착된 게임 개체에 적용됨
            //해당 개체가 부딪힐 경우 tag가 Hit로 바뀜
        }
   }
}

