using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using UnityEngine;

public class JumpTrap : MonoBehaviour
{
   [SerializeField] private float jumpForece ;
   [SerializeField]private int playerLayer;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.name}이 트랩에 닿음");
        if (other.gameObject.layer == playerLayer)
        {
            Debug.Log("플레이어감지");
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = new Vector3(rb.velocity.x,0, rb.velocity.z);
                rb.AddForce(Vector3.up * jumpForece , ForceMode.Impulse);
                Debug.Log("Jump");
            }
        }

    }
}
