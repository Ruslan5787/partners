using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore; // Для EF Core


namespace Plants_App {
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window {
        Partner partnerObj;
        public EditWindow(Partner partner) {
            InitializeComponent();

            partnerObj = partner;

            typeInput.Text = partner.PartnerType;
            nameInput.Text = partner.PartnerName;
            directorInput.Text = partner.Director;
            phoneInput.Text = partner.PartnerPhone;
            retingInput.Text = partner.Reyting.ToString();
        }

        private void ButtonClick(object sender, RoutedEventArgs e) {
            if(typeInput.Text != "" && nameInput.Text != "" && directorInput.Text != "" && phoneInput.Text != "" && retingInput.Text != "") {
                error.Visibility = Visibility.Visible;
                if(!Regex.IsMatch(typeInput.Text, @"^[А-Яа-яЁё]{3}$")) {
                    error.Text = "Ввдетие кириллицей тип компании";
                } else if(!Regex.IsMatch(nameInput.Text, @"^[А-Яа-яЁё0-9\s]+$")) {
                    error.Text = "Ввдетие название компании (можно вводить кириллицу и цифры)";
                } else if (!Regex.IsMatch(directorInput.Text, @"^[А-ЯЁ][а-яё]+\s[А-ЯЁ][а-яё]+\s[А-ЯЁ][а-яё]+$")) {
                    error.Text = "Ввдетие ФИО директора компании";
                } else if(!Regex.IsMatch(phoneInput.Text, @"^\d{3}\s\d{3}\s\d{2}\s\d{2}$")) {
                    error.Text = "Ввдетие корректный номер телефона (пример: 493 123 45 67)";
                } else if (!Regex.IsMatch(retingInput.Text, @"^(10|[0-9])$")) {
                    error.Text = "Ввдетие корректное значение рейтинга (от 0 до 10)";
                } else {
                    error.Text = "";

                    if (partnerObj != null) {
                        partnerObj.PartnerType = typeInput.Text;
                        partnerObj.PartnerName = nameInput.Text;
                        partnerObj.Director = directorInput.Text;
                        partnerObj.PartnerPhone = phoneInput.Text;
                        partnerObj.Reyting = Convert.ToByte(retingInput.Text);

                        using (PlantsBdContext context = new PlantsBdContext()) {
                            context.Entry(partnerObj).State = EntityState.Modified;
                            context.SaveChanges();
                        }
                    } else {
                        throw new Exception("Продукт не найден");
                    }

                    this.Close();
                }
            } else {
                error.Visibility = Visibility.Visible;
                error.Text = "Заполните все поля данными";
            }
        }

        private void ButtonClick1(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
