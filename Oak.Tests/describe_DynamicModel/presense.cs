﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSpec;
using Oak.Tests.describe_DynamicModel.SampleClasses;

namespace Oak.Tests.describe_DynamicModel
{
    class presense : nspec
    {
        dynamic book;

        bool isValid;

        void before_each()
        {
            book = new Book();
        }

        void validating_presense_of()
        {
            act = () => isValid = book.IsValid();

            context["title is empty"] = () => 
            {
                before = () => book.Title = string.Empty;

                it["is not valid"] = () => isValid.should_be_false();
            };

            context["body is populated, but title is empty"] = () =>
            {
                before = () => book.Body = "Body";

                it["is not valid"] = () => isValid.should_be_false();
            };

            context["title and body is populated"] = () =>
            {
                before = () =>
                {
                    book.Title = "Some Title";
                    book.Body = "Some Body";
                };

                it["is valid"] = () => isValid.should_be_true();
            };
        }
    }
}
