using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Events;
using UnityEngine;


     namespace PixelCrew.Component
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private UnityEvent _onDamage;
        [SerializeField] private UnityEvent _onHeal;
        [SerializeField] private UnityEvent _onDie;


        public void ModifyHealth(int healthDelta)
        {
            _health += healthDelta;//��������� �������� 
            if (healthDelta < 0)//���� �� ������ ��� ����� 0 �� ���������� ������ 
            {
                _onDamage?.Invoke();
            }
            if (healthDelta > 0 )// ��������� 
            {
                _onHeal?.Invoke();
            }
            if (_health <=0)
            {
                _onDie?.Invoke(); 
            }
        }
        /*public void RemoveCollider(){
            gameObject.GetComponent<Collider2D>().enabled=false;
        }*/
    }
}
