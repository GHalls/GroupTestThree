using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TutorialGameTwo
{
    public class Ball
    {
        private float _dirX;
        private float _dirY;
        private Vector2 _vec;

        public Ball(int x, int y)
        {
            this._vec = new Vector2(x, y);
        }

        public float X
        {
            get { return this._vec.X; }
            set { this._vec.X = value; }
        }

        public float Y
        {
            get { return this._vec.Y; }
            set { this._vec.Y = value; }
        }

        public float DirX
        {
            get { return this._dirX; }
            set { this._dirX = value; }
        }

        public float DirY
        {
            get { return this._dirY; }
            set { this._dirY = value; }
        }

        public void hitRightOrLeft()
        {
            this._dirX = this._dirX * -1;
        }

        public void hitTopOrBottom()
        {
            this._dirY = this.DirY * -1;
        }

        public void Update()
        {
            this._vec.X += this._dirX;
            this._vec.Y += this._dirY;
        }
    }
}
