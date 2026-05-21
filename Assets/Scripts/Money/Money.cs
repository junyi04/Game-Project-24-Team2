using UnityEngine;
using System;

public class Money : MonoBehaviour
{
    public static event Action<float> OnMoneyChanged;
    public static float currentMoney = 50000f;

    private void OnEnable()
    {
        ShopPurchaseHandler.OnItemPurchased += HandleItemPurchased;
        Pot.OnMushroomReaped += HandleMushroomReaped;
    }

    private void OnDisable()
    {
        ShopPurchaseHandler.OnItemPurchased -= HandleItemPurchased;
        Pot.OnMushroomReaped -= HandleMushroomReaped;
    }

    private void HandleItemPurchased(Item item)
    {
        currentMoney -= item.Price;
        OnMoneyChanged?.Invoke(currentMoney);
    }

    private void HandleMushroomReaped()
    {
        currentMoney += 500f;
        OnMoneyChanged?.Invoke(currentMoney);
    }
}