using FluentV.Core.Enums;
using System.Collections.Generic;

namespace FluentV.Core.Rules
{
    public class Rule
    {
        public string Message { get; set; }
        public EValidationType ValidationType { get; set; }
        public List<object> AcceptedValues { get; set; } = new List<object>();
    }
}
