using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Utilitie
{
    /// <summary>
    /// model item apriori
    /// </summary>
    public class AprioriItem
    {
        /// <summary>
        /// X
        /// </summary>
        public IEnumerable<string> X { get; set; }

        /// <summary>
        /// Y
        /// </summary>
        public IEnumerable<string> Y { get; set; }

        /// <summary>
        /// Support
        /// </summary>
        public string Support { get; set; }

        /// <summary>
        /// Confidence
        /// </summary>
        public string Confidence { get; set; }
    }
}
