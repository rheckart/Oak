using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSpec;
using System.Dynamic;
using System.Reflection;
using Oak.Tests.describe_Gemini.Classes;

namespace Oak.Tests.describe_Gemini
{
    class describe_get_member : _describe_Gemini
    {
        void retrieving_member()
        {
            it["retrieves value with exact casing"] = () =>
                (Gemini().GetMember("Title") as string).should_be("Some Name");

            it["retrieves value with exact case insensitive"] = () =>
                (Gemini().GetMember("title") as string).should_be("Some Name");

            it["throws invalid op if property doesn't exist"] =
                expect<InvalidOperationException>(() => Gemini().GetMember("FooBar"));
        }
    }
}
