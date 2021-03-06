using System.Collections.Generic;
using cqhttp.Cyan.Enums;
using cqhttp.Cyan.Messages;

namespace CyanBot.Functions {
    public class Repeater {
        static Dictionary < (MessageType, long), Message > last =
            new Dictionary < (MessageType, long), Message > ();
        static Dictionary < (MessageType, long), bool > repeated =
            new Dictionary < (MessageType, long), bool > ();
        public static void Register () {
            FunctionPool.onAny.Add (
                (endPoint, message) => {
                    if (last.ContainsKey (endPoint) && last[endPoint] == message) {
                        if (repeated[endPoint] == false) {
                            repeated[endPoint] = true;
                            return message;
                        }
                    } else {
                        last[endPoint] = message;
                        repeated[endPoint] = false;
                    }
                    return new Message ();
                }
            );
        }
    }
}