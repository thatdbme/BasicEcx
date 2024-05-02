using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.BusinessPack.Controls;
using DotVVM.BusinessPack.Filters;
using DotVVM.Framework.ViewModel;

namespace BasicEcx.Test.GridView
{
    public class FilterTest2ViewModel : DotvvmViewModelBase
    {
        public BusinessPackDataSet<Customer> Customers { get; set; } = new BusinessPackDataSet<Customer>
        {
            PagingOptions = { /*PageSize = 10 */}
        };


        public string OrderFilter { get; set; }

        public override Task PreRender()
        {
            // refresh data
            if (Customers.IsRefreshRequired)
            {
                Customers.LoadFromQueryable(GetQueryable(24));
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
                    Orders = i,
                    HasPremiumSupport = (i % 2.5) > 1
                });
            }
            return numbers.AsQueryable();
        }


        #region Helper Classes

        public class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Name2 => Name;
            public string LastName => !string.IsNullOrWhiteSpace(Name) ? Name.Split(' ').LastOrDefault() : "";
            public DateTime BirthDate { get; set; }
            public int Orders { get; set; }
            public bool HasPremiumSupport { get; set; }
        }

        #endregion Helper Classes
    }


}

