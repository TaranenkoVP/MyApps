using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Data.Core.Constants;

namespace MyForum.Business.Core.Infrastructure
{
    public static class ConstantsBusiness
    {
        /// <summary>
        /// Static string Dictionary for constants
        /// </summary>
        private static Dictionary<string, string> _dictionary = AppConstants.GetConstantsAll;

        /// <summary>
        /// Access the Dictionary from external sources
        /// </summary>
        public static string GetConstant(string word)
        {
            // Try to get the result in the static Dictionary
            string result;
            if (_dictionary.TryGetValue(word, out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Access the Dictionary from external sources
        /// </summary>
        public static Dictionary<string, string> GetConstantsAll
        {
            get
            {
                return _dictionary;
            }
        }
    }
}
