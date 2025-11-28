using UnityEngine;

[CreateAssetMenu(fileName = "New Audio Data", menuName = "Audio/Audio Data")]
public class AudioData : ScriptableObject
{
    public AudioClip clip;
    public float volume = 1f;
    public float pitch = 1f;
}