using System;

namespace BusinessLogic
{
    public class common
    {
        public static bool CheckInjection(string querystring)
        {
            try
            {
                if (querystring.Length < 350)
                {
                    querystring = querystring.ToLower();
                    string[] array_split_item = new string[] { "–", ";", "*", "<", ">", "select", "@@", "@", "char", "nchar", "varchar", "nvarchar", "alter", "begin", "cast", "create", "cursor", "declare", "drop", "end", "exec", "execute", "fetch", "kill", "open", "sys", "sysobjects", "syscolumns", "table", "xtype", "<script>", "script", "</script>", "‘" };
                    int lowerbound = array_split_item.GetLowerBound(0);
                    int uperbound = array_split_item.GetUpperBound(0);
                    foreach (char item in querystring)
                    {
                        for (int array_counter = lowerbound; array_counter <= uperbound; array_counter++)
                        {
                            bool sts = querystring.Contains(array_split_item[array_counter]);
                            if (sts)
                            {
                                return true;
                            }
                        }
                    }
                }
                else
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static string LogFilePath()
        {
            //Folder path
             return @"D:\Vinod\LogFile\{0}";          
        }
        public static string FilePath()
        {
            //Folder path
            return @"D:\arai";
        }
    }
}
