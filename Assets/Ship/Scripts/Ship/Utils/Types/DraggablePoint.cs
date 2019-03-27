using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

#endif

namespace Ship.Utils.Types
{
    public class DraggablePoint : PropertyAttribute
    {
    }


#if UNITY_EDITOR
    [CustomEditor(typeof(MonoBehaviour), true)]
    public class DraggablePointDrawer : UnityEditor.Editor
    {
        readonly GUIStyle style = new GUIStyle();

        void OnEnable()
        {
            style.fontStyle = FontStyle.Bold;
            style.normal.textColor = Color.white;
        }

        public void OnSceneGUI()
        {
            var property = serializedObject.GetIterator();
            while (property.Next(true))
            {
                if (property.propertyType == SerializedPropertyType.Vector3)
                {
                    var field = serializedObject.targetObject.GetType().GetField(property.name);
                    if (field == null)
                    {
                        continue;
                    }

                    var draggablePoints = field.GetCustomAttributes(typeof(DraggablePoint), false);
                    if (draggablePoints.Length > 0)
                    {
                        Handles.Label(property.vector3Value, property.displayName);
                        property.vector3Value = Handles.PositionHandle(property.vector3Value, Quaternion.identity);
                        serializedObject.ApplyModifiedProperties();
                    }
                }
            }
        }
    }
#endif
}