using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace BouncyBalls
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject ballPrefab;
        [SerializeField] private GameObject gameParams;
        [SerializeField] private float maxBalls;
        [SerializeField] private int currentBalls;
        [SerializeField] private Queue<GameObject> balls = new Queue<GameObject>();

        void Start()
        {
            if (UnityEngine.InputSystem.GravitySensor.current != null)
                InputSystem.EnableDevice(UnityEngine.InputSystem.GravitySensor.current);

            maxBalls = gameParams.GetComponent<GameParams>().getMaxBalls();
            // add one ball to start
            balls.Enqueue(Instantiate(ballPrefab, Vector3.zero, Quaternion.identity));
        }

        // late update to ensure all balls have been updated
        void LateUpdate()
        {
            List<GameObject> newBalls = new List<GameObject>();
            currentBalls = balls.Count;

            bool gravity = gameParams.GetComponent<GameParams>().getGravity();
            float gravityStrength = gameParams.GetComponent<GameParams>().getGravityStrength();
            if (InputSystem.GetDevice<UnityEngine.InputSystem.GravitySensor>() != null) {
                Vector3 gravitySense = InputSystem.GetDevice<UnityEngine.InputSystem.GravitySensor>().gravity.ReadValue();
                Physics2D.gravity = new Vector2(gravitySense.x*gravityStrength, gravitySense.y*gravityStrength);
            }
            else {
                Physics2D.gravity = new Vector2(0, -gravityStrength);
            }

            bool collisions = gameParams.GetComponent<GameParams>().isColliding();

            foreach (GameObject ball in balls)
            {
                // create new ball if collided with wall
                if (ball.GetComponent<Ball>().getHasCollided() && maxBalls > currentBalls)
                {
                    ball.GetComponent<Ball>().NewColour();
                    ball.GetComponent<Ball>().setHasCollided(false);
                    newBalls.Add(Instantiate(ballPrefab, Vector3.zero, Quaternion.identity));
                }

                // check gravity setting
                if (gravity)
                {
                    ball.GetComponent<Ball>().EnableGravity();
                }
                else
                {
                    ball.GetComponent<Ball>().DisableGravity();
                }

                // check collisions setting
                if (collisions)
                {
                    ball.GetComponent<Ball>().EnableCollisions();
                }
                else
                {
                    ball.GetComponent<Ball>().DisableCollisions();
                }
            }

            // add new balls
            foreach (GameObject newBall in newBalls)
            {
                balls.Enqueue(newBall);
            }

            // remove balls if over max
            maxBalls = gameParams.GetComponent<GameParams>().getMaxBalls();
            while (balls.Count > maxBalls)
            {
                Destroy(balls.Dequeue());
            }

            currentBalls = balls.Count;
        }

        public void Reset()
        {
            foreach (GameObject ball in balls)
            {
                Destroy(ball);
            }
            balls.Clear();
            maxBalls = gameParams.GetComponent<GameParams>().getMaxBalls();
            // add one ball to start
            balls.Enqueue(Instantiate(ballPrefab, Vector3.zero, Quaternion.identity));
        }
    }
}