using System.Collections.Generic;
using System.Linq;

namespace SimLoto
{
    public class Loto
    {
        NumbersDrum _numbersDrum;
        IEnumerable<int> _playedNumbers;

        public Loto()
        {
            _numbersDrum = new NumbersDrum();
            _playedNumbers = _numbersDrum.NumberKegs.Take(5).ToList();
        }

        public bool GuessNumbers(IEnumerable<int> ticket)
        {
            if (ContainsAll(_playedNumbers, ticket))
            {
                return true;
            }

            return false;
        }

        public int CountIntersects(IEnumerable<int> ticket)
        {
            var counter = 0;
            foreach (var item in ticket)
            {
                if (_playedNumbers.Contains(item))
                {
                    counter++;
                }
            }
            return counter;
        }

        private bool ContainsAll(IEnumerable<int> first, IEnumerable<int> second)
        {
            var counter = 0;
            var secondCount = 0;
            foreach (var item in second)
            {
                secondCount++;
                if (first.Contains(item))
                {
                    counter++;
                }
            }
            return counter == secondCount;
        }
    }
}