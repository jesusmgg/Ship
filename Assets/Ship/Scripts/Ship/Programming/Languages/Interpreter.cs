using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ship.Programming.Languages
{
    public class Interpreter : MonoBehaviour
    {
        public float speed = 100.0f;

        public InterpreterState state;
        
        string code;
        
        Coroutine runningCoroutine;
        
        public string Code
        {
            get => code;
            set
            {
                if (string.IsNullOrWhiteSpace(Code))
                {
                    code = value;
                }
                else
                {
                    Debug.LogWarning("Can't reassign code after the interpreter already started running.");
                }
            }
        }
        
        void OnDisable()
        {
            StopCoroutine(runningCoroutine);
        }
        
        IEnumerator Start() 
        {
            state = new InterpreterState();
            yield return new WaitUntil(() => string.IsNullOrWhiteSpace(Code));
            runningCoroutine = StartCoroutine(Run());
        }

        protected virtual IEnumerator Run()
        {
            yield return null;
        }
    }

    public sealed class InterpreterState
    {
        public InterpreterVariables variables = new InterpreterVariables();
    }

    public sealed class InterpreterVariables
    {
        public Dictionary<string, int> integers = new Dictionary<string, int>();
        public Dictionary<string, string> strings = new Dictionary<string, string>();
    }
}