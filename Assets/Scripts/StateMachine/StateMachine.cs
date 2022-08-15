namespace StateMachine
{
    public class StateMachine
    {
        public State CurrentState { get; set; }

        public void InitState(State startState)
        {
            CurrentState = startState;
            CurrentState.Enter();
        }

        public void ChangeState(State newState)
        {
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}