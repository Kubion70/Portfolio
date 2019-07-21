using Portfolio.Core.LogicAbstractions;
using System;
using System.Threading.Tasks;

namespace Portfolio.BusinessLogic.Sample
{
    public class SampleLogic : Logic<SampleLogicRequest, SampleLogicResult>
    {
        protected override async Task<SampleLogicResult> Execute(SampleLogicRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
