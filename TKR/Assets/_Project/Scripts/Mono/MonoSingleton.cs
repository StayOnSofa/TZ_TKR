using UnityEngine;

namespace _Project.Mono
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        private static T GetOrCreate()
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                
                if (_instance == null)
                {
                    _instance = new GameObject(typeof(T).Name).AddComponent<T>();
                    _instance.gameObject.hideFlags = HideFlags.HideInHierarchy;
                }
            }

            return _instance;
        }

        public static T Instance => GetOrCreate();
    }
}