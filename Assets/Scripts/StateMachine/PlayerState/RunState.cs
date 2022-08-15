using PlayersScripts;
using UnityEngine;

namespace StateMachine.PlayerState
{
    public class RunState : State
    {
        private PlayerMove _player;

        public RunState(PlayerMove player)
        {
            _player = player;
        }
        
        public override void Enter()
        {
            base.Enter();
            Debug.Log("enter run state");
            _player.animator.CrossFade("RunPlayerAim", 0.05f);
        }

        public override void Update()
        {
            base.Update();
            Debug.Log("update run state");
            _player.Moving();
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("exit run state");
        }
    }
}