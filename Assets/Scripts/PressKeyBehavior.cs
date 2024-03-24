using UnityEngine;
using UnityEngine.Events;

public class PressKeyBehavior : MonoBehaviour
{
    public static UnityEvent PressE = new UnityEvent();
     
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) & PickUpBehavior.outlineCheck)
        {
            PressE?.Invoke();
        }
    }
}