using PlayersScripts;
using UnityEngine;

namespace StateMachine.PlayerState
{
    public class IdleState : State
    {
        private PlayerMove _player;

        public IdleState(PlayerMove player)
        {
            _player = player;
        }
        
        public override void Enter()
        {
            base.Enter();
            Debug.Log("enter idle state");
            _player.animator.gameObject.SetActive(true);
            _player.animator.CrossFade("IdlePlayerAnim", 0.02f);
        }


        public override void Exit()
        {
            base.Exit();
            Debug.Log("exit idle state");
        }
    }
}