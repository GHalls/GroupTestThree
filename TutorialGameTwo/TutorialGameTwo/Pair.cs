using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TutorialGameTwo
{
    public class Pair<V, P> 
    {
        private V first;
        private P second;

        public Pair(V f, P s)
        {
            this.first = f;
            this.second = s;
        }

        public V First
        {
            get { return this.first; }
            set { this.first = value; }
        }

        public P Second
        {
            get { return this.second; }
            set { this.second = value; }
        }
    }
}
