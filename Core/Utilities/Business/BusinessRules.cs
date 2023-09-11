using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {

        //params ile IResult turunde virgulle ayirarak istediginiz kadar parametre ekleyebilirsiniz demek
        public static IResult Run(params IResult[] logics)//>>>> logic burada kural demek
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }


            }

            return null;
        }


    }
}
