using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Joystick Referansı")]
    public Joystick joystick;

    [Header("Oyuncu Ayarları")]
    [SerializeField] private float hareketHizi = 5.0f;
    
    private CharacterController controller;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float yatayInput = joystick.Horizontal;
        float dikeyInput = joystick.Vertical;

        Vector3 horizontalMove = new Vector3(yatayInput, 0, dikeyInput).normalized;
        
        if (horizontalMove.magnitude >= 0.1f)
        {
            controller.Move(horizontalMove * hareketHizi * Time.deltaTime);
        }
    }
}