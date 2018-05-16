namespace ArrayMethods
{
    public static class ArrayExtentions
    {
        public static bool AnyOf<T>(this T[,] obj, System.Func<T, bool> checkerFunc)
        {
            return obj.CommonRetunIf(checkerFunc, (first, second) => first || second, false);
        }
        
        public static bool AllOf<T>(this T[,] obj, System.Func<T, bool> checkerFunc)
        {
            return obj.CommonRetunIf(checkerFunc, (b, b1) => b && b1);
        }
        
        public static T[] Filter<T>(this T[,] obj, System.Func<T, bool> filterFunc)
        {
            if (IsInvalidArrayExtensions(obj, filterFunc))
                return null;
            
            var curElement = 0;
            var accumulateArray = new T[obj.Length];

            var array = accumulateArray;
            obj.NoCheckForEach(element =>
            {
                if (filterFunc(element))
                    array[curElement++] = element;
            });
            
            System.Array.Resize(ref accumulateArray, curElement);
            return accumulateArray;
        }

        public static T[,] To2DArray<T>(this T[] obj, uint rowCount = 1)
        {
            if (obj == null)
                throw new System.ArgumentNullException();
            
            if(rowCount == 0 || obj.Length < rowCount || obj.Length % rowCount != 0)
                throw new System.ArgumentException("Invalid row count");

            var collumnSize = (uint)(obj.Length / rowCount);
            var res = new T[rowCount, collumnSize];
            
            RangeIter(rowCount, collumnSize, (i, j) => res[i, j] = obj[i * collumnSize + j]);
            
            return res;
        }

        public static bool MapIf<T>(this T[,] obj, System.Func<T, T> handler, System.Func<T, bool> predicat)
        {
            if (predicat == null)
                return false;
            
            return obj.ForEach((i, j, curElement) =>
            {
                if (predicat(curElement))
                    obj[i, j] = handler(curElement);
            });
        }
        
        public static bool Map<T>(this T[,] obj, System.Func<T, T> handler)
        {
            return obj.ForEach((i, j, curObj) => obj[i, j] = handler(curObj));
        }
        
        public static bool ForEach<T>(this T[,] obj, System.Action<T> handler)
        {
            return obj.CommonChecker(() => obj.NoCheckForEach(handler));
        }

        public static bool ForEach<T>(this T[,] obj, System.Action<uint, uint, T> handler)
        {
            return obj.CommonChecker(() => obj.NoCheckForEach(handler));
        }

        private static bool IsInvalidArrayExtensions<T, TActionT>(T[,] obj, TActionT handler)
        {
            return obj == null || handler == null;
        }
        
        private static void NoCheckForEach<T>(this T[,] obj, System.Action<T> handler)
        {
            obj.NoCheckForEach((i, j, curObj) => handler(curObj));
        }
        
        private static bool CommonChecker<T>(this T[,] obj, System.Action handler)
        {
            if (IsInvalidArrayExtensions(obj, handler))
                return false;
            handler();
            return true;
        }
        
        private static void NoCheckForEach<T>(this T[,] obj, System.Action<uint, uint, T> handler)
        {
            var xSize = (uint)obj.GetLength(0);
            var ySize = (uint)obj.GetLength(1);
            RangeIter(xSize, ySize, (i, j) => handler(i, j, obj[i, j]));
        }
        
        private static bool CommonRetunIf<T>(this T[,] obj, 
            System.Func<T, bool> checkerFunc, 
            System.Func<bool, bool, bool> combinerFunc, bool startVal = true)
        {
            if (IsInvalidArrayExtensions(obj, checkerFunc))
                return false;

            var isAnyOf = obj.NoCheckerReturnIf((curElem, prev) => combinerFunc(prev, checkerFunc(curElem)), startVal);
            return isAnyOf.AllSucces;
        }
        
        private static FindRes NoCheckerReturnIf<T>(this T[,] obj, System.Func<T, bool, bool> handler, bool startVal)
        {
            return obj.NoCheckerReturnIf((i, j, curElem, prev) => handler(curElem, prev), startVal);
        }
        
        private static FindRes NoCheckerReturnIf<T>(this T[,] obj, System.Func<uint, uint, T, bool, bool> handler, bool startVal)
        {
            var xSize = (uint)obj.GetLength(0);
            var ySize = (uint)obj.GetLength(1);
            var res = startVal;
            for (uint i = 0; i < xSize; ++i)
            {
                for (uint j = 0; j < ySize; ++j)
                {
                    res = handler(i, j, obj[i, j], res);
                    if (res == false)
                        return FindRes.Create(false, i, j);
                }
            }

            return FindRes.Create(true, (uint)0, (uint)0);
        }
        
        public static void RangeIter(uint xSize, uint ySize, System.Action<uint, uint> handler)
        {
            for (uint i = 0; i < xSize; ++i)
            {
                for (uint j = 0; j < ySize; ++j)
                {
                    handler(i, j);
                }
            }
        }
        
        private struct FindRes
        {
            public bool AllSucces;
            public uint I;
            public uint J;

            public FindRes(bool allSucces, uint i, uint j)
            {
                AllSucces = allSucces;
                I = i;
                J = j;
            }

            public static FindRes Create(bool find = true, uint i = 0, uint j = 0)
            {
                return new FindRes(find, i, j);
            }
        }
    }
}
