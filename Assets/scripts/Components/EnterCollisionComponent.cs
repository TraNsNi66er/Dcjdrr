using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

 namespace PixelCrew.Component
{
    public class EnterCollisionComponent : MonoBehaviour
    {

        [SerializeField] private string _tag;
        [SerializeField] private UnityEvent<GameObject> _action;
        private void OnCollisionEnter2D(Collision2D other)//������ �������� ������������ ���� ��� ��� 
        {
            if (other.gameObject.CompareTag(_tag))//���� �� ����������� � �������� ������������� ��� 
            {
                _action?.Invoke(other.gameObject);//���������� ����� �����-�� 
            }
        }
       
    } 
    [Serializable]
        public class  EnterEvent:UnityEvent<GameObject>//� ���� ����� �� ������� �� � ��� �� ����������� 
            {    
            }

}