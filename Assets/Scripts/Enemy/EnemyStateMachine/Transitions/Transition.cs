using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected Cake Target { get; private set; }

    public State TargetState => _targetState;
    public bool NeedTransit { get; protected set; }
    public void Init(Cake target)
    {
        Target = target;
    }
    private void OnEnable()
    {
        NeedTransit = false;
    }
}
