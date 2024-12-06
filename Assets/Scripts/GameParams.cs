using UnityEngine;

namespace BouncyBalls
{
    public class GameParams : MonoBehaviour
    {
        // constants
        public const float MAX_SPEED = 5f;
        public const float MIN_SPEED = 1f;
        public const float MAX_RADIUS = 0.75f;
        public const float MIN_RADIUS = 0.25f;
        public const float MAX_BALLS = 1;
        public const bool TRAILS = false;
        public const bool GRAVITY = true;
        public const float GRAVITY_STRENGTH = 3f;
        public const bool COLLISIONS = false;
        public const float FRICTION = 0f;
        public const float BOUNCE = 1f;

        // params  
        [SerializeField] private float maxSpeed;
        [SerializeField] private float minSpeed;
        [SerializeField] private float maxRadius;
        [SerializeField] private float minRadius;
        [SerializeField] private float maxBalls;
        [SerializeField] private bool trails;
        [SerializeField] private bool gravity;
        [SerializeField] private float gravityStrength;
        [SerializeField] private bool collisions;
        [SerializeField] private PhysicsMaterial2D bounceMaterial;

        public void Reset()
        {
            // default params
            setMaxSpeed(MAX_SPEED);
            setMinSpeed(MIN_SPEED);
            setMaxRadius(MAX_RADIUS);
            setMinRadius(MIN_RADIUS);
            setMaxBalls(MAX_BALLS);
            setTrails(TRAILS);
            setGravity(GRAVITY);
            setGravityStrength(GRAVITY_STRENGTH);
            setCollisions(COLLISIONS);
            setFriction(FRICTION);
            setBounce(BOUNCE);
        }

        // getters and setters
        public float getMaxSpeed()
        {
            return maxSpeed;
        }

        public float getMinSpeed()
        {
            return minSpeed;
        }

        public float getMaxRadius()
        {
            return maxRadius;
        }

        public float getMinRadius()
        {
            return minRadius;
        }

        public float getMaxBalls()
        {
            return maxBalls;
        }

        public bool getTrails()
        {
            return trails;
        }

        public bool getGravity()
        {
            return gravity;
        }

        public float getGravityStrength()
        {
            return gravityStrength;
        }

        public bool isColliding()
        {
            return collisions;
        }

        public float getFriction()
        {
            return bounceMaterial.friction;
        }

        public float getBounce()
        {
            return bounceMaterial.bounciness;
        }

        public void setMaxSpeed(float value)
        {
            if (value < minSpeed)
            {
                maxSpeed = minSpeed;
            }
            else
            {
                maxSpeed = value;
            }
        }

        public void setMinSpeed(float value)
        {
            if (value > maxSpeed)
            {
                minSpeed = maxSpeed;
            }
            else
            {
                minSpeed = value;
            }
        }

        public void setMaxRadius(float value)
        {
            if (value < minRadius)
            {
                maxRadius = minRadius;
            }
            else
            {
                maxRadius = value;
            }
        }

        public void setMinRadius(float value)
        {
            if (value > maxRadius)
            {
                minRadius = maxRadius;
            }
            else
            {
                minRadius = value;
            }
        }

        public void setMaxBalls(float value)
        {
            maxBalls = value;
        }

        public void setTrails(bool value)
        {
            trails = value;
        }

        public void setGravity(bool value)
        {
            gravity = value;
        }

        public void setGravityStrength(float value)
        {
            gravityStrength = value;
        }

        public void setCollisions(bool value)
        {
            collisions = value;
        }

        public void setFriction(float value)
        {
            bounceMaterial.friction = value;
        }

        public void setBounce(float value)
        {
            bounceMaterial.bounciness = value;
        }
    }
}