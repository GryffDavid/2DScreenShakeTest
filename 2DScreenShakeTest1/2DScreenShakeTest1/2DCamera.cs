using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace _2DScreenShakeTest1
{
    public class _2DCamera
    {
        public Matrix Transform;

        public Vector2 Position;
        public float Rotation;

        bool IsShaking = true;
        int ShakeCount = 30;
        int Shakes = 0;
        float ShakeIntensity = 2.0f;
        float ShakeSpeed = 2.0f;
        static Random Random = new Random();

        KeyboardState CurKbState, PreKbState;
        

        public void Update(GameTime gameTime)
        {
            CurKbState = Keyboard.GetState();

            if (Shakes < ShakeCount)
            {
                Position = new Vector2(RandomFloat(-ShakeIntensity, ShakeIntensity), RandomFloat(-ShakeIntensity, ShakeIntensity));
                //Rotation = RandomFloat(-0.004f, 0.004f);
                Shakes++;
            }

            if (Shakes >= ShakeCount)
            {
                ShakeCount = 0;
                Shakes = 0;
                Position = Vector2.Zero;
                //Rotation = 0;

            }

            Transform = Matrix.CreateTranslation(-new Vector3(1280/2, 720/2, 0)) *
                        Matrix.CreateTranslation(new Vector3(Position.X, Position.Y, 0)) *
                        Matrix.CreateRotationZ(Rotation) *
                        Matrix.CreateTranslation(new Vector3(1280/2, 720/2, 0));

            if (Mouse.GetState().LeftButton == ButtonState.Pressed &&
                ShakeIntensity > 0)
            {
                ShakeIntensity -= 0.1f;
            }

            if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                ShakeIntensity += 0.1f;
            }

            if (CurKbState.IsKeyUp(Keys.Space) &&
                PreKbState.IsKeyDown(Keys.Space))
            {
                ShakeCount = 80;
                Shakes = 0;
                //Rotation = 0;
            }
                
                PreKbState = CurKbState;
        }

        public static float RandomFloat(float a, float b)
        {
            return (float)(a + Random.NextDouble() * (b - a));
        }
    }
}
