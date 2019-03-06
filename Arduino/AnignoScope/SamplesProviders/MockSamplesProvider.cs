using System;
using System.Threading.Tasks;
using Common;

namespace SamplesProviders
{
    public class MockSamplesProvider : DataProviderBase
    {
        protected override Result StartInit()
        {
            Task.Factory.StartNew(SamplesCreationHandler);
            return new Result(ResultEnum.Passed);
        }

        private void SamplesCreationHandler()
        {
            throw new NotImplementedException();
        }

        protected override void StopInit()
        {
            
        }
    }
}