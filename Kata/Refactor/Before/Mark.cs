namespace Kata.Refactor.Before
{
    public class Mark
    {
        public Mark(string mark)
        {
            _mark = mark;
        }

        private string _mark { get; set; }

        public bool IsFake()
        {
            return _mark.EndsWith("FAKE");
        }

        public bool IsGoldenTwo()
        {
            return _mark.StartsWith("GD02");
        }

        public bool IsValidateGoldenMark(Mark mark)
        {
            return IsGoldenOne() && HasSameKeyWithGoldenOne(mark);
        }

        private bool HasSameKeyWithGoldenOne(Mark mark)
        {
            return mark._mark.Substring(4, 6).Equals(_mark.Substring(4, 6));
        }

        private bool IsGoldenOne()
        {
            return _mark.StartsWith("GD01");
        }

        public string Convert()
        {
            return _mark;
        }

        public override bool Equals(object obj)
        {
            return ((Mark)obj)._mark == this._mark;
        }
    }
}