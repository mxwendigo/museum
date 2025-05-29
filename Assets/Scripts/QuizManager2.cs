using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class QuizManager2 : MonoBehaviour
{
    public GameObject continuePanel;
    private bool waitingForClick = false;
    public GameObject quizPanel; 
    public GameObject feedbackPanel;
    public TextMeshProUGUI feedbackText;
    public TextMeshProUGUI Text;     
    public Image Painting1;              
    public Button[] answerButtons;           
    public string correctAnswer;             

    void Start()
    {
        // Load the image (make sure it's in a Resources folder!)
        Sprite painting = Resources.Load<Sprite>("Painting1");

        // Call our custom function to set up the quiz question
        SetQuestion(
            "2-What is the correct title of this famous Baroque painting made by Rembrandt?",
            painting,
            new string[] { "Dissection Study of Dr. Nicolas Tulip", "Anatomy Lesson of Dr. Nicolaes Tulp", "Surgical Lecture of Dr. Nikolas Tulip", "Medical Demonstration of Dr. Nicholas Tulp" },
            "Anatomy Lesson of Dr. Nicolaes Tulp"
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

        quizPanel.SetActive(false);

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
        waitingForClick = true;
    }
    void Update()
    {
        if (waitingForClick && Input.GetMouseButtonDown(0))
        {
            // Player clicked — now show Continue panel
            feedbackPanel.SetActive(false);
            continuePanel.SetActive(true);
            waitingForClick = false;
        }
    }

    public void HideFeedback()
    {
        feedbackPanel.SetActive(false);
        // Show Continue Panel after feedback
        continuePanel.SetActive(true);

    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("MenuScene"); 
    }

    public void ReturnToMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

}



