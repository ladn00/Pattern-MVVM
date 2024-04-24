using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Паттерн_MVVM
{
    class ApplicationViewModel : INotifyPropertyChanged
    {
        private Рецепт selectedRecipe;

        public ObservableCollection<Рецепт> Recipes { get; set; }
        public Рецепт SelectedRecipe
        {
            get { return selectedRecipe; }
            set
            {
                selectedRecipe = value;
                OnPropertyChanged("SelectedRecipe");
            }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Рецепт recipe = new Рецепт("", Рецепт.razdel.Горячее, 0, 0, "", "", "");
                      Recipes.Insert(0, recipe);
                      SelectedRecipe = recipe;
                  }));
            }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      Рецепт recipe = obj as Рецепт;
                      if (recipe != null)
                      {
                          Recipes.Remove(recipe);
                      }
                  },
                 (obj) => Recipes.Count > 0));
            }
        }

        RelayCommand doubleCommand;
        public RelayCommand DoubleCommand
        {
            get
            {
                return doubleCommand ??
                    (doubleCommand = new RelayCommand(obj =>
                    {
                        Рецепт phone = obj as Рецепт;
                        if (phone != null)
                        {
                            Рецепт phoneCopy = new Рецепт(phone.Title, phone.RecipeRazdel, phone.Price, phone.Cal, phone.MainIngridient, phone.Description, phone.Photo);
                            Recipes.Insert(0, phoneCopy);
                        }
                    }));
            }
        }

        public ApplicationViewModel()
        {
            Recipes = new ObservableCollection<Рецепт>
            {
                new Рецепт("Цезарь", Рецепт.razdel.Салат, 400, 150, "Курица", "Cалат цезарь. ", "imgs/Цезарь.jpg"),
                new Рецепт ("Сырный суп", Рецепт.razdel.Горячее, 500, 210,"Сыр", "Очень сырный суп. ", "imgs/Сырный суп.jpg" ),
                new Рецепт ("Вителло-тоннато",Рецепт.razdel.Закуска, 300, 200, "Мясо", "Закуска вителло-тоннато.", "imgs/Что.jpg"),
                new Рецепт ("Чизкейк", Рецепт.razdel.Десерт, 300, 250, "Сливочный сыр", "Чизкейк Нью-Йорк. ", "imgs/Чизкейк.jpg" )
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
