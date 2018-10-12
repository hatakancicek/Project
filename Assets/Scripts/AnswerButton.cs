using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{

    public Text answerText;
    public InputField inputField;
    private AnswerData answerData;

    // Use this for initialization
    void Start()
    {
        Button button = gameObject.GetComponent<Button>();
    }

    void Awake()
    {
        inputField.onEndEdit.AddListener(AcceptStringInput);
    }


    public void Setup(AnswerData data)
    {
        answerData = data;
        answerText.text = answerData.getAnswer();
    }

    void AcceptStringInput(string userInput)
    {
        userInput = userInput.ToLower();
        controller.LogStringWithReturn(userInput);

        char[] delimiterCharacters = { ' ' };
        string[] separatedInputWords = userInput.Split(delimiterCharacters);

        for (int i = 0; i < controller.inputActions.Length; i++)
        {
            InputAction inputAction = controller.inputActions[i];
            if (inputAction.keyWord == separatedInputWords[0])
            {
                inputAction.RespondToInput(controller, separatedInputWords);
            }
        }

        InputComplete();

    }
    void InputComplete()
    {
        controller.DisplayLoggedText();
        inputField.ActivateInputField();
        inputField.text = null;
    }

}