namespace AnignoraCommonAndHelpers.Tracers
{
    public class TracerNull : ITracer
    {
        public void Trace(string p_format, params object[] p_params)
        {
            //Nothing
        }
    }
}