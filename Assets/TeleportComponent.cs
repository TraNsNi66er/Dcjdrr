using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew.Component
{
    public class TeleportComponent : MonoBehaviour
  {
    [SerializeField] private Transform _destTransform;

    public void Teleport(GameObject target)//компонент который будем перемещать 
    {
        target.transform.position = _destTransform.position;//телпорт по позиции   
    }

   }   
}   

 