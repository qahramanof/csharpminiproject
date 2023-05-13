
using CodeProject1.Exceptoins;

namespace CodeProject1.Helpers;

public class Helper
{
   public static Dictionary<string,string>Errors= new Dictionary<string,string>()
   {
       {"AlReadyExistException","this object already exist" },
       {"Sizeexception","Length doesn't match " }
   };
}
