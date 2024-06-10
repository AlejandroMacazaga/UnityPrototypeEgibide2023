using Entities;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Enviroment.Scripts
{
    public class ActivationSwitch : EntityControler
    {
        [SerializeField] private float activeTime = 0.5f;
        [SerializeField] private GameObject _gate2D;
        [SerializeField] private GameObject _gate3D;
        private static readonly int IsAbierta = Animator.StringToHash("IsAbierta");
        private static readonly int IsCerrada = Animator.StringToHash("IsCerrada");
        private static readonly int On = Animator.StringToHash("On");
        private void Start()
        {
            InvulnerableTime = activeTime;
        }
        public override void OnReceiveDamage(AttackComponent.AttackData attack, bool toTheRight = true)
        { 
            if (Invulnerable) return;
            Invulnerable = true;
            Invoke(nameof(EndInvulnerability), InvulnerableTime);
            if (TryGetComponent<Animator>(out var animator))
            {
                animator.SetBool(On, true);
            }
            _gate2D.SetActive(false);
            _gate3D.GetComponent<Animator>().SetBool(IsAbierta, true);
            _gate3D.GetComponent<Animator>().SetBool(IsCerrada, false);
        }
        
        public override void EndInvulnerability()
        {
            Invulnerable = false;
            CloseGateAnim();
        }
        
        private void CloseGateAnim()
        {
            _gate2D.SetActive(true);
            if (TryGetComponent<Animator>(out var animator))
            {
                animator.SetBool(On, false);
            }
            _gate3D.GetComponent<Animator>().SetBool(IsCerrada, true);
            _gate3D.GetComponent<Animator>().SetBool(IsAbierta, false);
        }
    }
}
