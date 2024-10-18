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
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(GetPointerPosition()), Vector2.zero);

        if (hit.collider != null)
        {
            //if (hit.collider.CompareTag("Screw"))
            //{
            //    hit.collider.GetComponent<Screw>().DestroyNail();
            //}
        }
    }

    public Vector2 GetPointerPosition()
    {
        return Pointer.current.position.ReadValue();
    }
}