using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace HydrationReminderApp.Models
{
    public class Calculation 
    {
        public Calculation(double height, double weight)
        {
            Height = height;
            Weight = weight;
        }
        public double Height { get; set; }
        public double Weight { get; set; }

        public double Calculate()
        {
            return Height * Weight;
        }
    }
}