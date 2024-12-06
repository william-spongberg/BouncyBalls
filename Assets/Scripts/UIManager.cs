using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace BouncyBalls
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject gameParams;
        [SerializeField] private Slider maxSpeedSlider;
        [SerializeField] private TMPro.TextMeshProUGUI maxSpeedText;
        [SerializeField] private Slider minSpeedSlider;
        [SerializeField] private TMPro.TextMeshProUGUI minSpeedText;

        [SerializeField] private Slider maxRadiusSlider;
        [SerializeField] private TMPro.TextMeshProUGUI maxRadiusText;
        [SerializeField] private Slider minRadiusSlider;
        [SerializeField] private TMPro.TextMeshProUGUI minRadiusText;

        [SerializeField] private Toggle trailsToggle;

        [SerializeField] private Toggle gravityToggle;
        [SerializeField] private Slider gravityStrengthSlider;
        [SerializeField] private TMPro.TextMeshProUGUI gravityStrengthText;

        [SerializeField] private Slider frictionSlider;
        [SerializeField] private TMPro.TextMeshProUGUI frictionText;

        [SerializeField] private Slider bounceSlider;
        [SerializeField] private TMPro.TextMeshProUGUI bounceText;

        [SerializeField] private Slider maxBallsSlider;
        [SerializeField] private TMPro.TextMeshProUGUI maxBallsText;

        void Awake()
        {
            // reset game params
            gameParams.GetComponent<GameParams>().Reset();
        }

        void LateUpdate()
        {
            updateGUI();
        }

        public void updateGUI()
        {
            // update UI elements
            maxSpeedSlider.value = gameParams.GetComponent<GameParams>().getMaxSpeed();
            minSpeedSlider.value = gameParams.GetComponent<GameParams>().getMinSpeed();

            maxRadiusSlider.value = gameParams.GetComponent<GameParams>().getMaxRadius();
            minRadiusSlider.value = gameParams.GetComponent<GameParams>().getMinRadius();

            trailsToggle.isOn = gameParams.GetComponent<GameParams>().getTrails();

            gravityToggle.isOn = gameParams.GetComponent<GameParams>().getGravity();
            gravityStrengthSlider.value = gameParams.GetComponent<GameParams>().getGravityStrength();

            frictionSlider.value = gameParams.GetComponent<GameParams>().getFriction();
            bounceSlider.value = gameParams.GetComponent<GameParams>().getBounce();

            maxBallsSlider.value = gameParams.GetComponent<GameParams>().getMaxBalls();

            // update UI text
            maxSpeedText.text = "Max Speed: " + gameParams.GetComponent<GameParams>().getMaxSpeed().ToString("F3");
            minSpeedText.text = "Min Speed: " + gameParams.GetComponent<GameParams>().getMinSpeed().ToString("F3");

            maxRadiusText.text = "Max Radius: " + gameParams.GetComponent<GameParams>().getMaxRadius().ToString("F3");
            minRadiusText.text = "Min Radius: " + gameParams.GetComponent<GameParams>().getMinRadius().ToString("F3");

            gravityStrengthText.text = "Gravity: " + gameParams.GetComponent<GameParams>().getGravityStrength().ToString("F3");

            frictionText.text = "Friction: " + gameParams.GetComponent<GameParams>().getFriction().ToString("F3");
            bounceText.text = "Bounce: " + gameParams.GetComponent<GameParams>().getBounce().ToString("F3");

            maxBallsText.text = "Max Balls: " + gameParams.GetComponent<GameParams>().getMaxBalls().ToString();
        }
    }
}