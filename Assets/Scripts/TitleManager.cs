using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public string PlayerName { get; private set; }
    public TMP_InputField nameInputField;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        
    }

    public void NameInputChanged()
    {
        PlayerName = nameInputField.text;
        Debug.Log(nameInputField.text);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
