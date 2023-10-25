using UnityEditor;

namespace Match3Bonus
{
    [CustomEditor(typeof(UnityEventInvoker))]
    [CanEditMultipleObjects]
    public class UnityEventInvokerEditor : Editor
    {
        private SerializedProperty _onInvoke;
        private SerializedProperty _isRepeating;
        private SerializedProperty _repeatInterval;
        private SerializedProperty _delayFirstInvoke;

        private void OnEnable()
        {
            _onInvoke = serializedObject.FindProperty(nameof(_onInvoke));
            _isRepeating = serializedObject.FindProperty(nameof(_isRepeating));
            _repeatInterval = serializedObject.FindProperty(nameof(_repeatInterval));
            _delayFirstInvoke = serializedObject.FindProperty(nameof(_delayFirstInvoke));
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_onInvoke);
            EditorGUILayout.PropertyField(_isRepeating);
            if (_isRepeating.boolValue)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(_repeatInterval);
                EditorGUI.indentLevel--;
            }

            EditorGUILayout.PropertyField(_delayFirstInvoke);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
