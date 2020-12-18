using System;
using System.Drawing;
namespace CVA.Continuous
{
    public class Renderer
    {
        public readonly Animation animation = null;
        public Renderer(Animation animation)
        {
            if(animation is null)
            {
                throw new NullReferenceException();
            }
            this.animation = animation;
        }
        public Bitmap Render(double t)
        {
            return null;
        }
    }
}
