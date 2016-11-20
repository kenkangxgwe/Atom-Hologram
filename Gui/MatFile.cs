namespace HologramGenerator
{
    class MatFile
    {
        public string Filename { get; set; }
        private MatlabFunction.MatFileMethod Mf = null;

        public MatFile(string File)
        {
            this.Filename = File;
        }

        public string LastIteration()
        {
            Mf = new MatlabFunction.MatFileMethod();
            return Mf.GetLastIteration(this.Filename).ToString();
        }
    }
}
