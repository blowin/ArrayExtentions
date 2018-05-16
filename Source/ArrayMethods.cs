namespace ArrayMethods
{
    public static class ArrayExtentions
    {
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
        
        public static bool Map<T>(this T[,] obj, System.Func<T, T> handler)
        {
            return obj.ForEach((i, j, curObj) => curObj = handler(curObj));
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
    }
}
