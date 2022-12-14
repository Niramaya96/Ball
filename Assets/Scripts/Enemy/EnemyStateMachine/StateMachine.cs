using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _startState;
    [SerializeField] private Enemy _enemy;

    private Cake _target;
    private State _currentState;

    public State Current => _currentState;

    private void Start()
    {
        _target = GetComponent<Enemy>().Target;
        SetStartState();
    }
    private void SetStartState()
    {
        _currentState = _startState;

        if (_currentState != null)
            _currentState.Enter(_target);
    }
    private void Update()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.GetNextState();
        if (nextState != null)
            Transit(nextState);
    }
           
    private void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;
        if (_currentState != null)
            _currentState.Enter(_target);
    }
}