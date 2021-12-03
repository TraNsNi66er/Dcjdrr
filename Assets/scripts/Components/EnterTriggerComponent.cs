using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

namespace PixelCrew.Component
{
    public class EnterTriggerComponent : MonoBehaviour
    {
        [SerializeField] private string _tag;
        [SerializeField] private EnterEvent _action;
        private void OnTriggerEnter2D(Collider2D other)//проверка что ты находишься в зоне где ты умираешь 

        {
            if (other.gameObject.CompareTag(_tag))
            { 
                    _action.Invoke(other.gameObject);
            }
        }
    }
    
}