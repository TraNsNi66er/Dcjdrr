using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PixelCrew {
    public class HeroInputReader : MonoBehaviour
    {
        [SerializeField] private Hero _hero;

        private void OnHorizontalMovement(InputAction.CallbackContext context)//��������� ������ � ������ ������� ����� HeroInputAction
        {
            var direction = context.ReadValue<Vector2>();
            _hero.SetDirection(direction);
        }
        private void OnSaySomething(InputAction.CallbackContext context)
        {
            if(context.canceled)  
            { 

             _hero.SaySomething();

            }
            
        }
        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.canceled)
            {
               _hero.Interact();
            }
        }
    } 
}
