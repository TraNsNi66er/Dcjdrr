using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew.Component
{
    public class SwitchComponent : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private bool _state;
        [SerializeField]  private string _animatorKey;


        public void Switch()
        {
            _state = !_state;
            _animator.SetBool(_animatorKey, _state);//анимирование для двери 
        }
        [ContextMenu("Switch")]//для отладки  
        public void SwitchIt()
        {
            Switch();
        }
        

    }

}

