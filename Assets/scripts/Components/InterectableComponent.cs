using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace PixelCrew.Component
{
    public class InterectableComponent : MonoBehaviour
    {
        [SerializeField] private UnityEvent _action;

        public void Interact()
        {
            _action?.Invoke(); //он дергает список методов указанных в компоненте switch и октроет нам дверь 
        }
    }

}


