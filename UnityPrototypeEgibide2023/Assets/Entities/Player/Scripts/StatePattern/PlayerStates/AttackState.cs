﻿using StatePattern;
using UnityEngine;

namespace Entities.Player.Scripts.StatePattern.PlayerStates
{
    public class AttackState : IState
    {
        protected PlayerController Player;
        protected Vector2 AttackDirection;
        protected float KnockbackMultiplier;

        protected AttackState(PlayerController player)
        {
            this.Player = player;
        }
        
        public virtual void Enter()
        {
            Player.meleeAttack.GetComponent<AttackComponent>().ClearAttackData();
            Player.meleeAttack.GetComponent<AttackComponent>().AddAttackData(new AttackComponent.AttackData(Player.GetPlayerData().damage, Player.GetPlayerData().knockback * KnockbackMultiplier, AttackDirection, 7, AttackComponent.AttackType.Normal));
            Player.meleeAttack.GetComponent<AttackComponent>().AddAttackData(new AttackComponent.AttackData(1, Player.GetPlayerData().knockbackPotion * KnockbackMultiplier, AttackDirection, 8, AttackComponent.AttackType.Normal));
            Player.meleeAttack.GetComponent<AttackComponent>().AddAttackData(new AttackComponent.AttackData(1, 0, AttackDirection, 12, AttackComponent.AttackType.Normal));
        }

        public virtual void Update()
        {
            
        }

        public virtual void Exit()
        {
            
        }
    }
}