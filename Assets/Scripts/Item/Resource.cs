using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Resource : MonoBehaviour
{
    public ItemData itemToGive; //����Ǵ¾�����
    public int quantityperhit = 1; // 
    public int capacity; // �� ����������ִ��� 

    public float respawnTime;
    public Vector3 respawnArea;
    public void Gather(Vector3 hitPoint , Vector3 hitNormal)
    {
        for (int i = 0; i < quantityperhit; i++) 
        {
            if (capacity <= 0)
            {
                DestroyResource();
                break;
            }

            capacity -= 1;
            Instantiate(itemToGive.dropPrefab, hitPoint + Vector3.up, Quaternion.LookRotation(hitNormal, Vector3.up));
        }
    }

    void DestroyResource()
    {
        gameObject.SetActive(false);
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        if (capacity <=1)// �ٸ�������Ʈ�� ���������
        {
            yield break;
        }
        yield return new WaitForSeconds(respawnTime);

        
        gameObject.SetActive(true);
    }
}
