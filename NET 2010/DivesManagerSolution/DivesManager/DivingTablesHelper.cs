using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DivesManager
{
    public enum DecompressionGroupEnum
    {
        A = 0, B, C, D, E, F, G, H, I, J, K, L, M, N
    }

    public class DivingTablesHelper
    {
        #region Fields
        private static readonly Dictionary<int, int[]> _tableA = new Dictionary<int, int[]>();
        private static readonly Dictionary<DecompressionGroupEnum, int[]> _tableB = new Dictionary<DecompressionGroupEnum, int[]>();
        private static readonly Dictionary<int, int[]> _tableC = new Dictionary<int, int[]>();
        #endregion

        #region CTOR
        static DivingTablesHelper()
        {
            InitTableA();
            InitTableB();
            InitTableC();
        }
        #endregion

        #region Public
        public static int GetNitrogenDebt(DecompressionGroupEnum group, int depth)
        {
            if (depth == 0) return 0;
            int groupNumber = (int)group;
            int[] groupArray = _tableC[depth];
            return groupArray[groupNumber];
        }

        public static DecompressionGroupEnum GetGroupAfterResting(DecompressionGroupEnum preGroup, int time)
        {
            int[] groupArray = _tableB[preGroup];
            for (int a = 0; a < groupArray.Length; a++)
            {
                if (time <= groupArray[a]) return (DecompressionGroupEnum)((int)preGroup - a);
            }
            return DecompressionGroupEnum.A;
        }

        public static DecompressionGroupEnum GetDecompGroup(int depth, int minutes, int prevNitrogenDebt)
        {
            if(depth==0)return DecompressionGroupEnum.A;
            int[] groupArray = _tableA[depth];
            int maxTime = minutes + prevNitrogenDebt;
            for (int a = 0; a < groupArray.Length; a++)
            {
                if (groupArray[a] >= maxTime) return (DecompressionGroupEnum)a;
            }
            return DecompressionGroupEnum.N;
        }

        public static int GetMaxTimeForDepth(int depth, int prevNitrogenDebt)
        {
            if (depth <= 0) return 999;
            int[] groupArray = _tableA[depth];
            int ret = 0;
            ret = groupArray[groupArray.Length - 1] - prevNitrogenDebt;
            if (ret < 0) ret = 0;
            return ret;
        }
        #endregion

        #region Private
        private static void InitTableC()
        {
            //Nitrogen debt for depth oredered by decompression groups
            _tableC.Add(1, new int[] { 60, 120, 210, 300, 300, 300, 300, 300, 300, 300, 300, 300, 300, 300 });
            _tableC.Add(2, new int[] { 60, 120, 210, 300, 300, 300, 300, 300, 300, 300, 300, 300, 300, 300 });
            _tableC.Add(3, new int[] { 60, 120, 210, 300, 300, 300, 300, 300, 300, 300, 300, 300, 300, 300 });
            _tableC.Add(4, new int[] { 35, 70, 110, 160, 225, 350, 350, 350, 350, 350, 350, 350, 350, 350 });
            _tableC.Add(5, new int[] { 25, 50, 75, 100, 135, 180, 240, 325, 325, 325, 325, 325, 325, 325 });
            _tableC.Add(6, new int[] { 25, 50, 75, 100, 135, 180, 240, 325, 325, 325, 325, 325, 325, 325 });
            _tableC.Add(7, new int[] { 20, 35, 55, 75, 100, 125, 160, 195, 245, 315, 315, 315, 315, 315 });
            _tableC.Add(8, new int[] { 15, 30, 45, 60, 75, 95, 120, 145, 170, 205, 250, 310, 310, 310 });
            _tableC.Add(9, new int[] { 15, 30, 45, 60, 75, 95, 120, 145, 170, 205, 250, 310, 310, 310 });
            _tableC.Add(10, new int[] { 5, 15, 25, 40, 50, 60, 80, 100, 120, 140, 270, 270, 270, 270 });
            _tableC.Add(11, new int[] { 7, 17, 25, 37, 49, 61, 73, 87, 101, 116, 213, 213, 213, 213 });
            _tableC.Add(12, new int[] { 7, 17, 25, 37, 49, 61, 73, 87, 101, 116, 213, 213, 213, 213 });
            _tableC.Add(13, new int[] { 6, 13, 21, 29, 38, 47, 56, 66, 76, 87, 99, 111, 124, 142 });
            _tableC.Add(14, new int[] { 6, 13, 21, 29, 38, 47, 56, 66, 76, 87, 99, 111, 124, 142 });
            _tableC.Add(15, new int[] { 6, 13, 21, 29, 38, 47, 56, 66, 76, 87, 99, 111, 124, 142 });
            _tableC.Add(16, new int[] { 5, 11, 17, 24, 30, 36, 44, 52, 61, 70, 79, 88, 97, 107 });
            _tableC.Add(17, new int[] { 5, 11, 17, 24, 30, 36, 44, 52, 61, 70, 79, 88, 97, 107 });
            _tableC.Add(18, new int[] { 5, 11, 17, 24, 30, 36, 44, 52, 61, 70, 79, 88, 97, 107 });
            _tableC.Add(19, new int[] { 4, 9, 15, 20, 26, 31, 37, 43, 50, 57, 64, 72, 80, 87 });
            _tableC.Add(20, new int[] { 4, 9, 15, 20, 26, 31, 37, 43, 50, 57, 64, 72, 80, 87 });
            _tableC.Add(21, new int[] { 4, 9, 15, 20, 26, 31, 37, 43, 50, 57, 64, 72, 80, 87 });
            _tableC.Add(22, new int[] { 4, 8, 13, 18, 23, 28, 32, 38, 43, 43, 54, 61, 68, 73 });
            _tableC.Add(23, new int[] { 4, 8, 13, 18, 23, 28, 32, 38, 43, 43, 54, 61, 68, 73 });
            _tableC.Add(24, new int[] { 4, 8, 13, 18, 23, 28, 32, 38, 43, 43, 54, 61, 68, 73 });
            _tableC.Add(25, new int[] { 3, 7, 11, 16, 20, 24, 29, 33, 38, 43, 47, 53, 58, 64 });
            _tableC.Add(26, new int[] { 3, 7, 11, 16, 20, 24, 29, 33, 38, 43, 47, 53, 58, 64 });
            _tableC.Add(27, new int[] { 3, 7, 11, 16, 20, 24, 29, 33, 38, 43, 47, 53, 58, 64 });
            _tableC.Add(28, new int[] { 3, 7, 10, 14, 18, 22, 26, 30, 34, 38, 43, 48, 52, 57 });
            _tableC.Add(29, new int[] { 3, 7, 10, 14, 18, 22, 26, 30, 34, 38, 43, 48, 52, 57 });
            _tableC.Add(30, new int[] { 3, 7, 10, 14, 18, 22, 26, 30, 34, 38, 43, 48, 52, 57 });
        }

        private static void InitTableB()
        {
            //time in minutes for given group to change X groups
            _tableB.Add(DecompressionGroupEnum.A, new int[] { 720 });
            _tableB.Add(DecompressionGroupEnum.B, new int[] { 130, 720 });
            _tableB.Add(DecompressionGroupEnum.C, new int[] { 100, 170, 720 });
            _tableB.Add(DecompressionGroupEnum.D, new int[] { 70, 160, 350, 720 });
            _tableB.Add(DecompressionGroupEnum.E, new int[] { 55, 118, 203, 393, 720 });
            _tableB.Add(DecompressionGroupEnum.F, new int[] { 46, 90, 149, 238, 426, 720 });
            _tableB.Add(DecompressionGroupEnum.G, new int[] { 41, 76, 120, 179, 266, 456, 720 });
            _tableB.Add(DecompressionGroupEnum.H, new int[] { 37, 67, 102, 144, 201, 290, 480, 720 });
            _tableB.Add(DecompressionGroupEnum.I, new int[] { 34, 60, 90, 123, 165, 224, 313, 502, 720 });
            _tableB.Add(DecompressionGroupEnum.J, new int[] { 32, 55, 80, 108, 141, 185, 243, 341, 521, 720 });
            _tableB.Add(DecompressionGroupEnum.K, new int[] { 29, 50, 72, 96, 124, 159, 202, 260, 349, 539, 720 });
            _tableB.Add(DecompressionGroupEnum.L, new int[] { 27, 46, 65, 86, 110, 140, 174, 217, 276, 363, 553, 720 });
            _tableB.Add(DecompressionGroupEnum.M, new int[] { 26, 43, 60, 79, 100, 126, 155, 189, 233, 290, 379, 569, 720 });
            _tableB.Add(DecompressionGroupEnum.N, new int[] { 25, 40, 55, 72, 91, 114, 139, 168, 203, 245, 304, 213, 488, 720 });
        }


        private static void InitTableA()
        {
            //Time in minutes for given depth to end in group
            _tableA.Add(1, new int[] { 60, 120, 210, 300 });
            _tableA.Add(2, new int[] { 60, 120, 210, 300 });
            _tableA.Add(3, new int[] { 60, 120, 210, 300 });
            _tableA.Add(4, new int[] { 35, 70, 110, 160, 225, 350 });
            _tableA.Add(5, new int[] { 35, 70, 110, 160, 225, 350 });
            _tableA.Add(6, new int[] { 25, 50, 75, 100, 135, 180, 240, 325 });
            _tableA.Add(7, new int[] { 25, 50, 75, 100, 135, 180, 240, 325 });
            _tableA.Add(8, new int[] { 15, 30, 45, 60, 75, 95, 120, 145, 170, 205, 250, 310 });
            _tableA.Add(9, new int[] { 15, 30, 45, 60, 75, 95, 120, 145, 170, 205, 250, 310 });
            _tableA.Add(10, new int[] { 5, 15, 25, 40, 50, 60, 80, 100, 120, 140, 160, 190, 220, 270 });
            _tableA.Add(11, new int[] { 5, 15, 25, 30, 40, 50, 70, 80, 100, 110, 130, 150, 170 });
            _tableA.Add(12, new int[] { 5, 15, 25, 30, 40, 50, 70, 80, 100, 110, 130, 150, 170 });
            _tableA.Add(13, new int[] { 0, 10, 15, 25, 30, 40, 50, 60, 70, 80, 90 });
            _tableA.Add(14, new int[] { 0, 10, 15, 25, 30, 40, 50, 60, 70, 80, 90 });
            _tableA.Add(15, new int[] { 0, 10, 15, 25, 30, 40, 50, 60, 70, 80, 90 });
            _tableA.Add(16, new int[] { 0, 10, 15, 20, 25, 30, 40, 50, 55 });
            _tableA.Add(17, new int[] { 0, 10, 15, 20, 25, 30, 40, 50, 55 });
            _tableA.Add(18, new int[] { 0, 10, 15, 20, 25, 30, 40, 50, 55 });
            _tableA.Add(19, new int[] { 0, 5, 10, 15, 20, 30, 35, 40, 45 });
            _tableA.Add(20, new int[] { 0, 5, 10, 15, 20, 30, 35, 40, 45 });
            _tableA.Add(21, new int[] { 0, 5, 10, 15, 20, 30, 35, 40, 45 });
            _tableA.Add(22, new int[] { 0, 5, 10, 15, 20, 25, 30, 35 });
            _tableA.Add(23, new int[] { 0, 5, 10, 15, 20, 25, 30, 35 });
            _tableA.Add(24, new int[] { 0, 5, 10, 15, 20, 25, 30, 35 });
            _tableA.Add(25, new int[] { 0, 5, 10, 12, 15, 20, 25 });
            _tableA.Add(26, new int[] { 0, 5, 10, 12, 15, 20, 25 });
            _tableA.Add(27, new int[] { 0, 5, 10, 12, 15, 20, 25 });
            _tableA.Add(28, new int[] { 0, 5, 7, 10, 15, 20, 22 });
            _tableA.Add(29, new int[] { 0, 5, 7, 10, 15, 20, 22 });
            _tableA.Add(30, new int[] { 0, 5, 7, 10, 15, 20, 22 });
            _tableA.Add(31, new int[] { 0, 0, 5, 10, 13, 15 });
            _tableA.Add(32, new int[] { 0, 0, 5, 10, 13, 15 });
            _tableA.Add(33, new int[] { 0, 0, 5, 10, 13, 15 });
            _tableA.Add(34, new int[] { 0, 0, 5, 10, 12 });
            _tableA.Add(35, new int[] { 0, 0, 5, 10, 12 });
            _tableA.Add(36, new int[] { 0, 0, 5, 10, 12 });
            _tableA.Add(37, new int[] { 0, 0, 5, 8 });
            _tableA.Add(38, new int[] { 0, 0, 5, 8 });
            _tableA.Add(39, new int[] { 0, 0, 5, 8 });
            _tableA.Add(40, new int[] { 0, 0, 5, 7 });
            _tableA.Add(41, new int[] { 0, 0, 5, 7 });
            _tableA.Add(42, new int[] { 0, 0, 5, 7 });
        }
        #endregion

    }
}