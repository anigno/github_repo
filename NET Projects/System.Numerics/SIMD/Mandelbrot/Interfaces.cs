using System;

namespace Algorithms
{
    public abstract class FractalRenderer
    {
        public delegate void Render(float xmin, float xmax, float ymin, float ymax, float step);

        private Func<bool> abort;
        private Action<int, int, int> drawPixel;
        protected const int max_iters = 1000; // Make this higher to see more detail when zoomed in (and slow down rendering a lot)

        protected FractalRenderer(Action<int, int, int> draw, Func<bool> checkAbort)
        {
            drawPixel = draw; abort = checkAbort;
        }

        protected Action<int, int, int> DrawPixel { get { return drawPixel; } }

        public bool Abort { get { return abort(); } }

        public static Render SelectRender(Action<int, int, int> draw, Func<bool> abort, bool useVectorTypes, bool doublePrecision, bool isMultiThreaded, bool useAbstractDataType, bool dontUseIntTypes = true)
        {
            if (useVectorTypes && doublePrecision)
            {
                if (dontUseIntTypes)
                {
                    var r = new VectorDoubleStrictRenderer(draw, abort);
                    if (isMultiThreaded)
                    {
                        if (useAbstractDataType)
                            return r.RenderMultiThreadedWithADT;
                        else // !useAbstractDataType
                            return r.RenderMultiThreadedNoADT;
                    }
                    else // !isMultiThreaded
                    {
                        if (useAbstractDataType)
                            return r.RenderSingleThreadedWithADT;
                        else // !useAbstractDataType
                            return r.RenderSingleThreadedNoADT;
                    }
                }
                else // !dontUseIntTypes
                {
                    var r = new VectorDoubleRenderer(draw, abort);
                    if (isMultiThreaded)
                    {
                        if (useAbstractDataType)
                            return r.RenderMultiThreadedWithADT;
                        else // !useAbstractDataType
                            return r.RenderMultiThreadedNoADT;
                    }
                    else // !isMultiThreaded
                    {
                        if (useAbstractDataType)
                            return r.RenderSingleThreadedWithADT;
                        else // !useAbstractDataType
                            return r.RenderSingleThreadedNoADT;
                    }
                }
            }
            else if (useVectorTypes && !doublePrecision)
            {
                if (dontUseIntTypes)
                {
                    var r = new VectorFloatStrictRenderer(draw, abort);
                    if (isMultiThreaded)
                    {
                        if (useAbstractDataType)
                            return r.RenderMultiThreadedWithADT;
                        else // !useAbstractDataType
                            return r.RenderMultiThreadedNoADT;
                    }
                    else // !isMultiThreaded
                    {
                        if (useAbstractDataType)
                            return r.RenderSingleThreadedWithADT;
                        else // !useAbstractDataType
                            return r.RenderSingleThreadedNoADT;
                    }
                } 
                else // !dontUseIntTypes
                {
                    var r = new VectorFloatRenderer(draw, abort);
                    if (isMultiThreaded)
                    {
                        if (useAbstractDataType)
                            return r.RenderMultiThreadedWithADT;
                        else // !useAbstractDataType
                            return r.RenderMultiThreadedNoADT;
                    }
                    else // !isMultiThreaded
                    {
                        if (useAbstractDataType)
                            return r.RenderSingleThreadedWithADT;
                        else // !useAbstractDataType
                            return r.RenderSingleThreadedNoADT;
                    }
                }
            }
            else if (!useVectorTypes && doublePrecision)
            {
                var r = new ScalarDoubleRenderer(draw, abort);
                if (isMultiThreaded)
                {
                    if (useAbstractDataType)
                        return r.RenderMultiThreadedWithADT;
                    else // !useAbstractDataType
                        return r.RenderMultiThreadedNoADT;
                }
                else // !isMultiThreaded
                {
                    if (useAbstractDataType)
                        return r.RenderSingleThreadedWithADT;
                    else // !useAbstractDataType
                        return r.RenderSingleThreadedNoADT;
                }
            }
            else // (!useVectorTypes && !doublePrecision)
            {
                var r = new ScalarFloatRenderer(draw, abort);
                if (isMultiThreaded)
                {
                    if (useAbstractDataType)
                        return r.RenderMultiThreadedWithADT;
                    else // !useAbstractDataType
                        return r.RenderMultiThreadedNoADT;
                }
                else // !isMultiThreaded
                {
                    if (useAbstractDataType)
                        return r.RenderSingleThreadedWithADT;
                    else // !useAbstractDataType
                        return r.RenderSingleThreadedNoADT;
                }
            }
        }
    }
}