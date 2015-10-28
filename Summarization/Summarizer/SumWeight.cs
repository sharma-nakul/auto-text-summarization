using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Summarization.Summarizer
{
    class SumWeight : IComparable
    {
        public int weight;
        public string line;
        public int index;
        public static int op = 0;

        #region IComparable Members

        public int CompareTo(object obj)
        {
            if (op == 0)
            {
                return ((SumWeight)obj).weight.CompareTo(weight);
            }
            else
            {
                return index.CompareTo(((SumWeight)obj).index);
            }
        }

        #endregion
    }
}
