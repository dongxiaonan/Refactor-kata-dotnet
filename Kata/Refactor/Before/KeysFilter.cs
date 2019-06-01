using System.Collections.Generic;
using System.Linq;

namespace Kata.Refactor.Before
{
    public class KeysFilter
    {
        public ISessionService SessionService { get; set; }
        
        public List<string> Filter(IList<string> marks, bool isGoldenKey)
        {

            if (marks == null || marks.Count == 0)
            {
                return new List<string>();
            }

            var markList = new MarkList(marks);

            return markList.Filter(isGoldenKey, GetSavedMarkList(isGoldenKey))
                .Select(x => x.Convert())
                .ToList();
        }

        private MarkList GetSavedMarkList(bool isGoldenKey)
        {
            if (isGoldenKey)
            {
                return new MarkList(SessionService.Get<List<string>>("GoldenKey").ToList());
            }

            var keys = new List<string>();
            var SilverKeys = SessionService.Get<List<string>>("SilverKey");
            var CopperKeys = SessionService.Get<List<string>>("CopperKey");

            keys.AddRange(SilverKeys);
            keys.AddRange(CopperKeys);

            return new MarkList(keys);
        }
    }

    public interface ISessionService
    {
        IEnumerable<string> Get<T>(string sessionKey);
    }
}