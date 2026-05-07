using UnityEngine;

[RequireComponent(typeof(ShopManager))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(SpriteRenderer))]

public class Shop : MonoBehaviour
{
    private ShopManager shopManager;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // 상점 아이콘 표시
        shopManager = GetComponent<ShopManager>(); // 상점 기능
    }

    public void OpenShop()
    {
        shopManager.OpenShop();
    }
}