using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class ShopPurchaseHandler : MonoBehaviour
{
    private TextMeshProUGUI moneyText;

    private int startingMoney = 50000;
    private int currentMoney;

    private AudioSource audioSource;
    private AudioClip purchaseCompleteSound;
    private AudioClip purchaseFailSound;

    private void Awake()
    {
        currentMoney = startingMoney;

        audioSource = GetComponent<AudioSource>();
        purchaseCompleteSound = Resources.Load<AudioClip>("Shop/ShopPurchaseCompleteSound1");
        purchaseFailSound = Resources.Load<AudioClip>("Shop/ShopPurchaseFailSound1");
    }

    public void SetMoneyText(TextMeshProUGUI ui)
    {
        moneyText = ui;
        UpdateMoneyUI(); // 초기 UI 업데이트
    }

    public void UpdateMoneyUI()
    {
        moneyText.text = $"보유금액 : {currentMoney}원";
    }

    public void TryPurchase(Item item)
    {
        if (currentMoney >= item.Price)
        {
            currentMoney -= item.Price;
            UpdateMoneyUI();

            Debug.Log($"{item.ItemName} 구매 성공! -{item.Price}원");
            audioSource.PlayOneShot(purchaseCompleteSound);
            // 인벤토리에 Item 추가 로직 구현 예정
        }
        else
        {
            Debug.LogWarning($"금액 부족! 현재 금액: {currentMoney}원 | 필요: {item.Price}원");
            audioSource.PlayOneShot(purchaseFailSound);
            // 금액 부족 팝업 메뉴 구현 예정
        }
    }
}