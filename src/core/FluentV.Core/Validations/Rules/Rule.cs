using FluentV.Core.Enums;
using System;
using System.Collections.Generic;

namespace FluentV.Core.Validations.Rules
{
    public class Rule
    {
        public string Message { get; set; }
        public EValidationType ValidationType { get; set; }
        public List<object> AcceptedValues { get; set; } = new List<object>();
    }
}
