using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.BusinessPack.Controls;
using DotVVM.BusinessPack.Filters;
using DotVVM.Framework.ViewModel;

namespace BasicEcx.Test.GridView
{
    public class FilterTest1ViewModel : DotvvmViewModelBase
    {

        public BusinessPackDataSet<Customer> Customers { get; set; } = new BusinessPackDataSet<Customer>
        {
            PagingOptions = { /*PageSize = 10 */}
        };


        public string OrderFilter { get; set; }

        public override Task PreRender()
        {
            // you can initialize default filters
            if (!Context.IsPostBack)
            {
                Customers.FilteringOptions = new FilteringOptions()
                {
                    FilterGroup = new FilterGroup()
                    {
                        Filters = new List<FilterBase>()
                        {
                            new FilterCondition() { FieldName = "Name", Operator = FilterOperatorType.Contains, Value = "1" }
                        },
                        Logic = FilterLogicType.And
                    }
                };
            }

            // refresh data
            if (Customers.IsRefreshRequired)
            {
                Customers.LoadFromQueryable(GetQueryable(13));
            }

            return base.PreRender();
        }

        public void OnOrderFilterChanged()
        {
            // do your logic
            Customers.RequestRefresh();
        }

        private IQueryable<Customer> GetQueryable(int size)
        {
            var numbers = new List<Customer>();
            for (var i = 0; i < size; i++)
            {
                numbers.Add(new Customer
                {
                    Id = i + 1, 
                    Name = $"Customer {i + 1}", 
                    BirthDate = DateTime.Now.AddYears(-i), 
                    Orders = i
                });
            }
            return numbers.AsQueryable();
        }


        #region Helper Classes

        public class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string LastName => !string.IsNullOrWhiteSpace(Name) ? Name.Split(' ').LastOrDefault() : "";
            public DateTime BirthDate { get; set; }
            public int Orders { get; set; }
        }

        #endregion Helper Classes

    }


}

