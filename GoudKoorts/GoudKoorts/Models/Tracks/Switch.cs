using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Models.Tracks
{
    abstract class Switch : Track
    {
        public override char CharValue { 
            get {
                char c;

                if (Occupied)
                {
                    c = Cart.CharValue;
                } 
                else
                {
                    if (Position == 0)
                    {
                        c = '<';
                    }
                    else
                    {
                        c = '>';
                    }
                }

                return c;
            }
        }

        public int Position { get; private set; } = 0;

        public void Flip()
        {
            Position = 1 - Position;
        }
    }
}
