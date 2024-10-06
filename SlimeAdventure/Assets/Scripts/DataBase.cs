using UnityEngine;

public class DataBase : MonoBehaviour
{
    public static DataBase instance { get; private set; }

    private void Awake() {
        if (instance == null) {
            DontDestroyOnLoad(gameObject);
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    void Start() {
        
    }
}