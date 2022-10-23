using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    CharacterController cc;
    public float speed = 5f;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

     void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        
        if (dir.magnitude > 0.1f)
        {
             float faceAngle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
             Quaternion targetRotation = Quaternion.Euler(-90, faceAngle, 180);
             transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.3f);
        }
        
        Vector3 move = dir * speed;
        
        if (!cc.isGrounded)
        {
            move.y = -9.8f * 30 * Time.deltaTime;
        }
	
        cc.Move( move * speed * Time.deltaTime );
    }

}
