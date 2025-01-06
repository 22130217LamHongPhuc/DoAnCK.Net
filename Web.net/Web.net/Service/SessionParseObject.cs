using Newtonsoft.Json;

namespace Web.net.Service;




public static class SessionParseObject
{



    public static void SetObject(this ISession session, string key, object value)
    {
        var json = JsonConvert.SerializeObject(value);
        session.SetString(key, json);  // Lưu chuỗi JSON vào session
    }

    public static T GetObject<T>(this ISession session, string key)
    {
        var json = session.GetString(key);
        if (json != null)
            
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        return default;           
    }


}
