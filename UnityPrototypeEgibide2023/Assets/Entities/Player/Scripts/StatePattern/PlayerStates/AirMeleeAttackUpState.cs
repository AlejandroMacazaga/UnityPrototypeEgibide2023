﻿using StatePattern;
using UnityEngine;

namespace Entities.Player.Scripts.StatePattern.PlayerStates
{
    public class AirMeleeAttackUpState : AttackState
    {
        public AirMeleeAttackUpState(PlayerController player) : base(player)
        {
            AttackDirection = new Vector2(0, 1);
            KnockbackMultiplier = 1.5f;
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Entering Air Up Attack State");

            Player.isInMiddleOfAirAttack = true;
            Player.animator.SetBool("IsAAUp", true);
            Player.InvokeRepeating(nameof(Player.AirMove), 0, 0.01f);
            Player.Invoke(nameof(Player.EndAirAttack), 0.8f);
        }

        // per-frame logic, include condition to transition to a new state
        public override void Update()
        {     
            base.Update();
            if (!Player.isInMiddleOfAirAttack)
            {
                Player.PmStateMachine.TransitionTo(Player.PmStateMachine.AirState);
                return;
            }
            if (Player.IsGrounded()) {
                Player.PmStateMachine.TransitionTo(Player.PmStateMachine.IdleState);
                return;
            }
        }
        
        public override void Exit()
        {
            base.Exit();
            Player.CancelInvoke(nameof(Player.AirMove));
            Player.CancelInvoke(nameof(Player.EndAirAttack));
            Player.animator.SetBool("IsAAUp", false);
            Player.canAttack = true;
            Player.isInMiddleOfAirAttack = false;

            Debug.Log("Exiting Air Up Attack State");
        }
    }
}
