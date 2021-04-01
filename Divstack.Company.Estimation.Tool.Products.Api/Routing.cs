﻿
using System;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("Divstack.Company.Estimation.Tool.Products.IntegrationsTests")]
namespace Divstack.Company.Estimation.Tool.Products.Api
{
    internal static class Routing
    {
        private const string Host = "https://localhost/";
        internal const string ModuleBase = "api/products-module";

        internal static class Products
        {
            private const string ProductsController = Host + ModuleBase + "/" + nameof(Products) +"/" ;

            internal const string GetAll = ProductsController;
            internal const string Create = ProductsController;
            internal static string Delete(Guid id) => ProductsController + id;

            internal static class Attributes
            {
                private const string AttributesController = ProductsController + "Attributes";
                internal const string Create = AttributesController;
                internal const string Delete = AttributesController;
            }

            internal static class Categories
            {
                private const string Controller = ProductsController ;

                internal const string GetAll = Controller + nameof(GetAll);
                internal const string Create = Controller + nameof(Create);
            }
        }
    }
}
