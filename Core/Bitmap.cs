namespace CVA.Core
{
    public struct Bitmap
    {
        public ushort width;
        public ushort height;
        private Color[] data;
        public Bitmap(ushort width, ushort height)
        {
            this.width = width;
            this.height = height;
            data = new Color[width * height];
        }
        public Bitmap(ushort width, ushort height, Color fillColor)
        {
            this.width = width;
            this.height = height;
            data = new Color[width * height];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = fillColor;
            }
        }
        public Bitmap(ushort width, ushort height, Color[] data)
        {
            this.width = width;
            this.height = height;
            this.data = data;
        }
        public void SetPixel(int x, int y, Color color)
        {
            data[(y * width) + x] = color;
        }
        public Color GetPixel(int x, int y)
        {
            return data[(y * width) + x];
        }
        public void SetData(Color[] data)
        {
            this.data = data;
        }
        public Color[] GetData()
        {
            return data;
        }
    }
}