using System.Collections.Specialized;

namespace Examples.Chapter6
{
   public static class NameValueCollectionExt
   {
      public static Option<string> Lookup
         (this NameValueCollection @this, string key)
         => @this[key];
   }
}
