using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IDamagalbe
{
    void TakePhysicalDamage(int damage);
}
public class PlayerCondition : MonoBehaviour , IDamagalbe 
{
    public UICondition uiCondition;
    public PlayerController playerController;

    Condition health { get { return uiCondition.health; } }
    CharacterManager movespeed { get { return movespeed; } }

    public event Action onTakeDamage;

    void Update()
    {

        if(health.curValue <= 0f)
        {
            Die();
        }
    }

    public void Heal(float amout)
    {
        health.Add(amout);
    }

    public void Buff(float speed)
    {
        CharacterManager.Instance.Player.controller.moveSpeed += speed;

        Invoke("RemoveBuff", 5f);
        
    }
    public void Die()
    {
        Debug.Log("죽었다 ");
    }

    public void TakePhysicalDamage(int damage)
    {
        health.Subtract(damage);
        onTakeDamage?.Invoke();
    }

    public void RemoveBuff(float speed)
    {
        CharacterManager.Instance.Player.controller.moveSpeed -= speed;
        Debug.Log("버프끝");
    }
}
