using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public string PlayerName { get; private set; }
    public TMP_InputField nameInputField;

    public static TitleManager Instance;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
    }

    public void NameInputChanged()
    {
        PlayerName = nameInputField.text;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
