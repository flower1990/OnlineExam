using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace System.ComponentModel.DataAnnotations
{
    public class MaxWordsAttribute : ValidationAttribute, IClientValidatable
    {
        public int WordCount { get; set; }

        public MaxWordsAttribute(int wordCount)
            : base("{0} has too many words")
        {
            WordCount = wordCount;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var wordCount = value.ToString().ToList().Count;
                if (wordCount > WordCount)
                {
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
            }

            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
            rule.ValidationParameters.Add("wordcount", WordCount);
            rule.ValidationType = "maxwords";
            yield return rule;
        }
    }
}