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
            
            Marks = Marks.Where(x => !x.IsGoldenTwo() || ValidateGoldenTwo(x)).ToList();

            return this;
        }

        private bool ValidateGoldenTwo(Mark mark)
        {
            return Marks.Any(x => x.IsValidateGoldenTwoMark(mark));
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