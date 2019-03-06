using System;
using System.Reactive.Subjects;
using Common;

namespace SamplesProviders
{
    public abstract class DataProviderBase : StartableBase
    {
        protected Subject<float[]> OnSamplesSubject = new Subject<float[]>();
        public IObservable<float[]> OnSamples => OnSamplesSubject;
    }
}
