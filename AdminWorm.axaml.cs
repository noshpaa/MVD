using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.Script_C_;
using MySql.Data.MySqlClient;
using ClosedXML.Excel;

namespace AvaloniaApplication1;

public partial class AdminWorm : Window
{
    private List<Scripts> _script;
    private List<products> _svoystvaVeshes;
    private List<receipe> _monitors;
    private string _connString = "server=localhost;Port=3301;Database=biowik;UserID=root;password=Ghost45)";
    private MySqlConnection _sqlConnection;
    private List<filter_Meteo> _filterMeteos;

    public AdminWorm()
    {
        InitializeComponent();
        string sql = "SELECT * FROM person";
        Tables1(sql);
        FilterUser();
    }
    
    
     private void Tables1(string sql)
    {
        _script = new List<Scripts>();
        _sqlConnection = new MySqlConnection(_connString);
        _sqlConnection.Open();
        MySqlCommand command = new MySqlCommand(sql, _sqlConnection);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var current = new Scripts()
            {
                id = reader.GetInt32("person_id"),
                name = reader.GetString("name"),
                age = reader.GetInt32("age"),
                gender = reader.GetString("gender"),
                occupation = reader.GetString("occupation"),
                address = reader.GetString("address"),
                contact_number = reader.GetString("contact_number"),
                email = reader.GetString("email")
            };
            _script.Add(current);
        }
        _sqlConnection.Close();
        Grid1.ItemsSource = _script;
    }
     


    private void AddOnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            _sqlConnection.Open();
            MySqlCommand command =
                new MySqlCommand(
                    $"Insert into person  (name, age, gender, occupation, address, contact_number, email) Values ('"+t1.Text+"', '"+t2.Text+"', '"+t3.Text+"', '"+t4.Text+"', '"+t5.Text+"', '"+t6.Text+"', '"+t7.Text+"')", _sqlConnection);

            command.ExecuteNonQuery();
            _sqlConnection.Close();
        }
        catch (Exception exception)
        {
            Debug.WriteLine("Эта запись используется в других таблицах", ID_TextBox.Text = exception.Message);
        }
    }

    private void SaveOnClick(object? sender, RoutedEventArgs e)
    {
        _script = new List<Scripts>();
        _sqlConnection = new MySqlConnection(_connString);
        _sqlConnection.Open();
        string sql = "SELECT * FROM person";
        MySqlCommand command = new MySqlCommand(sql, _sqlConnection);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var current = new Scripts()
            {
                id = reader.GetInt32("person_id"),
                name = reader.GetString("name"),
                age = reader.GetInt32("age"),
                gender = reader.GetString("gender"),
                occupation = reader.GetString("occupation"),
                address = reader.GetString("address"),
                contact_number = reader.GetString("contact_number"),
                email = reader.GetString("email")
            };
            _script.Add(current);
        }
        _sqlConnection.Close();
        Grid1.ItemsSource = _script;
    }

    private void DeleteOnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            _sqlConnection.Open();
            string QeuryString = $"delete from person where person_id = {ID_TextBox.Text}";
            MySqlCommand command = new MySqlCommand(QeuryString, _sqlConnection);
            command.ExecuteNonQuery();
            _sqlConnection.Close();
        }
        catch (Exception)
        {

            Debug.WriteLine("Эта запись используется в других таблицах", ID_TextBox.Text);
        }
    }

    private void UpdateOnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            _sqlConnection.Open();
            string QueryString = $"update person set name = '"+t1.Text+"', age = '"+t2.Text+"', gender = '"+t3.Text+"', occupation = '"+t4.Text+"',  address = '"+t5.Text+"',  contact_number = '"+t6.Text+"',  email = '"+t7.Text+"' where person_id = '"+ID_TextBox.Text+"'";
            MySqlCommand command = new MySqlCommand(QueryString, _sqlConnection);
            command.ExecuteNonQuery();
            _sqlConnection.Close();
        }
        catch (Exception)
        {

            Debug.WriteLine("Эта запись используется в других таблицах", ID_TextBox.Text);
        }
    }

   
    
    
    private void FilterUser()
    {
        _filterMeteos = new List<filter_Meteo>();
        _sqlConnection = new MySqlConnection(_connString);
        _sqlConnection.Open();
        MySqlCommand command = new MySqlCommand("SELECT person_id, name FROM person", _sqlConnection);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var current = new filter_Meteo()
            {
                id4 = reader.GetInt32("person_id"),
                name = reader.GetString("name")
            };
            _filterMeteos.Add(current);
        }
        _sqlConnection.Close();
        var comboBox = this.FindControl<ComboBox>("Box");
        comboBox.ItemsSource = _filterMeteos;
    }
    private void Search_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        string sqlsearch = "select * from person WHERE name LIKE '%"+Search.Text+"%' OR age LIKE '%"+Search.Text+"%'";
        Tables1(sqlsearch);
    }

    private void Box_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var comboBox = (ComboBox)sender;
        var current = comboBox.SelectedItem as filter_Meteo;
        var filter = _script
            .Where(x => x.name == current.name)
            .ToList();
        Grid1.ItemsSource = filter;
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
    }

    private void NewButtonClick(object? sender, RoutedEventArgs e)
    {
        if (texts1.Text == "да" && texts2.Text== "да" && texts3.Text == "да" && texts4.Text == "да" && texts5.Text == "да" && texts6.Text == "да" && texts7.Text == "да" && texts8.Text == "да" && texts9.Text == "да" 
            && texts10.Text == "да"&& texts11.Text == "да"&& texts12.Text == "да"&& texts13.Text == "да"&& texts14.Text == "да"&& texts15.Text == "да"&& texts16.Text == "да"&& texts17.Text == "да"&& texts18.Text == "да"
            && texts19.Text == "да" && texts20.Text == "да" && texts21.Text == "да" && texts22.Text== "да" && texts23.Text == "да" && texts24.Text == "да" && texts25.Text == "да" && texts26.Text == "да" && texts27.Text == "да" && texts28.Text == "да" && texts29.Text == "да" 
            && texts30.Text == "да"&& texts31.Text == "да"&& texts32.Text == "да"&& texts33.Text == "да"&& texts34.Text == "да"&& texts35.Text == "да"&& texts36.Text == "да"&& texts37.Text == "да"&& texts38.Text == "да"
            && texts39.Text == "да" && texts40.Text == "да")
        {
            Result.Text = "Ваш тип темперамента ближе к холерику";
        }
        else if (texts1.Text == "нет" && texts2.Text== "нет" && texts3.Text == "нет" && texts4.Text == "нет" && texts5.Text == "нет" && texts6.Text == "нет" && texts7.Text == "нет" && texts8.Text == "нет" && texts9.Text == "нет" 
                   && texts10.Text == "нет" && texts11.Text == "нет" && texts12.Text == "нет"&& texts13.Text == "нет" && texts14.Text == "нет" && texts15.Text == "нет" && texts16.Text == "нет" && texts17.Text == "нет" && texts18.Text == "нет"
                   && texts19.Text == "нет" && texts20.Text == "нет" && texts21.Text == "нет" && texts22.Text== "нет" && texts23.Text == "нет" && texts24.Text == "нет" && texts25.Text == "нет" && texts26.Text == "нет" && texts27.Text == "нет" && texts28.Text == "нет" && texts29.Text == "нет" 
                   && texts30.Text == "нет" && texts31.Text == "нет" && texts32.Text == "нет"&& texts33.Text == "нет"&& texts34.Text == "нет"&& texts35.Text == "нет"&& texts36.Text == "нет"&& texts37.Text == "нет"&& texts38.Text == "нет"
                   && texts39.Text == "нет" && texts40.Text == "нет")
        {
            Result.Text = "Ваш тип темперамента холерик и флегматик";
        }
        
        
        else if (texts1.Text == "нет" && texts2.Text== "нет" && texts3.Text == "нет" && texts4.Text == "нет" && texts5.Text == "нет" && texts6.Text == "нет" && texts7.Text == "нет" && texts8.Text == "нет" && texts9.Text == "нет" 
                 && texts10.Text == "нет" && texts11.Text == "нет" && texts12.Text == "нет"&& texts13.Text == "нет" && texts14.Text == "нет" && texts15.Text == "нет" && texts16.Text == "нет" && texts17.Text == "нет" && texts18.Text == "нет"
                 && texts19.Text == "нет" && texts20.Text == "нет" && texts21.Text == "да" && texts22.Text== "да" && texts23.Text == "да" && texts24.Text == "да" && texts25.Text == "да" && texts26.Text == "да" && texts27.Text == "да" && texts28.Text == "да" && texts29.Text == "да" 
                 && texts30.Text == "да"&& texts31.Text == "да"&& texts32.Text == "да"&& texts33.Text == "да"&& texts34.Text == "да"&& texts35.Text == "да"&& texts36.Text == "да"&& texts37.Text == "да"&& texts38.Text == "да"
                 && texts39.Text == "да" && texts40.Text == "да")

        {
            Result.Text = "Ваш тип темперамента флегматик и сангвиник";
        }
        
        else if (texts1.Text == "да" && texts2.Text== "да" && texts3.Text == "да" && texts4.Text == "да" && texts5.Text == "да" && texts6.Text == "да" && texts7.Text == "да" && texts8.Text == "да" && texts9.Text == "да" 
                 && texts10.Text == "да"&& texts11.Text == "да" && texts12.Text == "да"&& texts13.Text == "да"&& texts14.Text == "да"&& texts15.Text == "да"&& texts16.Text == "да"&& texts17.Text == "да"&& texts18.Text == "да"
                 && texts19.Text == "да" && texts20.Text == "да" && texts21.Text == "нет" && texts22.Text== "нет" && texts23.Text == "нет" && texts24.Text == "нет" && texts25.Text == "нет" && texts26.Text == "нет" && texts27.Text == "нет" && texts28.Text == "нет" && texts29.Text == "нет" 
                 && texts30.Text == "нет" && texts31.Text == "нет" && texts32.Text == "нет"&& texts33.Text == "нет"&& texts34.Text == "нет"&& texts35.Text == "нет"&& texts36.Text == "нет"&& texts37.Text == "нет"&& texts38.Text == "нет"
                 && texts39.Text == "нет" && texts40.Text == "нет")
        {
            Result.Text = "Ваш тип темперамента меланхолик и флигматик";
        }
        
        else
        {
            Result.Text = "Ваш тип темперамента флегматик и холерик";
        }
    }

    private void Check_OnClick(object? sender, RoutedEventArgs e)
    {
        if (r1.IsChecked == true  && r5.IsChecked == true && r7.IsChecked == true &&
            r13.IsChecked == true && r17.IsChecked == true && r19.IsChecked == true && r29.IsChecked == true && 
            r33.IsChecked == true && r45.IsChecked == true && r51.IsChecked == true && r61.IsChecked == true &&
            r69.IsChecked == true && r73.IsChecked == true && r77.IsChecked == true && r79.IsChecked == true &&
            r85.IsChecked == true && r89.IsChecked == true && r93.IsChecked == true && r99.IsChecked == true)
        {
            ResultPs.Text = "Вы психически не устойчивы рекомендуется посетить психиатра";
        }
        else
        {
            ResultPs.Text = "Вы психически устойчивы";
        }
    }

    private void OrderOnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
           
            string QueryString = $"SELECT * FROM biowik.person order by gender;";
            Tables1(QueryString);
        }
        catch (Exception)
        {

            Debug.WriteLine("Эта запись используется в других таблицах", ID_TextBox.Text);
        }
    }
}