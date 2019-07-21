using Portfolio.Core.LogicAbstractions;
using System;
using System.Threading.Tasks;

namespace Portfolio.BusinessLogic.Sample
{
    public class SampleLogic : Logic<SampleLogicRequest, SampleLogicResult>
    {
        protected async override Task<SampleLogicResult> Execute(SampleLogicRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
