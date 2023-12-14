﻿
using Entities.Player.Scripts;
using UnityEngine;

namespace StatePattern.PlayerStates
{
    public class AirState: IState
    {
        private PlayerController player;
        public AirState(PlayerController player)
        {
            this.player = player;
        }
        
        public void Enter()
        {
            //Debug.Log("Entering Air State");

            player.animator.SetBool("OnAir", true);
        }
        
        // per-frame logic, include condition to transition to a new state
        public void Update()
        {

            if (player.IsGrounded())
            {
                if(player.isHoldingHorizontal)
                    player.PmStateMachine.TransitionTo(player.PmStateMachine.WalkState);
                else
                    player.PmStateMachine.TransitionTo(player.PmStateMachine.IdleState);
                return;
            }
            
            if (player.isPerformingMeleeAttack)
            {
                player.AirAttack();
                return;
            }

            
            if (player.isPerformingDash && player.isAirDashUnlocked)
            {
                player.PmStateMachine.TransitionTo((player.PmStateMachine.AirDashStartState));
                return;
            }

            if (player.isHoldingHorizontal)
            {
                player.AirMove();
                return;
            }

        }
        
        public void Exit()
        {
            // Debug.Log("Exiting Air State");
            
            player.animator.SetBool("OnAir", false);
        }
    }
}