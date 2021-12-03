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
        private void OnCollisionEnter2D(Collision2D other)//чекает коллизию столкновение двух физ лиц 
        {
            if (other.gameObject.CompareTag(_tag))//если мы столкнулись с объектом определенного таг 
            {
                _action?.Invoke(other.gameObject);//вызывается ивент какой-то 
            }
        }
       
    } 
    [Serializable]
        public class  EnterEvent:UnityEvent<GameObject>//в этот ивент мы передам то с кем мы столкнулись 
            {    
            }

}