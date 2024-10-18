using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private void Update()
    {
        // Dokunma ilk kez bu frame'de ba�lad�ysa
        if (Pointer.current != null && Pointer.current.press.wasPressedThisFrame/* && !EventSystem.current.IsPointerOverGameObject()*/)
        {
            OnClicked();
        }
    }

    private void OnClicked()
    {
        // Raycast olu�tur ve dokundu�un yerden at
        Ray ray = Camera.main.ScreenPointToRay(GetPointerPosition());

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Character"))
            {
                hit.collider.GetComponent<Character>().StartMoveToTarget();
            }
        }
    }

    public Vector2 GetPointerPosition()
    {
        return Pointer.current.position.ReadValue();
    }
}