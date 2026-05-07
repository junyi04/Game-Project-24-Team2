using UnityEngine;
using UnityEngine.InputSystem;

// 마우스를 사용해야해서 임시로 생성한 코드
// 병합 시 "삭제"해야함
// 이후 ShopIcon 감지 코드를 새로 생성해야함
public class PCforShopTest : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true; // 화면에 마우스 출력
        Cursor.lockState = CursorLockMode.Confined; // 화면에 마우스 갇힘
    }
    private void Update()
    {
        // ESC키로 마우스 갇힘 해제
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
            Cursor.lockState = CursorLockMode.None;

        // 상점 클릭
        if (Mouse.current.leftButton.wasPressedThisFrame)
            HandleShopIcon();
    }

    private void HandleShopIcon()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            if (hit.collider.TryGetComponent<Shop>(out Shop shopIcon))
            {
                shopIcon.OpenShop();
            }
        }
    }
}