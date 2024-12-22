using System;
using System.Collections.Generic;

namespace FluentV.Core.Rules
{
    public class RuleInfo
    {
        public RuleInfo(Type propertyType)
        {
            PropertyType = propertyType;
        }

        public Type PropertyType { get; private set; }
        public List<Rule> Rules { get; private set; } = new List<Rule>();
    }
}
