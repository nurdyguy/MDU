using System;
using System.Collections.Generic;
using System.Text;

using EulerService.Contracts;

using _calc = MathService.Calculators.Calculator;

namespace EulerService.Implementations
{
    public partial class EulerService : IEulerService
    {
        
        public EulerService()
        {
            
            //Calculator.InitCalculator();  //------------------------------------------------
        }
    }
}
