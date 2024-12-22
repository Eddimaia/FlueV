using FluentV.Core.Enums;
using System;
using System.Collections.Generic;

namespace FluentV.Core.Rules
{
    public class Rule
    {
        public Rule(string message, EValidation validation)
        {
            Message = message;
            Validation = validation;
        }

        public Rule(string message, EValidation validation, List<object> acceptedValues)
        {
            Message = message;
            Validation = validation;
            AcceptedValues = acceptedValues;
        }

        public string Message { get; private set; }
        public EValidation Validation { get; private set; }
        public List<object> AcceptedValues { get; private set; } = new List<object>();
    }
}
