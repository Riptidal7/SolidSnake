using UnityEditor;
using UnityEngine;

public class PlayerPrefsResetMenu : MonoBehaviour
{
    [MenuItem("Tools/Reset High Score")]
    public static void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        Debug.Log("High Score Reset via Editor Menu!");
    }

    [MenuItem("Tools/Reset All PlayerPrefs")]
    public static void ResetAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("All PlayerPrefs Reset!");
    }
}
