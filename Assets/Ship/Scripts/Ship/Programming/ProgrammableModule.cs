using System;
using System.Collections.Generic;
using UnityEngine;
using Ship.Programming.Languages;

namespace Ship.Programming
{
    public class ProgrammableModule : MonoBehaviour
    {
        public List<IoPin> pins;
        
        Interpreter interpreter;

        void Update()
        {
            foreach (IoPin pin in pins)
            {
                pin.Update();
            }
        }
    }
}