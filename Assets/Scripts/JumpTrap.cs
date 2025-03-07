using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using UnityEngine;

public class JumpTrap : MonoBehaviour
{
   [SerializeField] private float jumpForece ;
    private int playerLayer = 6;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.name}�� Ʈ���� ����");
        if (other.gameObject.layer == playerLayer)
        {
            Debug.Log("�÷��̾��");
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
