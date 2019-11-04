namespace USC.GISResearchLab.Common.USPS.TigerZip4
{
    public class TigerZip4RecordLayout
    {
        // {start, end, length}
        public static int[] ZipCode = new int[] { 1, 5, 5 };
        public static int[] ZipPlus4 = new int[] { 6, 9, 4 };
        public static int[] TLID = new int[] { 10, 19, 10 };
        public static int[] CarrierRoute = new int[] { 20, 23, 4 };
        public static int[] StateCode = new int[] { 24, 25, 2 };
        public static int[] CountyCode = new int[] { 26, 28, 3 };
        public static int[] RLFlag = new int[] { 29, 29, 1 };
        public static int[] CensusTract = new int[] { 30, 35, 6 };
        public static int[] CensusBlock = new int[] { 36, 39, 4 };
        public static int[] FromLat = new int[] { 40, 48, 9 };
        public static int[] FromLon = new int[] { 49, 58, 10 };
        public static int[] ToLat = new int[] { 59, 67, 9 };
        public static int[] ToLon = new int[] { 68, 77, 10 };
        public static int[] PMSACode = new int[] { 78, 81, 4 };
        public static int[] CMSACode = new int[] { 82, 85, 4 };
        public static int[] MultipleMatchCode = new int[] { 86, 86, 1 };

    }
}
