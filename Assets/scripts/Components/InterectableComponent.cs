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
            _action?.Invoke(); //�� ������� ������ ������� ��������� � ���������� switch � ������� ��� ����� 
        }
    }

}


