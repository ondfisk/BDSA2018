using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace BDSA2018.Lecture03
{
    class Notes
    {
        void Hamlet()
        {
            var text = File.ReadAllText("Hamlet.txt");

            var words = Regex.Split(text, @"\P{L}+");

            var histogram = from w in words
                            group w by w into h
                            let c = h.Count()
                            orderby c descending
                            select new { Word = h.Key, Count = c };

            histogram.Take(5);//.Print();

            // Dictionary
            // LO
        }
    }
}
