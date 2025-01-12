using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Entities.Player.Scripts;
using Entities.Player.Scripts.StatePattern.PlayerStates;
using UnityEngine;

namespace StatePattern
{
    [Serializable]
    public class PlayerMovementStateMachine : IStateMachine
    {
        public IState CurrentState { get; private set; }
        public IState LastState { get; private set; }
        // Event to notify other objects that state has changed
        public event Action<IState> OnStateChanged;

        // We add all possible states here
        public IdleState IdleState;
        public WalkState WalkState;
        public AirborneState AirborneState;
        public GroundDashState GroundDashState;
        public JumpState JumpState;
        public AirDashState AirDashState;
        public AirDashStartState AirDashStartState;
        public MeleeAttackRightState MeleeAttackRightState;
        public MeleeAttackLeftState MeleeAttackLeftState;
        public MeleeAttackUpState MeleeAttackUpState;
        public AirMeleeAttackForwardState AirMeleeAttackForwardState;
        public AirMeleeAttackBackwardState AirMeleeAttackBackwardState;
        public AirMeleeAttackUpState AirMeleeAttackUpState;
        public AirMeleeAttackDownState AirMeleeAttackDownState;
        public ThrowPotionState ThrowPotionState;
        public AirThrowPotionState AirThrowPotionState;
        public StunnedState StunnedState;
        public SceneChangeState SceneChangeState;
        public DeathState DeathState;
        
        // Constructor
        public PlayerMovementStateMachine(PlayerController player)
        {
            this.IdleState = new IdleState(player);
            this.WalkState = new WalkState(player);
            this.AirborneState = new AirborneState(player);
            this.GroundDashState = new GroundDashState(player);
            this.JumpState = new JumpState(player);
            this.AirDashState = new AirDashState(player);
            this.AirDashStartState = new AirDashStartState(player);
            this.MeleeAttackRightState = new MeleeAttackRightState(player);
            this.MeleeAttackLeftState = new MeleeAttackLeftState(player);
            this.MeleeAttackUpState = new MeleeAttackUpState(player);
            this.AirMeleeAttackForwardState = new AirMeleeAttackForwardState(player);
            this.AirMeleeAttackBackwardState = new AirMeleeAttackBackwardState(player);
            this.AirMeleeAttackUpState = new AirMeleeAttackUpState(player);
            this.AirMeleeAttackDownState = new AirMeleeAttackDownState(player);
            this.ThrowPotionState = new ThrowPotionState(player);
            this.AirThrowPotionState = new AirThrowPotionState(player);
            this.StunnedState = new StunnedState(player);
            this.SceneChangeState = new SceneChangeState(player);
            this.DeathState = new DeathState(player);
        }
        
        public void Initialize(IState startingState)
        {
            CurrentState = startingState;
            CurrentState.Enter();
            
            // Notify other objects that state has changed
            OnStateChanged?.Invoke(CurrentState);
        }

        public void TransitionTo(IState nextState)
        {
            if (CurrentState is DeathState) return;
            LastState = CurrentState;
            CurrentState = nextState;
            LastState.Exit();
            CurrentState.Enter();
            
            OnStateChanged?.Invoke(CurrentState);
        }

        public void StateUpdate()
        {
            if (CurrentState != null)
            {
                CurrentState.Update();
            }
        }
    }
    
}

