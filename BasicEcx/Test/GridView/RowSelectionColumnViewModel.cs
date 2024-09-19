using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;
using DotVVM.BusinessPack.Controls;

namespace BasicEcx.Test.GridView
{
    public class RowSelectionColumnViewModel : DotvvmViewModelBase
    {

        public override Task PreRender()
        {
            if (PeopleRed.IsRefreshRequired)
            {
                PeopleRed.LoadFromQueryable(GetQueryable(12));
            }

            if (PeopleGreen.IsRefreshRequired)
            {
                PeopleGreen.LoadFromQueryable(GetQueryable(12));
            }

            UserSettingsRed = GetGridViewUserSettingsRed();
            UserSettingsGreen = GetGridViewUserSettingsGreen();

            return base.PreRender();
        }

        #region Red

        public BusinessPackDataSet<Person> PeopleRed { get; set; } = new BusinessPackDataSet<Person>
        {
            PagingOptions = { PageSize = 5 }
        };

        public List<int> SelectedRowIdsRed { get; set; } = new List<int>();

        public GridViewUserSettings UserSettingsRed { get; set; }

        private GridViewUserSettings GetGridViewUserSettingsRed()
        {
            var settings = new GridViewUserSettings
            {
                ColumnsSettings = new List<GridViewColumnSettings>
                {
                    new GridViewColumnSettings
                    {
                        ColumnName = "Id",
                        DisplayOrder = 0,
                        DisplayText = "Id"
                    },
                    new GridViewColumnSettings
                    {
                        ColumnName = "Name",
                        DisplayOrder = 1,
                        DisplayText = "Name"
                    },
                    new GridViewColumnSettings
                    {
                        ColumnName = "IsEven",
                        DisplayOrder = 2,
                        DisplayText = "Is Even"
                    },
                    new GridViewColumnSettings
                    {
                        ColumnName = "FavColor",
                        DisplayOrder = 3,
                        DisplayText = "Favorite Color"
                    },
                    new GridViewColumnSettings
                    {
                        ColumnName = "IsThird",
                        DisplayOrder = 4,
                        DisplayText = "Is Third"
                    }
                }
            };

            return settings;
        }


        #endregion Red

        #region Green

        public BusinessPackDataSet<Person> PeopleGreen { get; set; } = new BusinessPackDataSet<Person>
        {
            PagingOptions = { PageSize = 4 }
        };

        public List<int> SelectedRowIdsGreen { get; set; } = new List<int>();

        public GridViewUserSettings UserSettingsGreen { get; set; }

        private GridViewUserSettings GetGridViewUserSettingsGreen()
        {
            var settings = new GridViewUserSettings
            {
                ColumnsSettings = new List<GridViewColumnSettings>
                {
                    new GridViewColumnSettings
                    {
                        ColumnName = "Id",
                        DisplayOrder = 0,
                        DisplayText = "Id"
                    },
                    new GridViewColumnSettings
                    {
                        ColumnName = "Name",
                        DisplayOrder = 1,
                        DisplayText = "Name"
                    },
                    new GridViewColumnSettings
                    {
                        ColumnName = "IsEven",
                        DisplayOrder = 2,
                        DisplayText = "Is Even"
                    },
                    new GridViewColumnSettings
                    {
                        ColumnName = "FavColor",
                        DisplayOrder = 3,
                        DisplayText = "Favorite Color"
                    },
                    new GridViewColumnSettings
                    {
                        ColumnName = "IsThird",
                        DisplayOrder = 4,
                        DisplayText = "Is Third"
                    }
                }
            };

            return settings;
        }


        #endregion Green

        #region Helper Data Items

        private static IQueryable<Person> GetQueryable(int size)
        {
            var records = new List<Person>();
            for (var i = 0; i < size; i++)
            {
                records.Add(new Person
                {
                    Id = i + 1,
                    Name = $"Person {i + 1}",
                    FavColor = GetColor(i),
                    IsEven = ((i + 1) % 2) == 0,
                    IsThird = ((i + 1) % 3) == 0
                });
            }
            return records.AsQueryable();
        }

        private static string GetColor(int id)
        {
            var lastDigit = id % 10;
            var text = Colors[lastDigit];
            return text;
        }

        private static readonly List<string> Colors = new List<string>() { "Blue","Red","Green","Yellow","Magenta","Aqua","Brown","Teal","Purple","Black" };

        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string FavColor { get; set; }
            public bool IsEven { get; set; }
            public bool IsThird { get; set; }
        }

        #endregion Helper Data Items
    }
}

