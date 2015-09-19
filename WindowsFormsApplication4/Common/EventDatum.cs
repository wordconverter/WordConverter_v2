using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WordConverter_v2.Common
{
    public class EventDatum
    {
        public static Delegate GetEventHandler(object obj, string eventName)
        {
            EventHandlerList ehl = GetEvents(obj);
            object key = GetEventKey(obj, eventName);
            return ehl[key];
        }

        private delegate MethodInfo delGetEventsMethod(Type objType, delGetEventsMethod callback);

        public static EventHandlerList GetEvents(object obj)
        {
            delGetEventsMethod GetEventsMethod = delegate(Type objtype, delGetEventsMethod callback)
            {
                MethodInfo mi = objtype.GetMethod("get_Events", All);
                if ((mi == null) & (objtype.BaseType != null))
                    mi = callback(objtype.BaseType, callback);
                return mi;
            };

            MethodInfo methodInfo = GetEventsMethod(obj.GetType(), GetEventsMethod);
            if (methodInfo == null) return null;
            return (EventHandlerList)methodInfo.Invoke(obj, new object[] { });
        }



        private delegate FieldInfo delGetKeyField(Type objType, string eventName, delGetKeyField callback);
        private static object GetEventKey(object obj, string eventName)
        {
            delGetKeyField GetKeyField = delegate(Type objtype, string eventname, delGetKeyField callback)
            {
                FieldInfo fi = objtype.GetField("Event" + eventName, All);
                if ((fi == null) & (objtype.BaseType != null))
                    fi = callback(objtype.BaseType, eventName, callback);
                return fi;
            };

            FieldInfo fieldInfo = GetKeyField(obj.GetType(), eventName, GetKeyField);
            if (fieldInfo == null) return null;
            return fieldInfo.GetValue(obj);
        }



        private static BindingFlags All
        {
            get
            {
                return
                    BindingFlags.Public |
                    BindingFlags.NonPublic |
                    BindingFlags.Instance |
                    BindingFlags.IgnoreCase |
                    BindingFlags.Static;
            }
        }
    }
}
