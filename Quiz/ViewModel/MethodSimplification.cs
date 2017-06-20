using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.ViewModel
{
    public class MethodSimplification
    {
        /// <summary>
        /// Simplified boolean method
        /// </summary>
        /// <param name="first">First Input</param>
        /// <param name="second">Second Input</param>
        /// <param name="third">Third Input</param>
        /// <returns></returns>
        public string AMethod(bool first, bool second, bool third)
        {
            if ((!first && (second && !second)) || (!third && !second))
            {
                // Return option one
                return TestEnum.Option1.ToString();
            }

            // Return option two
            return TestEnum.Option2.ToString();
        }

        public enum TestEnum
        {
            Option1,
            Option2,
        }
    }
}
