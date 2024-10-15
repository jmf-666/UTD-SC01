using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[InitializeOnLoadAttribute]
public abstract class ManagedObject : ScriptableObject
{
    abstract protected void OnBegin();
    abstract protected void OnEnd();

    private void Awake()
    {
        OnBegin();
    }

#if UNITY_EDITOR
    protected void OnEnable()
    {
        EditorApplication.playModeStateChanged += OnPlayStateChange;
        OnBegin();
    }

    protected void OnDisable()
    {
        EditorApplication.playModeStateChanged -= OnPlayStateChange;
    }

    void OnPlayStateChange(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.EnteredPlayMode)
        {
            OnBegin();
        }
        else if (state == PlayModeStateChange.ExitingPlayMode)
        {
            OnEnd();
        }
    }
#else
        protected void OnEnable()
        {
            OnBegin();
        }
 
        protected void OnDisable()
        {
            OnEnd();
        }
#endif
}