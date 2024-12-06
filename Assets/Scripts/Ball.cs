using UnityEngine;

namespace BouncyBalls
{
    [RequireComponent(typeof(SpriteRenderer)), RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(AudioSource)), RequireComponent(typeof(TrailRenderer))]
    public class Ball : MonoBehaviour
    {
        // constants
        public const float MAX_VOLUME = 1f;
        public const float MIN_VOLUME = 0.5f;
        public const float MAX_PITCH = 2.5f;
        public const float MIN_PITCH = 1.5f;

        // params
        [SerializeField] private GameObject minmax;
        [SerializeField] private float maxSpeed;
        [SerializeField] private float minSpeed;
        [SerializeField] private float maxRadius;
        [SerializeField] private float minRadius;

        // components
        private SpriteRenderer sRenderer;
        private Rigidbody2D rBody;
        private AudioSource aSource;
        private bool hasCollided = false;

        void Start()
        {
            // get maxes and mins from spawner
            maxSpeed = minmax.GetComponent<GameParams>().getMaxSpeed();
            minSpeed = minmax.GetComponent<GameParams>().getMinSpeed();

            maxRadius = minmax.GetComponent<GameParams>().getMaxRadius();
            minRadius = minmax.GetComponent<GameParams>().getMinRadius();

            // random colour
            sRenderer = GetComponent<SpriteRenderer>();
            NewColour();

            // random velocity
            rBody = GetComponent<Rigidbody2D>();
            float speed = Random.Range(minSpeed, maxSpeed);
            rBody.linearVelocity = new Vector2(Random.Range(-speed, speed), Random.Range(-speed, speed));

            // random radius
            float radius = Random.Range(minRadius, maxRadius);
            transform.localScale = new Vector3(radius, radius, 1);

            // audio
            aSource = GetComponent<AudioSource>();
        }

        void LateUpdate()
        {
            // draw trail
            if (minmax.GetComponent<GameParams>().getTrails())
            {
                GetComponent<TrailRenderer>().enabled = true;
            }
            else
            {
                GetComponent<TrailRenderer>().enabled = false;
            }
        }

        public void NewColour()
        {
            sRenderer.color = new Color(Random.value, Random.value, Random.value);
        }

        public void playSound()
        {
            aSource.volume = Random.Range(MIN_VOLUME, MAX_VOLUME);
            aSource.pitch = Random.Range(MIN_PITCH, MAX_PITCH);
            aSource.Play();
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag != "Ball")
            {
                playSound();
                hasCollided = true;
            }
        }

        // getters and setters
        public bool getHasCollided()
        {
            return hasCollided;
        }

        public void setHasCollided(bool value)
        {
            hasCollided = value;
        }

        public void EnableGravity()
        {
            rBody.gravityScale = GameParams.GRAVITY_STRENGTH;
        }

        public void DisableGravity()
        {
            rBody.gravityScale = 0;
        }

        public void EnableCollisions()
        {
            gameObject.layer = LayerMask.NameToLayer("BallHidden");
        }

        public void DisableCollisions()
        {
            gameObject.layer = LayerMask.NameToLayer("Ball");
        }
    }
}