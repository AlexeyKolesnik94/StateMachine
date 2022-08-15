using System;
using StateMachine.PlayerState;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace PlayersScripts
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float movingSpeed;

        public Animator animator;
        
        private global::StateMachine.StateMachine _stateMachine;
        private RunState _runState;
        private IdleState _idleState;

        private Controls _controls;

        private bool _isRun;
        private Vector3 _direction;

        private void Awake()
        {
            _controls = new Controls();
        }

        private void OnEnable()
        {
            _controls.Enable();
        }

        private void Start()
        {
            _stateMachine = new global::StateMachine.StateMachine();
            _runState = new RunState(this);
            _idleState = new IdleState(this);
            
            _stateMachine.InitState(_idleState);

            
            this.UpdateAsObservable()
                .Subscribe(_ =>
                {
                    _stateMachine.CurrentState.Update();

                   ChangeState();

                   Debug.Log(_direction);
                }).AddTo(this);
        }

        private void OnDisable()
        {
            _controls.Disable();
        }

        public void Moving()
        {
            var position = transform.position;
            position = new Vector3(position.x + movingSpeed * Time.deltaTime  * _direction.x, position.y,
                position.z + movingSpeed * Time.deltaTime * _direction.z);
            transform.position = position;
        }

        private void ChangeState()
        {
            _direction = _controls.Player.Moving.ReadValue<Vector3>();
            
            if (_direction == Vector3.zero && _isRun)
            {
                _isRun = false;
                _stateMachine.ChangeState(_idleState);
            }

            if (_direction != Vector3.zero && !_isRun)
            {
                _isRun = true;
                _stateMachine.ChangeState(_runState);
            }
        }
    }
}