using System.Configuration;
using System.Reflection;

namespace Sower.IDataAccess
{
     public class DataAccess
     {
         private static readonly string path = ConfigurationManager.AppSettings["WebDAL"];

         private static object CreateObject(string path, string CacheKey)
         {
             object objType = DataCache.GetCache(CacheKey);
             if (objType == null)
             {
                 try
                 {
                     objType = Assembly.Load(path).CreateInstance(CacheKey);
                     DataCache.SetCache(CacheKey, objType);
                 }
                 catch { }
             }
             return objType;
         }

         private static object CreateObjectNoCache(string path, string CacheKey)
         {
             try
             {
                 return Assembly.Load(path).CreateInstance(CacheKey);
             }
             catch
             {
                 return null;
             }
         }

         public static IDB_Article CreateIDB_Article()
         {
             string CacheKey = path + ".DB_Article";
             return (IDB_Article)CreateObject(path, CacheKey);

         }
         public static IDB_Product CreateIDB_Product()
         {
             string CacheKey = path + ".DB_Product";
             return (IDB_Product)CreateObject(path, CacheKey);
         }

         public static IDB_AverageUser CreateIDB_AverageUser()
         {
             string CacheKey = path + ".DB_AverageUser";
             return (IDB_AverageUser)CreateObject(path, CacheKey);
         }

         public static IDB_LearnCard CreateIDB_LearnCard()
         {
             string CacheKey = path + ".DB_LearnCard";
             return (IDB_LearnCard)CreateObject(path, CacheKey);
         }

         public static IDB_ExamFile CreateIDB_ExamFile()
         {
             string CacheKey = path + ".DB_ExamFile";
             return (IDB_ExamFile)CreateObject(path, CacheKey);
         }

         public static IDB_UserFeedback CreateIDB_UserFeedback()
         {
             string CacheKye = path + ".DB_UserFeedback";
             return (IDB_UserFeedback)CreateObject(path, CacheKye);
         }

         public static IDB_ExamType CreateIDB_ExamType()
         {
             string CacheKye = path + ".DB_ExamType";
             return (IDB_ExamType)CreateObject(path, CacheKye);
         }
    }
}
