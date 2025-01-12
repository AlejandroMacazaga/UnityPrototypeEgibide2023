﻿using StatePattern;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Entities.Player.Scripts.StatePattern.PlayerStates
{
    public class IdleState: GroundState
    {
        private ParticleEvents _particleEvents;
        public IdleState(PlayerController player) : base(player)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Player.GetRigidbody().velocity =  new Vector2( Player.GetRigidbody().velocity.x, 0);
            // Debug.Log("Entering Idle State");
            Player.animator.SetBool("IsIdle", true);
            
        }

        // per-frame logic, include condition to transition to a new state
        public override void Update()
        {
            base.Update();
            // If we're no longer grounded, transition to the air state
            if (Player.isHoldingHorizontal)
            {
                Player.PmStateMachine.TransitionTo(Player.PmStateMachine.WalkState);
                return;
            }

            if (Player.CanDash())
            {
                Player.PmStateMachine.TransitionTo(Player.PmStateMachine.GroundDashState);
                return;
            }

            if (Player.isPerformingJump)
            {
                Player.PmStateMachine.TransitionTo(Player.PmStateMachine.JumpState);
                return;
            }
            
            if (Player.isPerformingMeleeAttack)
            {
                Player.GroundAttack();
                return;
            }
            
            if (Player.CanThrowPotion())
            {
                Player.PmStateMachine.TransitionTo(Player.PmStateMachine.ThrowPotionState);
                return;
            }

            
        }
        
        public override void Exit()
        {
            base.Exit();
            Player.animator.SetBool("IsIdle", false);
            // Debug.Log("Exiting Idle State");
        }
    }
}