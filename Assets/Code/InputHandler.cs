using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private void Update()
    {
        // Dokunma ilk kez bu frame'de baþladýysa
        if (Pointer.current != null && Pointer.current.press.wasPressedThisFrame/* && !EventSystem.current.IsPointerOverGameObject()*/)
        {
            OnClicked();
        }
    }

    private void OnClicked()
    {
        // Raycast oluþtur ve dokunduðun yerden at
        Ray ray = Camera.main.ScreenPointToRay(GetPointerPosition());

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Character"))
            {
                Debug.Log("Karaktere týklandý");
            }
        }
    }

    public Vector2 GetPointerPosition()
    {
        return Pointer.current.position.ReadValue();
    }
}