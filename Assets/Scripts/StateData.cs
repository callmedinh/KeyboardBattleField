using DefaultNamespace;
using States;
using UnityEngine;

public abstract class StateData : ScriptableObject
{
    protected PlayerController playerController;
    public AudioData audioData;
    public abstract void UpdateAbility(Animator animator, CharacterStateMachine stateMachine, AnimatorStateInfo stateInfo);
    public abstract void OnEnter(Animator animator, CharacterStateMachine stateMachine, AnimatorStateInfo stateInfo);
    public abstract void OnExit(Animator animator, CharacterStateMachine stateMachine, AnimatorStateInfo stateInfo);
}