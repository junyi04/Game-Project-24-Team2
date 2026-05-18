using UnityEngine;
using System;

public class Money : MonoBehaviour
{
    public static event Action<float> OnMoneyChanged;
    public static float currentMoney = 50000f;

    private void OnEnable()
    {
        ShopPurchaseHandler.OnItemPurchased += HandleItemPurchased;
    }

    private void OnDisable()
    {
        ShopPurchaseHandler.OnItemPurchased -= HandleItemPurchased;
    }

    private void HandleItemPurchased(Item item)
    {
        currentMoney -= item.Price;
        OnMoneyChanged?.Invoke(currentMoney);
    }
}