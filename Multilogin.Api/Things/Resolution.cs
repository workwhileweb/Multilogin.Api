using System;
using System.Collections.Generic;
using System.Text;

namespace Multilogin.Api.Things
{
    public class Resolution
    {
        public long Height { get; set; }

        public long Width { get; set; }


        public Resolution(long width, long height)
        {
            this.Height = height;
            this.Width = width;
        }
    }
}
