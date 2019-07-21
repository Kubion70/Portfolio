using Portfolio.Core.LogicAbstractions;
using System;
using System.Threading.Tasks;

namespace Portfolio.BusinessLogic.Sample
{
    public class SampleLogic : Logic<SampleLogicIncomer, SampleLogicResult>
    {
        protected async override Task<SampleLogicResult> Execute(SampleLogicIncomer incomer)
        {
            throw new NotImplementedException();
        }
    }
}
