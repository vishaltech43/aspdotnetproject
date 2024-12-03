﻿using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EmployeeManagement.Models
{
    public class CommaSeparatedModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            //ModelType: Gets the model type represented by the current instance
            if (context.Metadata.ModelType == typeof(List<int>))
            {
                return new CommaSeparatedModelBinder();
            }
            return null;
        }
    }
}
