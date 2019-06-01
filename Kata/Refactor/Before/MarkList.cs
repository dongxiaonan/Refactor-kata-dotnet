using System.Collections.Generic;
using System.Linq;

namespace Kata.Refactor.Before
{
    public class MarkList
    {
        public MarkList(IList<string> marks)
        {
            Marks = marks.Select(x => new Mark(x)).ToList();
        }

        private IList<Mark> Marks { get; set; }

        private MarkList FilterForGoldenKeys(bool isGoldenKey)
        {
            if (!isGoldenKey)
            {
                return this;
            }
            
            var golden02Mark = Marks.Where(x => x.IsGoldenTwo()).ToList();
            
            foreach (var mark in golden02Mark)
            {
                if (!Validate(mark))
                {
                    Marks.Remove(mark);
                }
            }

            return this;
        }

        private bool Validate(Mark mark)
        {
            return Marks.Any(x => x.IsValidateGoldenMark(mark));
        }

        private List<Mark> FilterForSavedKeys(MarkList savedKeys)
        {
            return Marks.Where(mark => savedKeys.Contains(mark) || mark.IsFake()).ToList();
        }

        private bool Contains(Mark mark)
        {
            return Marks.Contains(mark);
        }

        public List<Mark> Filter(bool isGoldenKey, MarkList getSavedMarkList)
        {
            return FilterForGoldenKeys(isGoldenKey).FilterForSavedKeys(getSavedMarkList);
        }
    }
}