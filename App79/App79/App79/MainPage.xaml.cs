using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App79
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

            //Mr. Mono will be added to the ListView because it uses an ObservableCollection
            employees.Add(new Employee() { DisplayName = "Mr. Mono" });
            employees.Add(new Employee() { DisplayName = "Mr. MonoMonoMonoMonoMonoMonoMonoMonoMonoMonoMonoMonoMonoMonoMonoMonoMonoMonoMonoMonoMonoMonoMonoMonoMonoMonoMonoMono" });
            employees.Add(new Employee() { DisplayName = "MrMonoMonoMonoMonoMonoMonoMonoMono. Mono" });
            employees.Add(new Employee() { DisplayName = "MrMonoMonnoMonoMonoMonoMono. Mono" });
            employees.Add(new Employee() { DisplayName = "MrMonoMonnoM" });
            employees.Add(new Employee() { DisplayName = "Mrno. MonoMonoMonoMonoMonoMonoMonoMonoMonoMonoMonoMonoMonoMono" });
            employees.Add(new Employee() { DisplayName = "MrMonoMonnoMonoMonoMonoMono. Mono" });
            employees.Add(new Employee() { DisplayName = "MrMonoMonnoMonoMonoMo" });

            listView.ItemsSource = employees;
            BindingContext = this;
        }
    }

    public class Employee
    {

        public string DisplayName { get; set; }
    }
    public class myButton :Button{ 
        

    }
}
