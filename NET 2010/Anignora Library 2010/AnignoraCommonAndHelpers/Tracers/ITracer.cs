namespace AnignoraCommonAndHelpers.Tracers
{
    public interface ITracer
    {
        void Trace(string p_format, params object[] p_params);
    }
}
