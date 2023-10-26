using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Match3Bonus
{
    public class TestGameEditorWindow : EditorWindow
    {
        private float _timescale = 1.0f;

        [MenuItem("Window/Test Game")]
        public static void ShowWindow()
        {
            TestGameEditorWindow window = GetWindow<TestGameEditorWindow>("Test Game");
            window.Show();
        }

        private void OnGUI()
        {
            ShowTime();
            ShowGap();
            ShowGameViewModel();
            ShowGap();
            ShowGameView();
        }

        private void ShowTime()
        {
            GUILayout.Label("----TIME TEST----", EditorStyles.boldLabel);
            GUILayout.BeginHorizontal();
            GUILayout.Label("Timescale: ", GUILayout.Width(70));
            _timescale = EditorGUILayout.FloatField(_timescale,
                GUILayout.Width(12 * Mathf.Max(2, Mathf.Log10(_timescale) + 1)));
            GUILayout.EndHorizontal();
            //_timescale = Mathf.Clamp(_timescale, 0, 100);
            Time.timeScale = _timescale;
        }

        private void ShowGameViewModel()
        {
            GUILayout.Label("----GAME VIEW MODEL TEST----", EditorStyles.boldLabel);
            ShowInvokableFunctions<GameViewModel>();
        }

        private void ShowGameView()
        {
            GUILayout.Label("----GAME VIEW TEST----", EditorStyles.boldLabel);
            ShowInvokableFunctions<GameView>();
        }

        private void ShowInvokableFunctions<T>() where T : Object
        {
            T target = FindObjectOfType<T>();

            if (target == null)
            {
                EditorGUILayout.HelpBox("No object with GameViewModel found in the scene.", MessageType.Info);
                return;
            }

            EditorGUILayout.Space();

            MethodInfo[] methods = target.GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

            foreach (MethodInfo functionInfo in methods)
            {
                // Skip functions with parameters
                if (functionInfo.GetParameters().Length > 0)
                {
                    continue;
                }

                GUILayout.BeginVertical(EditorStyles.helpBox);

                GUILayout.Label(functionInfo.Name);

                GUILayout.Space(5);

                if (GUILayout.Button("Invoke"))
                {
                    functionInfo.Invoke(target, null);
                }

                GUILayout.EndVertical();
                GUILayout.Space(10);
            }
        }

        private void ShowGap()
        {
            GUILayout.Label("", GUILayout.Height(20));
        }
    }
}
