using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Script
{
    public class PlayerControllerVN : MonoBehaviour
    {
        private PlayerInputActionVN playerInput;
        private Vector2 moveInput;

        [SerializeField] private float moveSpeed;
        [SerializeField] private Rigidbody rb;
        
        
        private void OnEnable()
        {
            playerInput = new PlayerInputActionVN();
            
            playerInput.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
            playerInput.Player.Move.canceled += _ => moveInput = Vector2.zero;
            playerInput.Enable();
        }

        private void OnDisable()
        {
            playerInput.Dispose();
            playerInput.Disable();
        }

        private void Update()
        {
            if (moveInput != Vector2.zero)
            {
                rb.linearVelocity = new Vector3(moveInput.x,moveInput.y,0).normalized * Time.deltaTime * moveSpeed;
            }
            else
            {
                rb.linearVelocity = Vector3.zero;
            }
            
        }
        
    }
}
