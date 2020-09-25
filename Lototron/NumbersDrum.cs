using System;
using System.Collections.Generic;
using System.Linq;

namespace SimLoto
{
    public class NumbersDrum
    {
        public const int KegsCount = 15;

        private ICollection<KeyValuePair<int, int>> _numberKegs;

        public IEnumerable<int> NumberKegs
        {
            get
            {
                return _numberKegs.OrderBy(x => x.Key).Select(x => x.Value);
            }
        }

        public NumbersDrum()
        {
            _numberKegs = new List<KeyValuePair<int, int>>();

            var randomGenerator = new Random();

            for (var i = 0; i < KegsCount; i++)
            {
                var keg = new KeyValuePair<int, int>(randomGenerator.Next(int.MaxValue), i);
                _numberKegs.Add(keg);
            }
        }
    }
}