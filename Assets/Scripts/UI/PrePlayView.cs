using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
    public class PrePlayView : UIBaseView
    {
        public string textToType;
        public string[] instructions;
        private Queue<char> _characters;
        private Char _currentChar;
        public TMP_Text textTypingDisplay, textInstruction;
        private PlayerInputHandler _playerInputHandler;

        private void OnEnable()
        {
            Init();
            StartCoroutine(DisplayInstruction());
        }

        private void OnDisable()
        {
            _playerInputHandler.OnAttackKeyPressed -= OnKeyPressed;
        }

        private void Init()
        {
            _playerInputHandler = FindFirstObjectByType<PlayerInputHandler>();
            _characters = new Queue<char>(textToType.ToCharArray());
            _currentChar = _characters.Dequeue();
            _playerInputHandler.OnAttackKeyPressed += OnKeyPressed;
        }

        IEnumerator DisplayInstruction()
        {
            yield return new WaitForSeconds(1f);
            foreach (var instruction in instructions)
            {
                foreach (var ctx in instruction)
                {
                    textInstruction.text += ctx;
                    yield return new WaitForSeconds(0.1f);
                }
                yield return new WaitForSeconds(2f);
                textInstruction.text = "";
                yield return new WaitForSeconds(1f);
            }
        }
        private void OnKeyPressed(string keyPressed)
        {
            char inputChar = keyPressed.ToLower()[0];     // convert về lowercase cho dễ check
            char expected = char.ToLower(_currentChar);

            if (inputChar == expected)
            {
                // đúng ký tự
                textTypingDisplay.text += _currentChar;

                if (_characters.Count > 0)
                {
                    _currentChar = _characters.Dequeue();
                }
                else
                {
                    Debug.Log("Typing Completed!");
                    GameEvents.TypeCheckComplete?.Invoke();
                }
            }
            else
            {
                
            }
        }
    }
}