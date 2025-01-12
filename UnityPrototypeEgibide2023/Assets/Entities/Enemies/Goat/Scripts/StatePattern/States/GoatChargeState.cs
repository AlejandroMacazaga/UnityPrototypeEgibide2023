﻿using System.Collections;
using System.Collections.Generic;
using StatePattern;
using UnityEngine;


namespace Entities.Enemies.Goat.Scripts.StatePattern.States
{
    public class GoatChargeState : IState
    {
        // Start is called before the first frame update
        private GoatBehaviour entity;
        
        public GoatChargeState(GoatBehaviour entity)
        {
            this.entity = entity;
        }

        public void Enter()
        {
            entity.canCollideWithPlayer = true;
            entity.AttackComponent.ActivateHitbox();
            entity.animator.SetBool("IsCharge", true);
            entity.InvokeRepeating(nameof(entity.Move), 0, 0.01f);
        }

        // per-frame logic, include condition to transition to a new state
        public void Update()
        {
        
        }
        
        public void Exit()
        {
            entity.AttackComponent.DeactivateHitbox();
            entity.animator.SetBool("IsCharge", false);
            entity.CancelInvoke(nameof(entity.Move));
        }
    }  
}