using UnityEditor;

namespace Match3Bonus
{
    [CustomEditor(typeof(TimerView))]
    [CanEditMultipleObjects]
    public class TimerViewEditor : Editor
    {
        private SerializedProperty _timerTxt;
        private SerializedProperty _isCapTimeShow;
        private SerializedProperty _rangeTimeShow;
        private SerializedProperty _onShow;
        private SerializedProperty _onHide;

        private void OnEnable()
        {
            _timerTxt = serializedObject.FindProperty(nameof(_timerTxt));
            _isCapTimeShow = serializedObject.FindProperty(nameof(_isCapTimeShow));
            _rangeTimeShow = serializedObject.FindProperty(nameof(_rangeTimeShow));
            _onShow = serializedObject.FindProperty(nameof(_onShow));
            _onHide = serializedObject.FindProperty(nameof(_onHide));
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_timerTxt);
            EditorGUILayout.PropertyField(_isCapTimeShow);
            if (_isCapTimeShow.boolValue)
            {
                EditorGUILayout.PropertyField(_rangeTimeShow);
                EditorGUILayout.PropertyField(_onShow);
                EditorGUILayout.PropertyField(_onHide);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
