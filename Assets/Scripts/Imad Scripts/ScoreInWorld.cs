using UnityEngine;
using TMPro;

public class ScoreInWorld : MonoBehaviour
{
    

    [SerializeField] private TextMeshProUGUI textScore;

    void Start()
    {
        textScore = textScore.transform.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text= MinigameShooterManager.shooterScore.ToString();
    }
}
