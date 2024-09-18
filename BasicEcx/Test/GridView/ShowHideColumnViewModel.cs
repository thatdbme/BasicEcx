using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicEcx.Test.GridView
{
    public class ShowHideColumnViewModel : DotvvmViewModelBase
    {

        public bool ShowDadJoke { get; set; } = true;
        public bool ShowRowSelection { get; set; } = true;
        public bool ShowIsEven { get; set; } = true;
        public bool ShowIsThird { get; set; } = true;


        public BusinessPackDataSet<Person> People { get; set; } = new BusinessPackDataSet<Person>
        {
            PagingOptions = { /*PageSize = 10 */}
        };

        public List<int> SelectedRowIds1 { get; set; } = new List<int>();
        public List<int> SelectedRowIds2 { get; set; } = new List<int>();

        public GridViewUserSettings UserSettings1 { get; set; }
        public GridViewUserSettings UserSettings2 { get; set; }
        public GridViewUserSettings UserSettings3 { get; set; }
        public GridViewUserSettings UserSettings4 { get; set; }


        public override Task PreRender()
        {
            if (People.IsRefreshRequired)
            {
                People.LoadFromQueryable(GetQueryable(1));
            }

            UserSettings1 = GetGridViewUserSettings1();
            UserSettings2 = GetGridViewUserSettings2();
            UserSettings3 = GetGridViewUserSettings3();
            UserSettings4 = GetGridViewUserSettings4();

            return base.PreRender();
        }

        /// <summary>
        /// Dummy method to allow forcing a postback.
        /// </summary>
        public void FakePostback(){}

        private static IQueryable<Person> GetQueryable(int size)
        {
            var records = new List<Person>();
            for (var i = 0; i < size; i++)
            {
                records.Add(new Person
                {
                    Id = i + 1,
                    Name = $"Person {i + 1}",
                    DadJoke = GetSentence(i),
                    IsEven = ((i + 1) % 2) == 0,
                    IsThird = ((i + 1) % 3) == 0
                });
            }
            return records.AsQueryable();
        }

        private GridViewUserSettings GetGridViewUserSettings1()
        {
            var settings = new GridViewUserSettings();

            settings.ColumnsSettings = new List<GridViewColumnSettings>
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
                    ColumnName = "FavoriteDadJoke",
                    DisplayOrder = 3,
                    DisplayText = "Favorite Dad Joke"
                },
                new GridViewColumnSettings
                {
                    ColumnName = "IsThird",
                    DisplayOrder = 4,
                    DisplayText = "Is Third"
                }
            };

            return settings;
        }

        private GridViewUserSettings GetGridViewUserSettings2()
        {
            var settings = new GridViewUserSettings();

            settings.ColumnsSettings = new List<GridViewColumnSettings>
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
                    ColumnName = "FavoriteDadJoke",
                    DisplayOrder = 3,
                    DisplayText = "Favorite Dad Joke",
                    Visible = ShowDadJoke
                },
                new GridViewColumnSettings
                {
                    ColumnName = "IsThird",
                    DisplayOrder = 4,
                    DisplayText = "Is Third"
                },
                new GridViewColumnSettings()
                {
                    ColumnName = "SelectionColumn",
                    DisplayOrder = 5,
                    DisplayText = "Select Row",
                    Visible = ShowRowSelection
                }
            };

            return settings;
        }

        private GridViewUserSettings GetGridViewUserSettings3()
        {
            // Columns that always included
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
                    }
                }
            };

            // Columns that are sometimes included
            if (ShowIsEven)
                settings.ColumnsSettings.Add(new GridViewColumnSettings
                {
                    ColumnName = "IsEven",
                    DisplayOrder = 2,
                    DisplayText = "Is Even"
                });

            if (ShowDadJoke)
                settings.ColumnsSettings.Add(new GridViewColumnSettings
                {
                    ColumnName = "FavoriteDadJoke",
                    DisplayOrder = 3,
                    DisplayText = "Favorite Dad Joke"
                });

            if (ShowIsThird)
                settings.ColumnsSettings.Add(new GridViewColumnSettings
                {
                    ColumnName = "IsThird",
                    DisplayOrder = 4,
                    DisplayText = "Is Third"
                });


            if (ShowRowSelection)
                settings.ColumnsSettings.Add(new GridViewColumnSettings
                {
                    ColumnName = "SelectionColumn",
                    DisplayOrder = 5,
                    DisplayText = "Select Row"
                });

            return settings;
        }

        private GridViewUserSettings GetGridViewUserSettings4()
        {
            // Columns that are always included
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
                    }
                }
            };

            // Columns that are sometimes included
            settings.ColumnsSettings.Add(new GridViewColumnSettings
            {
                ColumnName = "IsEven",
                DisplayOrder = 2,
                DisplayText = "Is Even",
                Visible = ShowIsEven
            });
            settings.ColumnsSettings.Add(new GridViewColumnSettings
            {
                ColumnName = "FavoriteDadJoke",
                DisplayOrder = 3,
                DisplayText = "Favorite Dad Joke",
                Visible = ShowDadJoke
            });
            settings.ColumnsSettings.Add(new GridViewColumnSettings
            {
                ColumnName = "IsThird",
                DisplayOrder = 4,
                DisplayText = "Is Third",
                Visible = ShowIsThird
            });
            settings.ColumnsSettings.Add(new GridViewColumnSettings
            {
                ColumnName = "SelectionColumn",
                DisplayOrder = 5,
                DisplayText = "Select Row",
                Visible = ShowRowSelection
            });

            return settings;
        }


        #region Helper Data Items

        private static string GetSentence(int id)
        {
            var lastDigit = id % 10;
            var text = Sentences[lastDigit];
            return text;
        }

        private static readonly List<string> Sentences = new List<string>()
        {
            "To the guy who invented zero: Thanks for nothing!",
            "A plateau is the highest form of flattery.",
            "I didn't like my beard at first. Then it grew on me.",
            "What's brown and sticky? A stick.",
            "Why can't a bicycle stand on its own? It's two-tired.",
            "What’s more amazing than a talking dog? A spelling bee.",
            "Orion’s Belt is a huge waist of space.",
            "What did the grape say when it was stepped on? Nothing, it just let out a little wine.",
            "I'm reading a book about anti-gravity. I can't put it down.",
            "Once you've seen one shopping center, you've seen the mall."
        };

        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string DadJoke { get; set; }
            public bool IsEven { get; set; }
            public bool IsThird { get; set; }
        }

        #endregion Helper Data Items
    }
}

