using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public string GetInteractPromp();
    public void OnInteract();
}


public class ItemObjact : MonoBehaviour , IInteractable
{
    public ItemData data;

    public string GetInteractPromp()
    {
        string str= $"{data.displayName}\n{data.description}";
        return str;
    }

    public void OnInteract()
    {
        CharacterManager.Instance.Player.itemData = data;
        CharacterManager.Instance.Player.additem?.Invoke();

        Destroy(gameObject);
    }
}
