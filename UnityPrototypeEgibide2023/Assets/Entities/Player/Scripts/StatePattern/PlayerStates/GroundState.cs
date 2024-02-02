﻿using StatePattern;

namespace Entities.Player.Scripts.StatePattern.PlayerStates
{
    public class GroundState : IState
    {
        protected PlayerController Player;

        protected GroundState(PlayerController player)
        {
            this.Player = player;
        }
        
        public virtual void Enter()
        {
            Player.GetRigidbody().drag = 5;
        }

        public virtual void Update()
        {
            if (!Player.IsGrounded())
            {
                Player.PmStateMachine.TransitionTo(Player.PmStateMachine.AirborneState);
                return;
            }
        }

        public virtual void Exit()
        {
            
        }
    }
}