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

public partial class ClientWorm : Window
{
    private List<Scripts> _script;
    private List<products> _svoystvaVeshes;
    private List<receipe> _monitors;
    private string _connString = "server=localhost;Port=3301;Database=biowik;UserID=root;password=Ghost45)";
    private MySqlConnection _sqlConnection;
    public ClientWorm()
    {
        InitializeComponent();
        string sql = "SELECT * FROM person";
        // string sql2 = "SELECT * FROM product";
        // string sql3 = "SELECT * FROM recipe";
        Tables1(sql);
        // Tables2(sql2);
        // Tables3(sql3);

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
    
    private void Tables2(string sql)
    {
        _svoystvaVeshes = new List<products>();
        _sqlConnection = new MySqlConnection(_connString);
        _sqlConnection.Open();
        
        MySqlCommand command = new MySqlCommand(sql, _sqlConnection);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var current = new products()
            {
                id1 = reader.GetInt32("product_id"),
                product = reader.GetString("product_name"),
                category1 = reader.GetInt32("category_id"),
                bakery1= reader.GetInt32("bakery_id")
            };
            _svoystvaVeshes.Add(current);
        }
        _sqlConnection.Close();
        Grid2.ItemsSource = _svoystvaVeshes;
    }
    
    private void Tables3(string sql)
    {
        _monitors = new List<receipe>();
        _sqlConnection = new MySqlConnection(_connString);
        _sqlConnection.Open();
        MySqlCommand command = new MySqlCommand(sql, _sqlConnection);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var current = new receipe()
            {
                id2 = reader.GetInt32("recipe_id"),
                receipe_name = reader.GetString("recipe_name"),
                instructions = reader.GetString("instructions"),
                product_id = reader.GetInt32("product_id")
            };
            _monitors.Add(current);
        }
        _sqlConnection.Close();
        Grid3.ItemsSource = _monitors;
    }
    

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
    }
}