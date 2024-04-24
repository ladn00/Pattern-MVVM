using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Паттерн_MVVM
{
    public class Рецепт : INotifyPropertyChanged
    {
        public enum razdel
        {
            Горячее,
            Десерт,
            Закуска,
            Салат,
            Гарнир
        }
        private string title;
        private string mainIngridient;
        private razdel recipeRazdel;
        private string description;
        private double cal;
        private double price;
        private string photo;
        public string Title { get { return title; }
            set
            {
                // обработка изменения свойства
                title = value;
                OnPropertyChanged("Title");
            }
        }
        public string MainIngridient {
            get { return mainIngridient; }
            set
            {
                // обработка изменения свойства
                mainIngridient = value;
                OnPropertyChanged("mainIngridient");
            }
        }
        public razdel RecipeRazdel {
            get { return recipeRazdel; }
            set
            {
                // обработка изменения свойства
                recipeRazdel = value;
                OnPropertyChanged("recipeRazdel");
            }
        }
        public string Description {
            get { return description; }
            set
            {
                // обработка изменения свойства
                description = value;
                OnPropertyChanged("description");
            }
        }
        public double Cal {
            get { return cal; }
            set
            {
                // обработка изменения свойства
                cal = value;
                OnPropertyChanged("cal");
            }
        }
        public double Price {
            get { return price; }
            set
            {
                // обработка изменения свойства
                price = value;
                OnPropertyChanged("price");
            }
        }
        public string Photo {
            get { return photo; }
            set
            {
                // обработка изменения свойства
                photo = value;
                OnPropertyChanged("photo");
            }
        }

        public Рецепт(string Title, razdel recipeRazdel, double price, double cal, string mainIngridient, string description, string photo)
        {
            this.Title = Title;
            this.recipeRazdel = recipeRazdel;
            this.price = price;
            this.cal = cal;
            this.mainIngridient = mainIngridient;
            this.description = description;
            this.photo = photo;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
