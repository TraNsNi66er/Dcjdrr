using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace PixelCrew.Component
{
public class ModifyHealthComponent : MonoBehaviour
    {
        [SerializeField] private int _hpDelta;

        public void Apply(GameObject target)//����� ������� ������ ����� �� ��� 
        {
            var healthComponent = target.GetComponent<HealthComponent>();//�� � ���� ������ ���� ��������� healtcompo
            if (healthComponent != null)//���� �������,�� ��������� �����-�� ���� �� ���� 
            {
                healthComponent.ModifyHealth(_hpDelta );
                
            }
        }
    }

}


