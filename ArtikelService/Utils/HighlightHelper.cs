namespace ArtikelService.Utils
{
    public class HighlightHelper
    {
        //private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static bool IsNew(string url)
        {
            try
            {
                return set.Contains(url);
            }
            catch (Exception ex)
            {
                //Log.Error(ex);
            }
            return false;
        }

        private static System.Collections.Generic.HashSet<string> set = new HashSet<string>();

        public static void AddUrl(string url)
        {
            try
            {
                if (!set.Contains(url))
                    set.Add(url);
            }
            catch (Exception ex)
            {
                //Log.Error(ex);
            }
        }

    }
}
