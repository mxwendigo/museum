using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class QuizManager : MonoBehaviour
{
    public GameObject feedbackPanel;
    public TextMeshProUGUI feedbackText;
    public TextMeshProUGUI Text;     // The actual question text
    public Image Painting1;              // The painting to display
    public Button[] answerButtons;           // 4 answer buttons
    public string correctAnswer;             // The correct answer to compare

    void Start()
    {
        // Load the image (make sure it's in a Resources folder!)
        Sprite painting = Resources.Load<Sprite>("Painting1");

        // Call our custom function to set up the quiz question
        SetQuestion(
            "1-Which of the following artists painted this famous work of art?",
            painting,
            new string[] { "Velazquez", "Rubens", "Caravaggio", "El Greco" },
            "Caravaggio"
        );
    }

    public void SetQuestion(string question, Sprite painting, string[] options, string correct)
    {
        Text.text = question;
        Painting1.sprite = painting;
        correctAnswer = correct;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            string answer = options[i]; // local copy so Unity doesn't mess it up later

            // Set the button label text
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = answer;

            // Remove previous listeners so they don't stack up
            answerButtons[i].onClick.RemoveAllListeners();

            // Add new listener to check the clicked answer
            answerButtons[i].onClick.AddListener(() => CheckAnswer(answer));
        }
    }

    
    public void CheckAnswer(string selected)
    {
        Debug.Log("You clicked: " + selected);

        if (selected == correctAnswer)
        {
            Debug.Log("Correct answer!");
            feedbackText.text = "Correct!";
            feedbackText.color = Color.green;
        }
        else
        {
            Debug.Log("Wrong answer!");
            feedbackText.text = "Wrong!";
            feedbackText.color = Color.red;
        }

        feedbackPanel.SetActive(true);
    }

    public void HideFeedback()
    {
        feedbackPanel.SetActive(false);
    }
}



