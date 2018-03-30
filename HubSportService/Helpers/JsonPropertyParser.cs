using System;

namespace HubSportService.Helpers
{
  internal static class JsonPropertyParser
    {
       internal static string GetPropertyValue(dynamic properties, string prpertyName )
        {
            try //TODO add condition
            {
                return  properties[prpertyName].value;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                return string.Empty;
            }
        }
    }
}
