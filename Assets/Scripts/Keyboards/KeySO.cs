using UnityEngine;
using UnityEngine.InputSystem;


[CreateAssetMenu (fileName = "New Key", menuName = "ScriptableObjects/KeySO", order = 1)]
public class KeySo : ScriptableObject
{
    public string keyName; //id
    public Sprite normalSprite;
    public Sprite selectedSprite;
}
