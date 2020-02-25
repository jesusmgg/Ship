using UnityEngine;

namespace Ship.Programming
{
    public class IoPin
    {
        public string name;
        
        public IoPinMode mode;
        public IoPinValueType valueType;

        public IoPin connectedPin;
        
        string value;

        public string Value
        {
            get => value;
            set
            {
                if (mode == IoPinMode.Output)
                {
                    this.value = value;
                }
            }
        }

        public IoPin(string name, IoPinMode mode = IoPinMode.Output, IoPinValueType valueType = IoPinValueType.Int)
        {
            this.name = name;
            this.mode = mode;
            this.valueType = valueType;
            
            SetDefaultValue();
        }

        public void Update()
        {
            if (mode == IoPinMode.Input)
            {
                if (connectedPin != null)
                {
                    if (valueType != connectedPin.valueType)
                    {
                        Debug.LogError($"{name} type is inconsistent with connected pin {connectedPin.name}");
                        SetDefaultValue();
                    }
                    else
                    {
                        value = connectedPin.value;    
                    }
                }
                else
                {
                    SetDefaultValue();
                }
            }
        }

        void SetDefaultValue()
        {
            if (valueType == IoPinValueType.Int) {Value = "0";}
            else if (valueType == IoPinValueType.String) {Value = "";}
        }
    }

    public enum IoPinMode
    {
        Output = 0,
        Input = 1
    }

    public enum IoPinValueType
    {
        Int,
        String
    }
}